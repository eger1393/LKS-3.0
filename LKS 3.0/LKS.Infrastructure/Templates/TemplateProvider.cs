using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LKS.Data.Models;
using LKS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Infrastructure.Templates
{
	public class TemplateProvider
	{

		List<Student> students; // текущие выбранные студенты(урощает работу с несколькими взводами)
		Student selectedStudent;    // выбранный студент
		Relative selectedStudentMather, //его мать
			selectedStudentFather,  //его отец
			selectedRelative;   //его дорственник
		Troop selectedTrop; //выбранный взвод
							//Summer summer; // информация о сборах
							//			   //Model.Department adminInfo; // Военком и нач кафедры
							//List<Admin> admins; // список администрации на сборах


		public byte[] CreateTemplate(string fileName, List<Student> Students = null, List<Prepod> prepods = null, List<Troop> troops = null)
		{
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
				this.students = troops.First().Students.Where(u => u.Status == StudentStatus.train || u.Status == StudentStatus.trainingFees).ToList();
				selectedTrop = troops.First();
			}
			else
			{
				this.students = Students;
			}
			selectedStudent = students.First(); // устанавливаем выбранного стуента


			var file = new MemoryStream();
			var f = File.Open(fileName, FileMode.Open);
			f?.CopyTo(file);
			f.Close();


			using (WordprocessingDocument doc = WordprocessingDocument.Open(file, true)) // открыли документ
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

								type = tempRow.Descendants<SdtElement>().ToList().Find(obj =>
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "СТУДЕНТЫ" ||
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "ВЗВОДА" ||
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "РОДСТВЕННИКИ")
								 .Descendants<SdtAlias>().First().Val.ToString().ToUpper(); // получили запись о том, кем заполнять таблицу

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
												for (int i = 0; i < selectedStudent.Relatives.Count; i++) // проходим по всем родственникам
												{
													selectedRelative = selectedStudent.Relatives[i];
													stringHandling(table, rowIndex, tempRow, i); // функция работы со строками
													rowIndex++; // перешли на след строку
												}
												break;
											}
										default:
											{
												throw new Exception("Ошибра в типе таблицы!");
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
									type = row.Descendants<SdtElement>().ToList().Find(obj =>
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "СТУДЕНТЫ" ||
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "ВЗВОДА" ||
									 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "РОДСТВЕННИКИ")
									 .Descendants<SdtAlias>().First().Val.ToString().ToUpper(); // получили запись о том, кем заполнять таблицу
								}
								//TODO Обработать исключения, если файнд вернул false
								catch (NullReferenceException) // 
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
														BookmarkToCommand(formattedText, i);
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
														BookmarkToCommand(formattedText, i);
													}
													table.AppendChild(tempRow);
												}
												row.Parent.RemoveChild(row);
												break;
											}
										case "РОДСТВЕННИКИ":
											{
												for (int i = 0; i < selectedStudent.Relatives.Count; i++) // проходим по всем родственникам
												{
													selectedRelative = selectedStudent.Relatives[i];
													TableRow tempRow = row.Clone() as TableRow;
													foreach (SdtElement formattedText in tempRow.Descendants<SdtElement>().ToList())
													{
														BookmarkToCommand(formattedText, i);
													}
													table.AppendChild(tempRow);
												}
												row.Parent.RemoveChild(row);
												break;
											}
										default:
											{
												throw new Exception("Ошибра в типе таблицы!");
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
					//if (valueCommand == "ФОТО" || valueCommand == "ВЗВОД ПРЕПОДАВАТЕЛЬ ПОДПИСЬ")
					//{
					//	string path; // путь к фото( в зависимости от команды либо к фото студента, либо к подписи препода
					//	if (valueCommand == "ФОТО")
					//	{
					//		path = selectedStudent.FullImagePath;
					//	}
					//	else
					//	{
					//		path = selectedTrop.Prepod.FullSignaturePath;
					//	}
					//	// скопипастил вставку картинок из мдсн
					//	MainDocumentPart mainPart = doc.MainDocumentPart;
					//	ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
					//	try
					//	{
					//		using (FileStream stream = new FileStream(path, FileMode.Open))
					//		{
					//			imagePart.FeedData(stream);
					//		}
					//		AddImageToBody(formattedText, mainPart.GetIdOfPart(imagePart));
					//	}
					//	catch (System.IO.FileNotFoundException ex)
					//	{
					//		System.Windows.MessageBox.Show(ex.Message + "/n ФОТО не найдено!");

					//	}
					//	catch (System.NotSupportedException ex)
					//	{

					//		System.Windows.MessageBox.Show(ex.Message + "/n Ошибка чтения ФОТО!");
					//		continue;
					//	}
					//	catch (Exception ex)
					//	{

					//		System.Windows.MessageBox.Show(ex.Message + "/n Ошибка чтения ФОТО!");
					//		continue;
					//	}
					//	continue;
					//}

					Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run; // скопировал первого потомка
					(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
					formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																			   // и заменил закладку обычным текстом
				}
				//doc.Save();
			}
			return file.ToArray();
		}
		private void AddImageToBody(SdtElement formattedText, string relationshipId)
		{
			// скопипастил код из МДСН 
			//var element =
			//	 new Drawing(
			//		 new DW.Inline(
			//			 new DW.Extent() { Cx = 990000L, Cy = 1100000L },
			//			 new DW.EffectExtent()
			//			 {
			//				 LeftEdge = 0L,
			//				 TopEdge = 0L,
			//				 RightEdge = 0L,
			//				 BottomEdge = 0L
			//			 },
			//			 new DW.DocProperties()
			//			 {
			//				 Id = (UInt32Value)1U,
			//				 Name = "Picture 1"
			//			 },
			//			 new DW.NonVisualGraphicFrameDrawingProperties(
			//				 new A.GraphicFrameLocks() { NoChangeAspect = true }),
			//			 new A.Graphic(
			//				 new A.GraphicData(
			//					 new PIC.Picture(
			//						 new PIC.NonVisualPictureProperties(
			//							 new PIC.NonVisualDrawingProperties()
			//							 {
			//								 Id = (UInt32Value)0U,
			//								 Name = "New Bitmap Image.jpg"
			//							 },
			//							 new PIC.NonVisualPictureDrawingProperties()),
			//						 new PIC.BlipFill(
			//							 new A.Blip(
			//								 new A.BlipExtensionList(
			//									 new A.BlipExtension()
			//									 {
			//										 Uri =
			//											"{28A0092B-C50C-407E-A947-70E740481C1C}"
			//									 })
			//							 )
			//							 {
			//								 Embed = relationshipId,
			//								 CompressionState =
			//								 A.BlipCompressionValues.Print
			//							 },
			//							 new A.Stretch(
			//								 new A.FillRectangle())),
			//						 new PIC.ShapeProperties(
			//							 new A.Transform2D(
			//								 new A.Offset() { X = 0L, Y = 0L },
			//								 new A.Extents() { Cx = 990000L, Cy = 1100000L }),
			//							 new A.PresetGeometry(
			//								 new A.AdjustValueList()
			//							 )
			//							 { Preset = A.ShapeTypeValues.Rectangle }))
			//				 )
			//				 { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
			//		 )
			//		 {
			//			 DistanceFromTop = (UInt32Value)0U,
			//			 DistanceFromBottom = (UInt32Value)0U,
			//			 DistanceFromLeft = (UInt32Value)0U,
			//			 DistanceFromRight = (UInt32Value)0U,
			//			 EditId = "50D07946"
			//		 });

			//// Append the reference to body, the element should be in a Run.
			//formattedText.Parent.ReplaceChild(new Run(element), formattedText);
		}

		/// <summary>
		/// Замена закладки на команду
		/// </summary>
		/// <param name="formattedText">Закладка</param>
		/// <param name="i">Номер строки в таблице(нужно для команды №)</param>
		private void BookmarkToCommand(SdtElement formattedText, int i)
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

			// В закладке всегда есть элемент Run (он создается вордом даже в том случае если там нет текста
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
			try
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
							BookmarkToCommand(formattedText, i);

						}
					}
				}
			}
			catch (IndexOutOfRangeException)
			{
				throw new Exception("Cлишком много студентов во взводе, добавьте пустые строки в шаблон журнала!");
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new Exception("Cлишком много студентов во взводе, добавьте пустые строки в шаблон журнала!");
			}
		}

		private string toAssessment(int num)
		{
			string[] assessmentEnum = { // Перевод оценок из цифр в обозначения
			"неудовлетв",
			"удовлетв",
			"хорошо",
			"отлично"
			};
			if (num >= 2 && num <= 5)
				return assessmentEnum[num - 2];
			else
				return num.ToString();
		}
		private string findCommand(string command)
		{
			if (command.ToUpper() == "НОВАЯ СТРОКА")
			{
				return "";
			}

			if (command.ToUpper() == "СЛЕДУЮЩИЙ СТУДЕНТ")
			{
				selectedStudent = students[1]; // костыль
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

			if (command.ToUpper() == "ИМЯББ")
			{
				return selectedStudent.FirstName.ToUpper();
			}

			if (command.ToUpper() == "ФАМИЛИЯББ")
			{
				return selectedStudent.MiddleName.ToUpper();
			}

			if (command.ToUpper() == "ОТЧЕСТВОББ")
			{
				return selectedStudent.LastName.ToUpper();
			}

			if (command.ToUpper() == "ФАКУЛЬТЕТ")
			{
				return selectedStudent.Faculty;
			}

			if (command.ToUpper() == "КУРС")
			{
				return selectedStudent.Kurs.ToString();
			}

			if (command.ToUpper() == "ГРУППА")
			{
				return selectedStudent.InstGroup;
			}

			//if (command.ToUpper() == "ВУС")
			//{
			//	return selectedStudent.VUS;
			//}

			if (command.ToUpper() == "ВУС (ПОЛНОЕ НАИМЕНОВАНИЕ)")
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
				return selectedStudent.Position.ToString();
			}


			if (command.ToUpper() == "ВЗВОД")
			{
				return selectedStudent.Troop?.NumberTroop ?? "нет";
			}

			if (command.ToUpper() == "ИНИЦИАЛЫ")
			{
				return selectedStudent.Initials;
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

			if (command.ToUpper() == "ПРОТОКОЛ 1 ТЕОРЕТИЧЕСКИЕ ЗНАНИЯ")
			{
				return toAssessment(selectedStudent.AssessmentProtocolOneTheory);
			}

			if (command.ToUpper() == "ПРОТОКОЛ 1 ПРАКТИЧЕСКИЕ УМЕНИЯ")
			{
				return toAssessment(selectedStudent.AssessmentProtocolOnePractice);
			}

			if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА")
			{
				return toAssessment(selectedStudent.AssessmentProtocolOneFinal);
			}

			if (command.ToUpper() == "ХАРАКТЕРИСТИКА ВОЕННО-ТЕХНИЧЕСКАЯ ПОДГОТОВКА")
			{
				return toAssessment(selectedStudent.AssessmentCharacteristicMilitaryTechnicalTraining);
			}

			if (command.ToUpper() == "ХАРАКТЕРИСТИКА ТАКТИКО-СПЕЦИАЛЬНАЯ ПОДГОТОВКА")
			{
				return toAssessment(selectedStudent.AssessmentCharacteristicTacticalSpecialTraining);
			}

			if (command.ToUpper() == "ХАРАКТЕРИСТИКА ВОЕННО-СПЕЦИАЛЬНАЯ ПОДГОТОВКА")
			{
				return toAssessment(selectedStudent.AssessmentCharacteristicMilitarySpeialTraining);
			}

			if (command.ToUpper() == "ХАРАКТЕРИСТИКА ОБЩАЯ ОЦЕНКА")
			{
				return toAssessment(selectedStudent.AssessmentCharacteristicFinal);
			}

			////
			////БЛОК РОДСТВЕННИКОВ
			////
			//if (selectedRelative != null)
			//{
			//	if (command.ToUpper() == "РОД ИМЯ")
			//	{
			//		return selectedRelative.FirstName;
			//	}

			//	if (command.ToUpper() == "РОД ФАМИЛИЯ")
			//	{
			//		return selectedRelative.MiddleName;
			//	}

			//	if (command.ToUpper() == "РОД ОТЧЕСТВО")
			//	{
			//		return selectedRelative.LastName;
			//	}

			//	if (command.ToUpper() == "РОД ДЕВИЧЬЯ ФАМИЛИЯ")
			//	{
			//		return selectedRelative.MaidenName;
			//	}

			//	if (command.ToUpper() == "РОД ДЕНЬ РОЖДЕНИЯ")
			//	{
			//		return selectedRelative.Birthday;
			//	}

			//	if (command.ToUpper() == "РОД АДРЕС РЕГЕРИСТРАЦИИ")
			//	{
			//		return selectedRelative.PlaceOfRegestration;
			//	}

			//	if (command.ToUpper() == "РОД АДРЕС ПРОЖИВАНИЯ")
			//	{
			//		return selectedRelative.PlaceOfResidence;
			//	}

			//	if (command.ToUpper() == "РОД МОБИЛЬНЫЙ НОМЕР")
			//	{
			//		return selectedRelative.MobilePhone;
			//	}

			//	if (command.ToUpper() == "РОД СТЕПЕНЬ РОДСТВА")
			//	{
			//		return selectedRelative.RelationDegree;
			//	}

			//	if (command.ToUpper() == "РОД СОСТОЯНИЕ ЗДОРОВЬЯ")
			//	{
			//		return selectedRelative.HealthStatus;
			//	}

			//	if (command.ToUpper() == "РОД ИНИЦИАЛЫ")
			//	{
			//		return selectedRelative.Initials;
			//	}
			//}
			////Мать
			//if (selectedStudentMather != null)
			//{
			//	if (command.ToUpper() == "МАТЬ ИМЯ")
			//	{
			//		return selectedStudentMather.FirstName;
			//	}

			//	if (command.ToUpper() == "МАТЬ ФАМИЛИЯ")
			//	{
			//		return selectedStudentMather.MiddleName;
			//	}

			//	if (command.ToUpper() == "МАТЬ ОТЧЕСТВО")
			//	{
			//		return selectedStudentMather.LastName;
			//	}

			//	if (command.ToUpper() == "МАТЬ ДЕВИЧЬЯ ФАМИЛИЯ")
			//	{
			//		return selectedStudentMather.MaidenName;
			//	}

			//	if (command.ToUpper() == "МАТЬ ДЕНЬ РОЖДЕНИЯ")
			//	{
			//		return selectedStudentMather.Birthday;
			//	}

			//	if (command.ToUpper() == "МАТЬ АДРЕС РЕГИСТРАЦИИ")
			//	{
			//		return selectedStudentMather.PlaceOfRegestration;
			//	}

			//	if (command.ToUpper() == "МАТЬ АДРЕС ПРОЖИВАНИЯ")
			//	{
			//		return selectedStudentMather.PlaceOfResidence;
			//	}

			//	if (command.ToUpper() == "МАТЬ МОБИЛЬНЫЙ НОМЕР")
			//	{
			//		return selectedStudentMather.MobilePhone;
			//	}

			//	if (command.ToUpper() == "МАТЬ СТЕПЕНЬ РОДСТВА")
			//	{
			//		return selectedStudentMather.RelationDegree;
			//	}

			//	if (command.ToUpper() == "МАТЬ СОСТОЯНИЕ ЗДОРОВЬЯ")
			//	{
			//		return selectedStudentMather.HealthStatus;
			//	}

			//	if (command.ToUpper() == "МАТЬ ИНИЦИАЛЫ")
			//	{
			//		return selectedStudentMather.Initials;
			//	}
			//}
			//// ОТЕЦ(ОТЧИМ)
			//if (selectedStudentFather != null)
			//{
			//	if (command.ToUpper() == "ОТЕЦ ИМЯ")
			//	{
			//		return selectedStudentFather.FirstName;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ ФАМИЛИЯ")
			//	{
			//		return selectedStudentFather.MiddleName;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ ОТЧЕСТВО")
			//	{
			//		return selectedStudentFather.LastName;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ ДЕВИЧЬЯ ФАМИЛИЯ")
			//	{
			//		return selectedStudentFather.MaidenName;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ ДЕНЬ РОЖДЕНИЯ")
			//	{
			//		return selectedStudentFather.Birthday;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ АДРЕС РЕГИСТРАЦИИ")
			//	{
			//		return selectedStudentFather.PlaceOfRegestration;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ АДРЕС ПРОЖИВАНИЯ")
			//	{
			//		return selectedStudentFather.PlaceOfResidence;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ МОБИЛЬНЫЙ НОМЕР")
			//	{
			//		return selectedStudentFather.MobilePhone;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ СТЕПЕНЬ РОДСТВА")
			//	{
			//		return selectedStudentFather.RelationDegree;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ СОСТОЯНИЕ ЗДОРОВЬЯ")
			//	{
			//		return selectedStudentFather.HealthStatus;
			//	}

			//	if (command.ToUpper() == "ОТЕЦ ИНИЦИАЛЫ")
			//	{
			//		return selectedStudentFather.Initials;
			//	}
			//}

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
					return selectedTrop.ArrivalDay.ToString(); //TODO
				}

				if (command.ToUpper() == "ВЗВОД ВУС")
				{
					return "123"; // TODO
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 5")
				{
					return selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 5) != 0 ?
						selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 5).ToString() : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 5 %")
				{
					return selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 5) != 0 ?
						((double)((selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 5))) / selectedTrop.Students.Count * 100).ToString("#.#") : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 4")
				{
					return selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 4) != 0 ?
						selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 4).ToString() : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 4 %")
				{
					return selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 4) != 0 ?
						((double)((selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 4))) / selectedTrop.Students.Count * 100).ToString("#.#") : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 3")
				{
					return selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 3) != 0 ?
						selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 3).ToString() : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 3 %")
				{
					return selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 3) != 0 ?
						((double)((selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal == 3))) / selectedTrop.Students.Count * 100).ToString("#.#") : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 2")
				{
					return selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal <= 2) != 0 ?
						selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal <= 2).ToString() : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 2 %")
				{
					return selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal <= 2) != 0 ?
						((double)((selectedTrop.Students.Count(u => u.AssessmentProtocolOneFinal <= 2))) / selectedTrop.Students.Count * 100).ToString("#.#") : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ВСЕГО СДАЛО")
				{
					return selectedTrop.Students.Count(u => (u.AssessmentProtocolOneFinal <= 5 && u.AssessmentProtocolOneFinal > 2)).ToString();
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 СРЕДНИЙ БАЛЛ")
				{
					return (Convert.ToDouble(selectedTrop.Students.TakeWhile(u => (u.AssessmentProtocolOneFinal <= 5 && u.AssessmentProtocolOneFinal >= 2)).Sum(u => u.AssessmentProtocolOneFinal)) /
						 selectedTrop.Students.Count(u => (u.AssessmentProtocolOneFinal <= 5 && u.AssessmentProtocolOneFinal >= 2))).ToString("#.#");
				}

				if (selectedTrop.Prepod != null)
				{
					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ИМЯ")
					{
						return selectedTrop.Prepod.FirstName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ФАМИЛИЯ")
					{
						return selectedTrop.Prepod.MiddleName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ОТЧЕСТВО")
					{
						return selectedTrop.Prepod.LastName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ЗВАНИЕ")
					{
						return selectedTrop.Prepod.Coolness.ToString(); // TODO
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ДОЛЖНОСТЬ")
					{
						return selectedTrop.Prepod.PrepodRank;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ИНИЦИАЛЫ")
					{
						return selectedTrop.Prepod.Initials;
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
						return selectedTrop.PlatoonCommander.InstGroup;
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
						return selectedTrop.PlatoonCommander.Position.ToString(); // TODO
					}


					if (command.ToUpper() == "ВЗВОД КОМАНДИР ВЗВОД")
					{
						return selectedTrop.NumberTroop;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ИНИЦИАЛЫ")
					{
						return selectedTrop.PlatoonCommander.Initials;
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

			//if (summer != null)
			//{
			//	if (command.ToUpper() == "СБОРЫ НОМЕР ПРИКАЗА")
			//	{
			//		return summer.NumberofOrder;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ДАТА ПРИКАЗА")
			//	{
			//		return summer.DateOfOrder;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ДАТА НАЧАЛА")
			//	{
			//		return summer.DateBeginSbori;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ДАТА ОКОНЧАНИЯ")
			//	{
			//		return summer.DateEndSbori;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ДАТА ПРИСЯГИ")
			//	{
			//		return summer.DatePrisyaga;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ДАТА ЭКЗАМЕНА")
			//	{
			//		return summer.DateExamen;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НОМЕР ЧАСТИ")
			//	{
			//		return summer.NumberVK;
			//	}

			//	if (command.ToUpper() == "СБОРЫ МЕСТОНАХОЖДЕНИЕ ЧАСТИ")
			//	{
			//		return summer.LocationVK;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ДЛИТЕЛЬНОСТЬ")
			//	{
			//		return (Convert.ToDateTime(summer.DateBeginSbori) - Convert.ToDateTime(summer.DateEndSbori)).ToString();
			//	}

			//	if (command.ToUpper() == "СБОРЫ ТЕКСТ ПРИКАЗА")
			//	{
			//		return summer.TittleOrder;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЗВАНИЕ БМ")
			//	{
			//		return summer.Bmp_kr;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЗВАНИЕ БМ ПОЛНОЕ")
			//	{
			//		return summer.Bmp_full;
			//	}


			//}
			//if (admins != null)
			//{
			//	if (command.ToUpper() == "НАЧАЛЬНИК ВК ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник факультета военного обучения").Initials;
			//	}

			//	if (command.ToUpper() == "НАЧАЛЬНИК ВК ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник факультета военного обучения").Collness;
			//	}

			//	if (command.ToUpper() == "НАЧАЛЬНИК ВК ДОЛЖНОСТЬ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник факультета военного обучения").Rank;
			//	}

			//	if (command.ToUpper() == "ВОЕНКОМ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Военный комиссар").Initials;
			//	}

			//	if (command.ToUpper() == "ВОЕНКОМ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Военный комиссар").Collness;
			//	}

			//	if (command.ToUpper() == "ВОЕНКОМ ДОЛЖНОСТЬ")
			//	{
			//		return admins.Find(u => u.Rank == "Военный комиссар").Rank;
			//	}
			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ИМЯ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник штаба").FirstName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ФАМИЛИЯ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник штаба").MiddleName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ОТЧЕСТВО")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник штаба").LastName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник штаба").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник штаба").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ИМЯ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").FirstName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ФАМИЛИЯ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").MiddleName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ОТЧЕСТВО")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").LastName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ЧАСТИ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник учебной части учебного сбора").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ИМЯ")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").FirstName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ФАМИЛИЯ")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").MiddleName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ОТЧЕСТВО")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").LastName;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВОСПИТАТЕЛЬНОЙ РАБОТЕ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по воспитательной работе").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ТЫЛУ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по тылу").Initials;
			//	}
			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ТЫЛУ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по тылу").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВООРУЖЕНИЮ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по вооружению").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЗАМ ПО ВООРУЖЕНИЮ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Заместитель начальника учебного сбора по вооружению").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК МЕД ЧАСТИ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник медицинсокй части учебного сбора").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК МЕД ЧАСТИ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник медицинсокй части учебного сбора").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР БАТАРЕИ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Командир учебной батареи").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР БАТАРЕИ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Командир учебной батареи").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР 1ВЗВОДА")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР 2ВЗВОДА")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР 3ВЗВОДА")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР 4ВЗВОДА")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР 5ВЗВОДА")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР 6ВЗВОДА")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ СТАРШИНА ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Старшина учебного взвода").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ СТАРШИНА ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Старшина учебного взвода").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР ЧАСТИ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Командир войсковой части").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ КОМАНДИР ЧАСТИ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Командир войсковой части").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ЧАСТИ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник штаба войсковой части").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ НАЧАЛЬНИК ШТАБА ЧАСТИ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Начальник штаба войсковой части").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ПРЕДСЕДАТЕЛЬ КОМИССИИ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Председатель государственной выпускной экзаменационной комиссии").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ПРЕДСЕДАТЕЛЬ КОМИССИИ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Председатель государственной выпускной экзаменационной комиссии").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ СЕКРЕТАРЬ КОМИССИИ ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Секретарь государственной выпускной экзаменационной комиссии").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ СЕКРЕТАРЬ КОМИССИИ ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Секретарь государственной выпускной экзаменационной комиссии").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 1 ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 1").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 1 ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 1").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 2 ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 2").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 2 ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 2").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 3 ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 3").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 3 ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 3").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 4 ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 4").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 4 ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 4").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 5 ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 5").Initials;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ЧЛЕН КОМИССИИ 5 ЗВАНИЕ")
			//	{
			//		return admins.Find(u => u.Rank == "Член комиссии 5").Collness;
			//	}

			//	if (command.ToUpper() == "СБОРЫ ПРЕПОДАВАТЕЛЬ1")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ ПРЕПОДАВАТЕЛЬ2")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ ПРЕПОДАВАТЕЛЬ3")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "СБОРЫ ПРЕПОДАВАТЕЛЬ4")
			//	{
			//		return "1";
			//	}

			//	if (command.ToUpper() == "РЕКТОР ИНИЦИАЛЫ")
			//	{
			//		return admins.Find(u => u.Rank == "Ректор МАИ НИУ").Initials;
			//	}

			//}

			return "НЕИЗВЕСТНАЯ КОМАНДА";
		}

		void changeTroop()
		{
			students = selectedTrop.Students.ToList();
			selectedStudent = students.First();
			changeSelectedStudent();
		}

		void changeSelectedStudent()
		{
			selectedStudentMather = null;
			selectedStudentFather = null;
			if (selectedStudent.Relatives != null)
			{
				if (selectedStudent.Relatives.Count != 0)
				{
					selectedRelative = selectedStudent.Relatives.First();
				}
				foreach (Relative item in selectedStudent.Relatives)
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
