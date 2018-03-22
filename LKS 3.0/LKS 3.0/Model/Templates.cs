using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.Data.Entity;


namespace LKS_3._0.Model
{
	class Templates
	{
		List<Student> students; // текущие выбранные студенты(урощает работу с несколькими взводами)
		Student selectedStudent;    // выбранный студент
		Relative selectedStudentMather, //его мать
			selectedStudentFather,  //его отец
			selectedRelative;   //его дорственник
		Troop selectedTrop; //выбранный взвод
		Summer summer; // информация о сборах
		Model.Department adminInfo; // Военком и нач кафедры
		List<Admin> admins; // список администрации на сборах

		// TODO
		ApplicationContext DataBase;// ссылка на БД надо отрефакторить код чтобы просто открывать БД, а не передавать ее

		public Templates(string fileName, ref ApplicationContext temp_DataBase, List<Student> Students = null, List<Prepod> prepods = null, List<Troop> troops = null, Summer charges = null)
		{   //TODO отрефактрить этот код
			// КОСТЫЛЬ
			if (Students == null)
			{
				Students = new List<Student>();
			}

			if (troops == null)
			{
				troops = new List<Troop>();
			}

			if (Students.Count == 0 && troops.Count != 0)
			{
				this.students = troops.First().ListStudents.ToList();
				selectedTrop = troops.First();
			}
			else
			{
				this.students = Students;
			}
			try
			{
				selectedStudent = students.First(); // устанавливаем выбранного стуента
			}
			catch (System.InvalidOperationException ex)
			{
				System.Windows.MessageBox.Show("Во взводе нет студентов!");
				return;
			}
			changeSelectedStudent(); // меняем мать и отца студента

			////
			DataBase = temp_DataBase;
			DataBase.Summers.Load();
			DataBase.Departments.Load();
			DataBase.Admins.Load();
			summer = DataBase.Summers.Local.ToList().First(); // в summers должна быть только одна запись!
			adminInfo = DataBase.Departments.Local.ToList().First();
			admins = DataBase.Admins.Local.ToList();

			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog(); // создали новое диалоговое окно
			dlg.Filter = "Word files (*.docx)|*.docx"; // добавили фильтер
													   // добавили название файла в предложенное название
			dlg.FileName = fileName.Substring(fileName.LastIndexOf('\\') + 1, fileName.LastIndexOf('.') - fileName.LastIndexOf('\\') - 1) + " ";
			if (troops.Count == 0)
			{
				dlg.FileName += students.First().MiddleName;
			}
			else
			{
				dlg.FileName += troops.First().NumberTroop;
			}

			if (dlg.ShowDialog() == true) // запустили окно
			{
				File.Copy(fileName, dlg.FileName, true); // создали выходной файл и теперь работаем с ним
			}
			else
			{
				return;
			}
			using (WordprocessingDocument doc = WordprocessingDocument.Open(dlg.FileName, true)) // открыли документ
			{
				foreach (Table table
					in doc.MainDocumentPart.Document.Body.Elements<Table>()) // проходим все таблицы
				{
					if (!table.Descendants<SdtElement>().Any()) // проверка на наличие закладок в текущей таблице
					{
						continue;
					}

					//проверяем как строится таблица( с добавлением строк или используется уже существующие строки)

					if (table.Descendants<SdtElement>().ToList().Find(obj =>
						obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "БЕЗ ДОБАВЛЕНИЯ СТРОК") != null)
					{ // Без добавления строк
					  // удаляем лишню закладку
						table.Descendants<SdtElement>().ToList().Find(obj =>
						obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "БЕЗ ДОБАВЛЕНИЯ СТРОК").Remove();
						int rowIndex = 0; // костыль который поможет определить с какой строкой мы сейчас работаем
										  // первая строка с которой мы будем работать это та где мы обнаружили команды 
						foreach (TableRow row in table.Elements<TableRow>())
						{
							if (row.Descendants<SdtElement>().Any()) // проверка на наличие закладок в строке
							{
								TableRow tempRow = row.Clone() as TableRow; // создали копию строки
								foreach (SdtElement formattedText in row.Descendants<SdtElement>().ToList())
								{
									formattedText.Remove(); // удалили все закладки в строке с закладками
															// команды остались в копии строки и мы будем работать с ними
								}

								// проверяем кам заполнять таблицу (студентами, взводами или родственниками)
								string type = null;
								try
								{
									type = (tempRow.Descendants<SdtElement>().ToList().Find(obj =>
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "СТУДЕНТЫ" ||
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "ВЗВОДА" ||
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "РОДСТВЕННИКИ") as SdtElement)
									 .Descendants<SdtAlias>().First().Val.ToString().ToUpper(); // получили запись о том, кем заполнять таблицу
								}
								//TODO Обработать исключения, если файнд вернул false
								catch (ArgumentNullException ex)
								{

								}

									if (type != null)
								{
									tempRow.Descendants<SdtElement>().ToList().Find(obj =>
									obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == type).Remove(); // удалили лишнюю закладку
									switch (type)
									{
										case "СТУДЕНТЫ":
											{
												for (int i = 0; i < students.Count; i++) // проходим по всем студентам
												{
													selectedStudent = students[i];
													changeSelectedStudent();
													stringHandling(table, rowIndex, tempRow, i); // функция работы со строками
													rowIndex++; // перешли на след строку
												}
												break;
											}
										case "ВЗВОДА":
											{
												for (int i = 0; i < troops.Count; i++) // проходим по всем взводам
												{
													selectedTrop = troops[i];
													changeTroop();
													stringHandling(table, rowIndex, tempRow, i); // функция работы со строками
													rowIndex++; // перешли на след строку
												}
												break;
											}
										case "РОДСТВЕННИКИ":
											{
												for (int i = 0; i < selectedStudent.ListRelatives.Count; i++) // проходим по всем родственникам
												{
													selectedRelative = selectedStudent.ListRelatives[i];
													stringHandling(table, rowIndex, tempRow, i); // функция работы со строками
													rowIndex++; // перешли на след строку
												}
												break;
											}
										default:
											{
												System.Windows.MessageBox.Show("Ошибра в типе таблицы!");
												break;
											}
									}
								}
									
							}
							rowIndex++; // если нет закладок то переходим на след строку
						}
					}
					else // с добавлением строк
					{
						foreach (TableRow row in table.Elements<TableRow>())
						{
							if (row.Descendants<SdtElement>().Any()) // проверка на наличие закладок в строке
							{

								string type = null;
								try
								{
									type = (row.Descendants<SdtElement>().ToList().Find(obj =>
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "СТУДЕНТЫ" ||
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "ВЗВОДА" ||
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "РОДСТВЕННИКИ") as SdtElement)
									 .Descendants<SdtAlias>().First().Val.ToString().ToUpper(); // получили запись о том, кем заполнять таблицу
								}
								//TODO Обработать исключения, если файнд вернул false
								catch (NullReferenceException ex) // 
								{
									type = null; // в таблицу не надо заполнять повторяющимися стрками(она исспользуется просто как форматирование)
								}

								if (type != null)
								{
									row.Descendants<SdtElement>().ToList().Find(obj =>
									obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == type).Remove(); // удалили лишнюю закладку
									switch (type)
									{
										case "СТУДЕНТЫ":
											{
												for (int i = 0; i < students.Count; i++) // проходим по всем студентам
												{
													selectedStudent = students[i];
													changeSelectedStudent();
													TableRow tempRow = row.Clone() as TableRow;
													foreach (SdtElement formattedText in tempRow.Descendants<SdtElement>().ToList())
													{
														BookmarkingToCommand(formattedText, i);
													}
													table.AppendChild(tempRow);
												}
												row.Parent.RemoveChild(row);
												break;
											}
										case "ВЗВОДА":
											{
												for (int i = 0; i < troops.Count; i++) // проходим по всем взводам
												{
													selectedTrop = troops[i];
													changeTroop();
													TableRow tempRow = row.Clone() as TableRow;
													foreach (SdtElement formattedText in tempRow.Descendants<SdtElement>().ToList())
													{
														BookmarkingToCommand(formattedText, i);
													}
													table.AppendChild(tempRow);
												}
												row.Parent.RemoveChild(row);
												break;
											}
										case "РОДСТВЕННИКИ":
											{
												for (int i = 0; i < selectedStudent.ListRelatives.Count; i++) // проходим по всем родственникам
												{
													selectedRelative = selectedStudent.ListRelatives[i];
													TableRow tempRow = row.Clone() as TableRow;
													foreach (SdtElement formattedText in tempRow.Descendants<SdtElement>().ToList())
													{
														BookmarkingToCommand(formattedText, i);
													}
													table.AppendChild(tempRow);
												}
												row.Parent.RemoveChild(row);
												break;
											}
										default:
											{
												System.Windows.MessageBox.Show("Ошибра в типе таблицы!");
												break;
											}
									}
								}
							}
						}
					}
				}

				// проходим по всем элементам "форматированный текст"(далее просто "закладка")
				// и сверяем имя закладки со списком команд
				// как обычно здесь есть немного магии (без toList может работать не правильно)

				// как всегда небольшой костыль ( сбрасываю исходного студента на начало)(но поидее это не обязательно)
				selectedStudent = students[0];
				changeSelectedStudent();
				foreach (SdtElement formattedText in doc.MainDocumentPart.Document.Body.Descendants<SdtElement>().ToList())
				{
					string valueCommand = findCommand(formattedText.SdtProperties.GetFirstChild<SdtAlias>().Val);
					if (valueCommand == "ФОТО" || valueCommand == "ВЗВОД ПРЕПОДАВАТЕЛЬ ПОДПИСЬ")
					{
						string path; // путь к фото( в зависимости от команды либо к фото студента, либо к подписи препода
						if(valueCommand == "ФОТО")
						{
							path = selectedStudent.ImagePath;
						}
						else
						{
							path = selectedTrop.ResponsiblePrepod.SignaturePath;
						}
						// скопипастил вставку картинок из мдсн
						MainDocumentPart mainPart = doc.MainDocumentPart;
						ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
						try
						{
							using (FileStream stream = new FileStream(path, FileMode.Open))
							{
								imagePart.FeedData(stream);
							}
							AddImageToBody(formattedText, mainPart.GetIdOfPart(imagePart));
						}
						catch (System.NotSupportedException ex)
						{

							System.Windows.MessageBox.Show(ex.Message + "/n Ошибка чтения ФОТО!");
							continue;
						}
						continue;
					}

					Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run; // скопировал первого потомка
					(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
					formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																			   // и заменил закладку обычным текстом
				}
			}
			System.Windows.MessageBox.Show("Готово!");
		}

		private static void AddImageToBody(SdtElement formattedText, string relationshipId)
		{
			// скопипастил код из МДСН 
			var element =
				 new Drawing(
					 new DW.Inline(
						 new DW.Extent() { Cx = 990000L, Cy = 792000L },
						 new DW.EffectExtent()
						 {
							 LeftEdge = 0L,
							 TopEdge = 0L,
							 RightEdge = 0L,
							 BottomEdge = 0L
						 },
						 new DW.DocProperties()
						 {
							 Id = (UInt32Value)1U,
							 Name = "Picture 1"
						 },
						 new DW.NonVisualGraphicFrameDrawingProperties(
							 new A.GraphicFrameLocks() { NoChangeAspect = true }),
						 new A.Graphic(
							 new A.GraphicData(
								 new PIC.Picture(
									 new PIC.NonVisualPictureProperties(
										 new PIC.NonVisualDrawingProperties()
										 {
											 Id = (UInt32Value)0U,
											 Name = "New Bitmap Image.jpg"
										 },
										 new PIC.NonVisualPictureDrawingProperties()),
									 new PIC.BlipFill(
										 new A.Blip(
											 new A.BlipExtensionList(
												 new A.BlipExtension()
												 {
													 Uri =
														"{28A0092B-C50C-407E-A947-70E740481C1C}"
												 })
										 )
										 {
											 Embed = relationshipId,
											 CompressionState =
											 A.BlipCompressionValues.Print
										 },
										 new A.Stretch(
											 new A.FillRectangle())),
									 new PIC.ShapeProperties(
										 new A.Transform2D(
											 new A.Offset() { X = 0L, Y = 0L },
											 new A.Extents() { Cx = 990000L, Cy = 792000L }),
										 new A.PresetGeometry(
											 new A.AdjustValueList()
										 )
										 { Preset = A.ShapeTypeValues.Rectangle }))
							 )
							 { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
					 )
					 {
						 DistanceFromTop = (UInt32Value)0U,
						 DistanceFromBottom = (UInt32Value)0U,
						 DistanceFromLeft = (UInt32Value)0U,
						 DistanceFromRight = (UInt32Value)0U,
						 EditId = "50D07946"
					 });

			// Append the reference to body, the element should be in a Run.
			formattedText.Parent.ReplaceChild(new Run(element), formattedText);
		}

		/// <summary>
		/// Замена закладки на команду
		/// </summary>
		/// <param name="formattedText">Закладка</param>
		/// <param name="i">Номер строки в таблице(нужно для команды №)</param>
		private void BookmarkingToCommand(SdtElement formattedText, int i)
		{
			string valueCommand;
			if (formattedText.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "НОМЕР")
			{
				valueCommand = (i + 1).ToString();
			}
			else
			{
				valueCommand = findCommand(formattedText.Descendants<SdtAlias>().First().Val);
			}

			// TODO Добавить обработку ситуации когда в закладке нет текста)
			Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run;
			(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
			if (formattedText.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "НОВАЯ СТРОКА")
			{
				tempRun.AppendChild(new Break());
			}
			formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																	   // и заменил закладку обычным текстом


		}

		/// <summary>
		///  Преобразование строки путем замены ячеек на ячейки из шаблонной строки(без добавления строк)
		/// </summary>
		/// <param name="table">Таблица с которой работаем</param>
		/// <param name="rowIndex">Индекс строки</param>
		/// <param name="tempRow">Шаблонная строка</param>
		/// <param name="i">Номер строки в таблице(нужно для команды №)</param>
		private void stringHandling(Table table, int rowIndex, TableRow tempRow, int i)
		{
			// перечеслитель для перебора ячеек в строке которая назодится в таблице(изначально он стоит ДО нулевой позиции
			IEnumerator<TableCell> IEcell = table.Elements<TableRow>().ToList()[rowIndex].
											Descendants<TableCell>().ToList().GetEnumerator();
			foreach (TableCell cell in tempRow.Descendants<TableCell>().ToList()) // проходим по всем ячейкам во временной строке
			{
				IEcell.MoveNext();// передвинули перечеслитель
				if (cell.Descendants<SdtElement>().Any()) // проверка на наличие закладок в ячейке
				{
					// ссылка на копиию, которой мы заменим текущую выбранную ячейку в строке
					TableCell tempCell = cell.Clone() as TableCell;
					IEcell.Current.Parent.ReplaceChild(tempCell, IEcell.Current); // замена
					foreach (SdtElement formattedText in tempCell.Descendants<SdtElement>().ToList())
					{
						BookmarkingToCommand(formattedText, i);
						
					}
				}
			}
		}

		private string findCommand(string command)
		{
			if (command.ToUpper() == "НОВАЯ СТРОКА")
			{
				return "";
			}

			if (command.ToUpper() == "ТЕКУЩАЯ ДАТА")
			{
				return DateTime.Now.ToString("dd.MM.yyyy");
			}

			if (command.ToUpper() == "ФОТО")
			{
				return "ФОТО";
			}

			// Студент
			if (command.ToUpper() == "ИМЯ")
			{
				return selectedStudent.FirstName;
			}

			if (command.ToUpper() == "ФАМИЛИЯ")
			{
				return selectedStudent.MiddleName;
			}

			if (command.ToUpper() == "ОТЧЕСТВО")
			{
				return selectedStudent.LastName;
			}

			if (command.ToUpper() == "ФАКУЛЬТЕТ")
			{
				return selectedStudent.Faculty;
			}

			if (command.ToUpper() == "ГРУППА")
			{
				return selectedStudent.Group;
			}

			if (command.ToUpper() == "ВУС")
			{
				return selectedStudent.SpecialityName;
			}

			if (command.ToUpper() == "УСЛОВИЯ ОБУЧЕНИЯ")
			{
				return selectedStudent.ConditionsOfEducation;
			}

			if (command.ToUpper() == "СРЕДНИЙ БАЛЛ")
			{
				return selectedStudent.AvarageScore;
			}

			if (command.ToUpper() == "ГОД ПОСТУПЛЕНИЯ В МАИ")
			{
				return selectedStudent.YearOfAddMAI;
			}

			if (command.ToUpper() == "ГОД ОКОНЧАНИЯ МАИ")
			{
				return selectedStudent.YearOfEndMAI;
			}

			if (command.ToUpper() == "ГОД ПОСТУПЛЕНИЯ НА КАФЕДРУ")
			{
				return selectedStudent.YearOfAddVK;
			}

			if (command.ToUpper() == "ГОД ОКОНЧАНИЯ КАФЕДРЫ")
			{
				return selectedStudent.YearOfEndVK;
			}

			if (command.ToUpper() == "НОМЕР ПРИКАЗА")
			{
				return selectedStudent.NumberOfOrder;
			}

			if (command.ToUpper() == "ДАТА ПРИКАЗА")
			{
				return selectedStudent.DateOfOrder;
			}

			if (command.ToUpper() == "ВОЕНКОМАТ")
			{
				return selectedStudent.Rectal;
			}

			if (command.ToUpper() == "ДЕНЬ РОЖДЕНИЯ")
			{
				return selectedStudent.Birthday;
			}

			if (command.ToUpper() == "МЕСТО РОЖДЕНИЯ")
			{
				return selectedStudent.PlaceBirthday;
			}

			if (command.ToUpper() == "НАЦИЯ")
			{
				return selectedStudent.Nationality;
			}

			if (command.ToUpper() == "ДОМАШНИЙ НОМЕР")
			{
				return selectedStudent.HomePhone;
			}

			if (command.ToUpper() == "МОБИЛЬНЫЙ НОМЕР")
			{
				return selectedStudent.MobilePhone;
			}

			if (command.ToUpper() == "АДРЕС ПРОЖИВАНИЯ")
			{
				return selectedStudent.PlaceOfResidence;
			}

			if (command.ToUpper() == "АДРЕС РЕГИСТРАЦИИ")
			{
				return selectedStudent.PlaceOfRegestration;
			}

			if (command.ToUpper() == "ШКОЛА")
			{
				return selectedStudent.School;
			}

			if (command.ToUpper() == "ДОЛЖНОСТЬ")
			{
				return selectedStudent.Rank;
			}


			if (command.ToUpper() == "ВЗВОД")
			{
				return selectedStudent.Troop;
			}

			if (command.ToUpper() == "ИНИЦИАЛЫ")
			{
				return selectedStudent.initials();
			}

			if (command.ToUpper() == "СЛУЖБА В ВС")
			{
				return selectedStudent.Military;
			}

			if (command.ToUpper() == "СЕМЕЙНЫЙ СТАТУС")
			{
				return selectedStudent.FamiliStatys;
			}

			if (command.ToUpper() == "ГРУППА КРОВИ")
			{
				return selectedStudent.BloodType;
			}

			if (command.ToUpper() == "СПЕЦИАЛЬНОСТЬ В ИНСТИТУТЕ")
			{
				return selectedStudent.SpecInst;
			}



			//
			//БЛОК РОДСТВЕННИКОВ
			//
			if (selectedRelative != null)
			{
				if (command.ToUpper() == "РОД ИМЯ")
				{
					return selectedRelative.FirstName;
				}

				if (command.ToUpper() == "РОД ФАМИЛИЯ")
				{
					return selectedRelative.MiddleName;
				}

				if (command.ToUpper() == "РОД ОТЧЕСТВО")
				{
					return selectedRelative.LastName;
				}

				if (command.ToUpper() == "РОД ДЕВИЧЬЯ ФАМИЛИЯ")
				{
					return selectedRelative.MaidenName;
				}

				if (command.ToUpper() == "РОД ДЕНЬ РОЖДЕНИЯ")
				{
					return selectedRelative.Birthday;
				}

				if (command.ToUpper() == "РОД АДРЕС РЕГЕРИСТРАЦИИ")
				{
					return selectedRelative.PlaceOfRegestration;
				}

				if (command.ToUpper() == "РОД АДРЕС ПРОЖИВАНИЯ")
				{
					return selectedRelative.PlaceOfResidence;
				}

				if (command.ToUpper() == "РОД МОБИЛЬНЫЙ НОМЕР")
				{
					return selectedRelative.MobilePhone;
				}

				if (command.ToUpper() == "РОД СТЕПЕНЬ РОДСТВА")
				{
					return selectedRelative.RelationDegree;
				}

				if (command.ToUpper() == "РОД СОСТОЯНИЕ ЗДОРОВЬЯ")
				{
					return selectedRelative.HealthStatus;
				}

				if (command.ToUpper() == "РОД ИНИЦИАЛЫ")
				{
					return selectedRelative.initials();
				}
			}
			//Мать
			if (selectedStudentMather != null)
			{
				if (command.ToUpper() == "МАТЬ ИМЯ")
				{
					return selectedStudentMather.FirstName;
				}

				if (command.ToUpper() == "МАТЬ ФАМИЛИЯ")
				{
					return selectedStudentMather.MiddleName;
				}

				if (command.ToUpper() == "МАТЬ ОТЧЕСТВО")
				{
					return selectedStudentMather.LastName;
				}

				if (command.ToUpper() == "МАТЬ ДЕВИЧЬЯ ФАМИЛИЯ")
				{
					return selectedStudentMather.MaidenName;
				}

				if (command.ToUpper() == "МАТЬ ДЕНЬ РОЖДЕНИЯ")
				{
					return selectedStudentMather.Birthday;
				}

				if (command.ToUpper() == "МАТЬ АДРЕС РЕГИСТРАЦИИ")
				{
					return selectedStudentMather.PlaceOfRegestration;
				}

				if (command.ToUpper() == "МАТЬ АДРЕС ПРОЖИВАНИЯ")
				{
					return selectedStudentMather.PlaceOfResidence;
				}

				if (command.ToUpper() == "МАТЬ МОБИЛЬНЫЙ НОМЕР")
				{
					return selectedStudentMather.MobilePhone;
				}

				if (command.ToUpper() == "МАТЬ СТЕПЕНЬ РОДСТВА")
				{
					return selectedStudentMather.RelationDegree;
				}

				if (command.ToUpper() == "МАТЬ СОСТОЯНИЕ ЗДОРОВЬЯ")
				{
					return selectedStudentMather.HealthStatus;
				}

				if (command.ToUpper() == "МАТЬ ИНИЦИАЛЫ")
				{
					return selectedStudentMather.initials();
				}
			}
			// ОТЕЦ(ОТЧИМ)
			if (selectedStudentFather != null)
			{
				if (command.ToUpper() == "ОТЕЦ ИМЯ")
				{
					return selectedStudentFather.FirstName;
				}

				if (command.ToUpper() == "ОТЕЦ ФАМИЛИЯ")
				{
					return selectedStudentFather.MiddleName;
				}

				if (command.ToUpper() == "ОТЕЦ ОТЧЕСТВО")
				{
					return selectedStudentFather.LastName;
				}

				if (command.ToUpper() == "ОТЕЦ ДЕВИЧЬЯ ФАМИЛИЯ")
				{
					return selectedStudentFather.MaidenName;
				}

				if (command.ToUpper() == "ОТЕЦ ДЕНЬ РОЖДЕНИЯ")
				{
					return selectedStudentFather.Birthday;
				}

				if (command.ToUpper() == "ОТЕЦ АДРЕС РЕГИСТРАЦИИ")
				{
					return selectedStudentFather.PlaceOfRegestration;
				}

				if (command.ToUpper() == "ОТЕЦ АДРЕС ПРОЖИВАНИЯ")
				{
					return selectedStudentFather.PlaceOfResidence;
				}

				if (command.ToUpper() == "ОТЕЦ МОБИЛЬНЫЙ НОМЕР")
				{
					return selectedStudentFather.MobilePhone;
				}

				if (command.ToUpper() == "ОТЕЦ СТЕПЕНЬ РОДСТВА")
				{
					return selectedStudentFather.RelationDegree;
				}

				if (command.ToUpper() == "ОТЕЦ СОСТОЯНИЕ ЗДОРОВЬЯ")
				{
					return selectedStudentFather.HealthStatus;
				}

				if (command.ToUpper() == "ОТЕЦ ИНИЦИАЛЫ")
				{
					return selectedStudentFather.initials();
				}
			}

			// Взвод
			if (selectedTrop != null)
			{
				if (command.ToUpper() == "ВЗВОД НОМЕР")
				{
					return selectedTrop.NumberTroop;
				}

				if (command.ToUpper() == "ВЗВОД КОЛ-ВО ЧЕЛОВЕК")
				{
					return selectedTrop.StaffCount.ToString();
				}

				if (command.ToUpper() == "ВЗВОД ДЕНЬ ПРИХОДА")
				{
					return selectedTrop.Day;
				}

				if (command.ToUpper() == "ВЗВОД ВУС")
				{
					return selectedTrop.Vus;
				}

				if (selectedTrop.ResponsiblePrepod != null)
				{
					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ИМЯ")
					{
						return selectedTrop.ResponsiblePrepod.FirstName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ФАМИЛИЯ")
					{
						return selectedTrop.ResponsiblePrepod.MiddleName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ОТЧЕСТВО")
					{
						return selectedTrop.ResponsiblePrepod.LastName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ЗВАНИЕ")
					{
						return selectedTrop.ResponsiblePrepod.Coolness;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ДОЛЖНОСТЬ")
					{
						return selectedTrop.ResponsiblePrepod.PrepodRank;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ИНИЦИАЛЫ")
					{
						return selectedTrop.ResponsiblePrepod.initials();
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ПОДПИСЬ")
					{
						return "ВЗВОД ПРЕПОДАВАТЕЛЬ ПОДПИСЬ";
					}
				}

				// Командир взвода
				if (selectedTrop.PlatoonCommander != null)
				{

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ИМЯ")
					{
						return selectedTrop.PlatoonCommander.FirstName;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ФАМИЛИЯ")
					{
						return selectedTrop.PlatoonCommander.MiddleName;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ОТЧЕСТВО")
					{
						return selectedTrop.PlatoonCommander.LastName;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ФАКУЛЬТЕТ")
					{
						return selectedTrop.PlatoonCommander.Faculty;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГРУППА")
					{
						return selectedTrop.PlatoonCommander.Group;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ВУС")
					{
						return selectedTrop.PlatoonCommander.SpecialityName;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР УСЛОВИЯ ОБУЧЕНИЯ")
					{
						return selectedTrop.PlatoonCommander.ConditionsOfEducation;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР СРЕДНИЙ БАЛЛ")
					{
						return selectedTrop.PlatoonCommander.AvarageScore;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГОД ПОСТУПЛЕНИЯ В МАИ")
					{
						return selectedTrop.PlatoonCommander.YearOfAddMAI;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГОД ОКОНЧАНИЯ МАИ")
					{
						return selectedTrop.PlatoonCommander.YearOfEndMAI;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГОД ПОСТУПЛЕНИЯ НА КАФЕДРУ")
					{
						return selectedTrop.PlatoonCommander.YearOfAddVK;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГОД ОКОНЧАНИЯ КАФЕДРЫ")
					{
						return selectedTrop.PlatoonCommander.YearOfEndVK;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР НОМЕР ПРИКАЗА")
					{
						return selectedTrop.PlatoonCommander.NumberOfOrder;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ДАТА ПРИКАЗА")
					{
						return selectedTrop.PlatoonCommander.DateOfOrder;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ВОЕНКОМАТ")
					{
						return selectedTrop.PlatoonCommander.Rectal;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ДЕНЬ РОЖДЕНИЯ")
					{
						return selectedTrop.PlatoonCommander.Birthday;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР МЕСТО РОЖДЕНИЯ")
					{
						return selectedTrop.PlatoonCommander.PlaceBirthday;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР НАЦИЯ")
					{
						return selectedTrop.PlatoonCommander.Nationality;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ДОМАШНИЙ НОМЕР")
					{
						return selectedTrop.PlatoonCommander.HomePhone;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР МОБИЛЬНЫЙНОМЕР")
					{
						return selectedTrop.PlatoonCommander.MobilePhone;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР АДРЕС ПРОЖИВАНИЯ")
					{
						return selectedTrop.PlatoonCommander.PlaceOfResidence;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР АДРЕС РЕГИСТРАЦИИ")
					{
						return selectedTrop.PlatoonCommander.PlaceOfRegestration;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ШКОЛА")
					{
						return selectedTrop.PlatoonCommander.School;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ДОЛЖНОСТЬ")
					{
						return selectedTrop.PlatoonCommander.Rank;
					}


					if (command.ToUpper() == "ВЗВОД КОМАНДИР ВЗВОД")
					{
						return selectedTrop.PlatoonCommander.Troop;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ИНИЦИАЛЫ")
					{
						return selectedTrop.PlatoonCommander.initials();
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР СЛУЖБА В ВС")
					{
						return selectedTrop.PlatoonCommander.Military;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР СЕМЕЙНЫЙ СТАТУС")
					{
						return selectedTrop.PlatoonCommander.FamiliStatys;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГРУППА КРОВИ")
					{
						return selectedTrop.PlatoonCommander.BloodType;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР СПЕЦИАЛЬНОСТЬ В ИНСТИТУТЕ")
					{
						return selectedTrop.PlatoonCommander.SpecInst;
					}
				}
			}

			if (summer != null) // ИЗМЕНИТЬ НА НЕ РАВНО
			{
				if (command.ToUpper() == "СБОРЫ НОМЕР ПРИКАЗА")
				{
					return summer.NumberofOrder;
				}

				if (command.ToUpper() == "СБОРЫ ДАТА ПРИКАЗА")
				{
					return summer.DateOfOrder;
				}

				if (command.ToUpper() == "СБОРЫ ДАТА НАЧАЛА")
				{
					return summer.DateBeginSbori;
				}

				if (command.ToUpper() == "СБОРЫ ДАТА ОКОНЧАНИЯ")
				{
					return summer.DateEndSbori;
				}

				if (command.ToUpper() == "СБОРЫ ДАТА ПРИСЯГИ")
				{
					return summer.DatePrisyaga;
				}

				if (command.ToUpper() == "СБОРЫ ДАТА ЭКЗАМЕНА")
				{
					return summer.DateExamen;
				}

				if (command.ToUpper() == "СБОРЫ НОМЕР ЧАСТИ")
				{
					return summer.NumberVK;
				}

				if (command.ToUpper() == "СБОРЫ МЕСТОНАХОЖДЕНИЕ ЧАСТИ")
				{
					return summer.LocationVK;
				}
			}
			if (adminInfo != null)
			{
				if (command.ToUpper() == "НАЧАЛЬНИК ВК ИНИЦИАЛЫ")
				{
					return adminInfo.HeadMilitaryDepartmentInitials;
				}

				if (command.ToUpper() == "НАЧАЛЬНИК ВК ЗВАНИЕ")
				{
					return adminInfo.HeadMilitaryDepartmentRank;
				}

				if (command.ToUpper() == "НАЧАЛЬНИК ВК ДОЛЖНОСТЬ")
				{
					return adminInfo.HeadMilitaryDepartmentPost;
				}

				if (command.ToUpper() == "ВОЕНКОМ ИНИЦИАЛЫ")
				{
					return adminInfo.WarriorInitials;
				}

				if (command.ToUpper() == "ВОЕНКОМ ЗВАНИЕ")
				{
					return adminInfo.WarriorRank;
				}

				if (command.ToUpper() == "ВОЕНКОМ ДОЛЖНОСТЬ")
				{
					return adminInfo.WarrioirPost;
				}
			}
			if (admins != null)
			{
				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ИМЯ")
				{
					return admins.Find(u => u.Rank == "Начальник штаба").FirstName;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ФАМИЛИЯ")
				{
					return admins.Find(u => u.Rank == "Начальник штаба").MiddleName;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ОТЧЕСТВО")
				{
					return admins.Find(u => u.Rank == "Начальник штаба").LastName;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Начальник штаба").Collness;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Начальник штаба").initials();
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ИМЯ")
				{
					return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").FirstName;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ФАМИЛИЯ")
				{
					return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").MiddleName;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ОТЧЕСТВО")
				{
					return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").LastName;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").initials();
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").Collness;
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ИМЯ")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").FirstName;
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ФАМИЛИЯ")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").MiddleName;
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ОТЧЕСТВО")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").LastName;
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").initials();
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").Collness;
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ТЫЛУ ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по тылу").initials();
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ТЫЛУ ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по тылу").Collness;
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВООРУЖЕНИЮ ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по вооружению").initials();
				}

				if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВООРУЖЕНИЮ ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по вооружению").Collness;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК МЕД ЧАСТИ ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Начальник медицинсокй части учебного сбора").initials();
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК МЕД ЧАСТИ ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Начальник медицинсокй части учебного сбора").Collness;
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР БАТАРЕИ ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Командир учебной батареи").initials();
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР БАТАРЕИ ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Командир учебной батареи").Collness;
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР 1ВЗВОДА")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР 2ВЗВОДА")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР 3ВЗВОДА")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР 4ВЗВОДА")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР 5ВЗВОДА")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР 6ВЗВОДА")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ СТАРШИНА ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Старшина учебного взвода").initials();
				}

				if (command.ToUpper() == "СБОРЫ СТАРШИНА ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Старшина учебного взвода").Collness;
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР ЧАСТИ ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Командир войсковой части").initials();
				}

				if (command.ToUpper() == "СБОРЫ КОМАНДИР ЧАСТИ ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Командир войсковой части").Collness;
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ЧАСТИ ИНИЦИАЛЫ")
				{
					return admins.Find(u => u.Rank == "Начальник штаба войсковой части").initials();
				}

				if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ЧАСТИ ЗВАНИЕ")
				{
					return admins.Find(u => u.Rank == "Начальник штаба войсковой части").Collness;
				}

				if (command.ToUpper() == "СБОРЫ ПРЕПОДАВАТЕЛЬ1")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ ПРЕПОДАВАТЕЛЬ2")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ ПРЕПОДАВАТЕЛЬ3")
				{
					return "1";
				}

				if (command.ToUpper() == "СБОРЫ ПРЕПОДАВАТЕЛЬ4")
				{
					return "1";
				}

			}

			return "НЕИЗВЕСТНАЯ КОМАНДА";
		}

		void changeTroop()
		{
			students = selectedTrop.ListStudents.ToList();
			selectedStudent = students.First();
			changeSelectedStudent();
		}

		void changeSelectedStudent()
		{
			selectedStudentMather = null;
			selectedStudentFather = null;
			if (selectedStudent.ListRelatives != null)
			{
				if (selectedStudent.ListRelatives.Count != 0)
				{
					selectedRelative = selectedStudent.ListRelatives.First();
				}
				foreach (Relative item in selectedStudent.ListRelatives)
				{
					if ((item.RelationDegree == "Мать" || item.RelationDegree == "Мачеха") && selectedStudentMather == null)
					{
						selectedStudentMather = item;
					}

					if ((item.RelationDegree == "Отец" || item.RelationDegree == "Отчим")
						&& selectedStudentFather == null)
					{
						selectedStudentFather = item;
					}
				}
			}
		}
	}
}
