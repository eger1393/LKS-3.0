using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Models;
using LKS.Data.Models.Enums;

// ReSharper disable StringLiteralTypo

namespace LKS.Infrastructure.Templates
{
	public class TemplateProvider
	{
        private readonly AsyncLock _mutex = new AsyncLock();
        private List<Student> _students; // текущие выбранные студенты(урощает работу с несколькими взводами)
        private Student _selectedStudent;    // выбранный студент

        private Relative _selectedStudentMather, //его мать
			_selectedStudentFather,  //его отец
			_selectedRelative;   //его родственник

        private Troop _selectedTroop; //выбранный взвод
							//Summer summer; // информация о сборах
							//			   //Model.Department adminInfo; // Военком и нач кафедры
							//List<Admin> admins; // список администрации на сборах


		public async Task<byte[]> CopyFile(string fileName)
		{
			var file = new MemoryStream();
			using (var f = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				f?.CopyTo(file);
			}
			return file.ToArray();
		}

		public async Task<byte[]> CreateTemplate(string fileName, List<Student> students = null, List<Prepod> prepods = null, List<Troop> troops = null)
		{
			if (students == null)
			{
				students = new List<Student>();
			}

			if (troops == null)
			{
				troops = new List<Troop>();
			}

			if (students.Count == 0 && troops.Count != 0)
			{
				this._students = troops.First().Students.Where(u => u.Status == StudentStatus.train || u.Status == StudentStatus.trainingFees).ToList();
				_selectedTroop = troops.First();
			}
			else
			{
				this._students = students;
			}

			_selectedStudent = _students?.First(); // устанавливаем выбранного стуента


			//using (
			var file = new MemoryStream();
			//using (await mutex.LockAsync())
			//{
			using (var f = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				f?.CopyTo(file);
			}
			//}

			using (var doc = WordprocessingDocument.Open(file, true)) // открыли документ
			{
				foreach (var table
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
								//string type = null;

								string type = tempRow.Descendants<SdtElement>().ToList().Find(obj =>
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
												for (int i = 0; i < _students.Count; i++) // проходим по всем студентам
												{
													_selectedStudent = _students[i];
													ChangeSelectedStudent();
													StringHandling(table, rowIndex, tempRow, i); // функция работы со строками
													rowIndex++; // перешли на след строку
												}
												break;
											}
										case "ВЗВОДА":
											{
												for (int i = 0; i < troops.Count; i++) // проходим по всем взводам
												{
													_selectedTroop = troops[i];
													ChangeTroop();
													StringHandling(table, rowIndex, tempRow, i); // функция работы со строками
													rowIndex++; // перешли на след строку
												}
												break;
											}
										case "РОДСТВЕННИКИ":
											{
												for (int i = 0; i < _selectedStudent?.Relatives?.Count; i++) // проходим по всем родственникам
												{
													_selectedRelative = _selectedStudent.Relatives[i];
													StringHandling(table, rowIndex, tempRow, i); // функция работы со строками
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

                                string type;
								try
								{
									type = row.Descendants<SdtElement>().ToList().Find(obj =>
									 obj.Descendants<SdtAlias>()?.First()?.Val?.ToString().ToUpper() == "СТУДЕНТЫ" ||
									 obj.Descendants<SdtAlias>()?.First()?.Val?.ToString().ToUpper() == "ВЗВОДА" ||
									 obj.Descendants<SdtAlias>()?.First()?.Val?.ToString().ToUpper() == "РОДСТВЕННИКИ")
									 ?.Descendants<SdtAlias>()?.First()?.Val?.ToString()?.ToUpper(); // получили запись о том, кем заполнять таблицу
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
												for (int i = 0; i < _students.Count; i++) // проходим по всем студентам
												{
													_selectedStudent = _students[i];
													ChangeSelectedStudent();
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
													_selectedTroop = troops[i];
													ChangeTroop();
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
												for (int i = 0; i < _selectedStudent.Relatives.Count; i++) // проходим по всем родственникам
												{
													_selectedRelative = _selectedStudent.Relatives[i];
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
												throw new Exception("Ошибка в типе таблицы!");
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
				_selectedStudent = _students[0];
				ChangeSelectedStudent();
				foreach (SdtElement formattedText in doc.MainDocumentPart.Document.Body.Descendants<SdtElement>().ToList())
				{
					string valueCommand = FindCommand(formattedText.SdtProperties.GetFirstChild<SdtAlias>().Val);
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
			////}
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
				valueCommand = FindCommand(formattedText.Descendants<SdtAlias>().First().Val);
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
		private void StringHandling(Table table, int rowIndex, TableRow tempRow, int i)
		{
			try
			{
				// перечеслитель для перебора ячеек в строке которая назодится в таблице(изначально он стоит ДО нулевой позиции
				IEnumerator<TableCell> ecell = table.Elements<TableRow>().ToList()[rowIndex].
												Descendants<TableCell>().ToList().GetEnumerator();
				foreach (TableCell cell in tempRow.Descendants<TableCell>().ToList()) // проходим по всем ячейкам во временной строке
				{
					ecell.MoveNext();// передвинули перечеслитель
					if (cell.Descendants<SdtElement>().Any()) // проверка на наличие закладок в ячейке
					{
						// ссылка на копиию, которой мы заменим текущую выбранную ячейку в строке
						TableCell tempCell = cell.Clone() as TableCell;
						ecell.Current.Parent.ReplaceChild(tempCell, ecell.Current); // замена
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

		private static string ToAssessment(int num)
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
		private string FindCommand(string command)
		{
			if (command.ToUpper() == "НОВАЯ СТРОКА")
			{
				return "";
			}

			if (command.ToUpper() == "СЛЕДУЮЩИЙ СТУДЕНТ")
			{
				_selectedStudent = _students[1]; // костыль
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
				return _selectedStudent.FirstName;
			}

			if (command.ToUpper() == "ФАМИЛИЯ")
			{
				return _selectedStudent.MiddleName;
			}

			if (command.ToUpper() == "ОТЧЕСТВО")
			{
				return _selectedStudent.LastName;
			}

			if (command.ToUpper() == "ИМЯББ")
			{
				return _selectedStudent.FirstName.ToUpper();
			}

			if (command.ToUpper() == "ФАМИЛИЯББ")
			{
				return _selectedStudent.MiddleName.ToUpper();
			}

			if (command.ToUpper() == "ОТЧЕСТВОББ")
			{
				return _selectedStudent.LastName.ToUpper();
			}

			if (command.ToUpper() == "ФАКУЛЬТЕТ")
			{
				return _selectedStudent.Faculty;
			}

			if (command.ToUpper() == "КУРС")
			{
				return _selectedStudent.Kurs.ToString();
			}

			if (command.ToUpper() == "ГРУППА")
			{
				return _selectedStudent.InstGroup;
			}

			//if (command.ToUpper() == "ВУС")
			//{
			//	return selectedStudent.VUS;
			//}

			if (command.ToUpper() == "ВУС (ПОЛНОЕ НАИМЕНОВАНИЕ)")
			{
				return _selectedStudent.SpecialityName;
			}

			if (command.ToUpper() == "УСЛОВИЯ ОБУЧЕНИЯ")
			{
				return _selectedStudent.ConditionsOfEducation;
			}

			if (command.ToUpper() == "СРЕДНИЙ БАЛЛ")
			{
				return _selectedStudent.AvarageScore;
			}

			if (command.ToUpper() == "ГОД ПОСТУПЛЕНИЯ В МАИ")
			{
				return _selectedStudent.YearOfAddMAI;
			}

			if (command.ToUpper() == "ГОД ОКОНЧАНИЯ МАИ")
			{
				return _selectedStudent.YearOfEndMAI;
			}

			if (command.ToUpper() == "ГОД ПОСТУПЛЕНИЯ НА КАФЕДРУ")
			{
				return _selectedStudent.YearOfAddVK;
			}

			if (command.ToUpper() == "ГОД ОКОНЧАНИЯ КАФЕДРЫ")
			{
				return _selectedStudent.YearOfEndVK;
			}

			if (command.ToUpper() == "НОМЕР ПРИКАЗА")
			{
				return _selectedStudent.NumberOfOrder;
			}

			if (command.ToUpper() == "ДАТА ПРИКАЗА")
			{
				return _selectedStudent.DateOfOrder;
			}

			if (command.ToUpper() == "ВОЕНКОМАТ")
			{
				return _selectedStudent.Rectal;
			}

			if (command.ToUpper() == "ДЕНЬ РОЖДЕНИЯ")
			{
				return _selectedStudent.Birthday;
			}

			if (command.ToUpper() == "МЕСТО РОЖДЕНИЯ")
			{
				return _selectedStudent.PlaceBirthday;
			}

			if (command.ToUpper() == "НАЦИЯ")
			{
				return _selectedStudent.Nationality;
			}

			if (command.ToUpper() == "ДОМАШНИЙ НОМЕР")
			{
				return _selectedStudent.HomePhone;
			}

			if (command.ToUpper() == "МОБИЛЬНЫЙ НОМЕР")
			{
				return _selectedStudent.MobilePhone;
			}

			if (command.ToUpper() == "АДРЕС ПРОЖИВАНИЯ")
			{
				return _selectedStudent.PlaceOfResidence;
			}

			if (command.ToUpper() == "АДРЕС РЕГИСТРАЦИИ")
			{
				return _selectedStudent.PlaceOfRegestration;
			}

			if (command.ToUpper() == "ШКОЛА")
			{
				return _selectedStudent.School;
			}

			if (command.ToUpper() == "ДОЛЖНОСТЬ")
			{
				return _selectedStudent.GetPositionValue;
			}


			if (command.ToUpper() == "ВЗВОД")
			{
				return _selectedStudent.Troop?.NumberTroop ?? "нет";
			}

			if (command.ToUpper() == "ИНИЦИАЛЫ")
			{
				return _selectedStudent.Initials;
			}

			if (command.ToUpper() == "СЛУЖБА В ВС")
			{
				return _selectedStudent.Military;
			}

			if (command.ToUpper() == "СЕМЕЙНЫЙ СТАТУС")
			{
				return _selectedStudent.FamiliStatys;
			}

			if (command.ToUpper() == "ГРУППА КРОВИ")
			{
				return _selectedStudent.BloodType;
			}

			if (command.ToUpper() == "СПЕЦИАЛЬНОСТЬ В ИНСТИТУТЕ")
			{
				return _selectedStudent.SpecInst;
			}

			if (command.ToUpper() == "ПРОТОКОЛ 1 ТЕОРЕТИЧЕСКИЕ ЗНАНИЯ")
			{
				return ToAssessment(_selectedStudent.AssessmentProtocolOneTheory);
			}

			if (command.ToUpper() == "ПРОТОКОЛ 1 ПРАКТИЧЕСКИЕ УМЕНИЯ")
			{
				return ToAssessment(_selectedStudent.AssessmentProtocolOnePractice);
			}

			if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА")
			{
				return ToAssessment(_selectedStudent.AssessmentProtocolOneFinal);
			}

			if (command.ToUpper() == "ХАРАКТЕРИСТИКА ВОЕННО-ТЕХНИЧЕСКАЯ ПОДГОТОВКА")
			{
				return ToAssessment(_selectedStudent.AssessmentCharacteristicMilitaryTechnicalTraining);
			}

			if (command.ToUpper() == "ХАРАКТЕРИСТИКА ТАКТИКО-СПЕЦИАЛЬНАЯ ПОДГОТОВКА")
			{
				return ToAssessment(_selectedStudent.AssessmentCharacteristicTacticalSpecialTraining);
			}

			if (command.ToUpper() == "ХАРАКТЕРИСТИКА ВОЕННО-СПЕЦИАЛЬНАЯ ПОДГОТОВКА")
			{
				return ToAssessment(_selectedStudent.AssessmentCharacteristicMilitarySpeialTraining);
			}

			if (command.ToUpper() == "ХАРАКТЕРИСТИКА ОБЩАЯ ОЦЕНКА")
			{
				return ToAssessment(_selectedStudent.AssessmentCharacteristicFinal);
			}

			////
			////БЛОК РОДСТВЕННИКОВ
			////
			if (_selectedRelative != null)
			{
				if (command.ToUpper() == "РОД ИМЯ")
				{
					return _selectedRelative.FirstName;
				}

				if (command.ToUpper() == "РОД ФАМИЛИЯ")
				{
					return _selectedRelative.MiddleName;
				}

				if (command.ToUpper() == "РОД ОТЧЕСТВО")
				{
					return _selectedRelative.LastName;
				}

				if (command.ToUpper() == "РОД ДЕВИЧЬЯ ФАМИЛИЯ")
				{
					return _selectedRelative.MaidenName;
				}

				if (command.ToUpper() == "РОД ДЕНЬ РОЖДЕНИЯ")
				{
					return _selectedRelative.Birthday;
				}

				if (command.ToUpper() == "РОД АДРЕС РЕГЕРИСТРАЦИИ")
				{
					return _selectedRelative.PlaceOfRegestration;
				}

				if (command.ToUpper() == "РОД АДРЕС ПРОЖИВАНИЯ")
				{
					return _selectedRelative.PlaceOfResidence;
				}

				if (command.ToUpper() == "РОД МОБИЛЬНЫЙ НОМЕР")
				{
					return _selectedRelative.MobilePhone;
				}

				if (command.ToUpper() == "РОД СТЕПЕНЬ РОДСТВА")
				{
					return _selectedRelative.RelationDegree;
				}

				if (command.ToUpper() == "РОД СОСТОЯНИЕ ЗДОРОВЬЯ")
				{
					return _selectedRelative.HealthStatus;
				}

				if (command.ToUpper() == "РОД ИНИЦИАЛЫ")
				{
					return _selectedRelative.Initials();
				}
			}
			//Мать
			if (_selectedStudentMather != null)
			{
				if (command.ToUpper() == "МАТЬ ИМЯ")
				{
					return _selectedStudentMather.FirstName;
				}

				if (command.ToUpper() == "МАТЬ ФАМИЛИЯ")
				{
					return _selectedStudentMather.MiddleName;
				}

				if (command.ToUpper() == "МАТЬ ОТЧЕСТВО")
				{
					return _selectedStudentMather.LastName;
				}

				if (command.ToUpper() == "МАТЬ ДЕВИЧЬЯ ФАМИЛИЯ")
				{
					return _selectedStudentMather.MaidenName;
				}

				if (command.ToUpper() == "МАТЬ ДЕНЬ РОЖДЕНИЯ")
				{
					return _selectedStudentMather.Birthday;
				}

				if (command.ToUpper() == "МАТЬ АДРЕС РЕГИСТРАЦИИ")
				{
					return _selectedStudentMather.PlaceOfRegestration;
				}

				if (command.ToUpper() == "МАТЬ АДРЕС ПРОЖИВАНИЯ")
				{
					return _selectedStudentMather.PlaceOfResidence;
				}

				if (command.ToUpper() == "МАТЬ МОБИЛЬНЫЙ НОМЕР")
				{
					return _selectedStudentMather.MobilePhone;
				}

				if (command.ToUpper() == "МАТЬ СТЕПЕНЬ РОДСТВА")
				{
					return _selectedStudentMather.RelationDegree;
				}

				if (command.ToUpper() == "МАТЬ СОСТОЯНИЕ ЗДОРОВЬЯ")
				{
					return _selectedStudentMather.HealthStatus;
				}

				if (command.ToUpper() == "МАТЬ ИНИЦИАЛЫ")
				{
					return _selectedStudentMather.Initials();
				}
			}
			// ОТЕЦ(ОТЧИМ)
			if (_selectedStudentFather != null)
			{
				if (command.ToUpper() == "ОТЕЦ ИМЯ")
				{
					return _selectedStudentFather.FirstName;
				}

				if (command.ToUpper() == "ОТЕЦ ФАМИЛИЯ")
				{
					return _selectedStudentFather.MiddleName;
				}

				if (command.ToUpper() == "ОТЕЦ ОТЧЕСТВО")
				{
					return _selectedStudentFather.LastName;
				}

				if (command.ToUpper() == "ОТЕЦ ДЕВИЧЬЯ ФАМИЛИЯ")
				{
					return _selectedStudentFather.MaidenName;
				}

				if (command.ToUpper() == "ОТЕЦ ДЕНЬ РОЖДЕНИЯ")
				{
					return _selectedStudentFather.Birthday;
				}

				if (command.ToUpper() == "ОТЕЦ АДРЕС РЕГИСТРАЦИИ")
				{
					return _selectedStudentFather.PlaceOfRegestration;
				}

				if (command.ToUpper() == "ОТЕЦ АДРЕС ПРОЖИВАНИЯ")
				{
					return _selectedStudentFather.PlaceOfResidence;
				}

				if (command.ToUpper() == "ОТЕЦ МОБИЛЬНЫЙ НОМЕР")
				{
					return _selectedStudentFather.MobilePhone;
				}

				if (command.ToUpper() == "ОТЕЦ СТЕПЕНЬ РОДСТВА")
				{
					return _selectedStudentFather.RelationDegree;
				}

				if (command.ToUpper() == "ОТЕЦ СОСТОЯНИЕ ЗДОРОВЬЯ")
				{
					return _selectedStudentFather.HealthStatus;
				}

				if (command.ToUpper() == "ОТЕЦ ИНИЦИАЛЫ")
				{
					return _selectedStudentFather.Initials();
				}
			}

			// Взвод
			if (_selectedTroop != null)
			{
				if (command.ToUpper() == "ВЗВОД НОМЕР")
				{
					return _selectedTroop.NumberTroop;
				}

				if (command.ToUpper() == "ВЗВОД КОЛ-ВО ЧЕЛОВЕК")
				{
					return _selectedTroop.StaffCount.ToString();
				}

				if (command.ToUpper() == "ВЗВОД ДЕНЬ ПРИХОДА")
				{
					return _selectedTroop.GetArrivalDayValue; //TODO
				}

				if (command.ToUpper() == "ВЗВОД ВУС")
				{
					return _selectedTroop.Cycle.VUS; // TODO
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 5")
				{
					return _selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 5) != 0 ?
						_selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 5).ToString() : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 5 %")
				{
					return _selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 5) != 0 ?
						((double)((_selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 5))) / _selectedTroop.Students.Count * 100).ToString("#.#") : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 4")
				{
					return _selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 4) != 0 ?
						_selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 4).ToString() : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 4 %")
				{
					return _selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 4) != 0 ?
						((double)((_selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 4))) / _selectedTroop.Students.Count * 100).ToString("#.#") : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 3")
				{
					return _selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 3) != 0 ?
						_selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 3).ToString() : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 3 %")
				{
					return _selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 3) != 0 ?
						((double)((_selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal == 3))) / _selectedTroop.Students.Count * 100).ToString("#.#") : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 2")
				{
					return _selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal <= 2) != 0 ?
						_selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal <= 2).ToString() : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ОБЩАЯ ОЦЕНКА 2 %")
				{
					return _selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal <= 2) != 0 ?
						((double)((_selectedTroop.Students.Count(u => u.AssessmentProtocolOneFinal <= 2))) / _selectedTroop.Students.Count * 100).ToString("#.#") : "-";
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 ВСЕГО СДАЛО")
				{
					return _selectedTroop.Students.Count(u => (u.AssessmentProtocolOneFinal <= 5 && u.AssessmentProtocolOneFinal > 2)).ToString();
				}

				if (command.ToUpper() == "ПРОТОКОЛ 1 СРЕДНИЙ БАЛЛ")
				{
					return (Convert.ToDouble(_selectedTroop.Students.TakeWhile(u => (u.AssessmentProtocolOneFinal <= 5 && u.AssessmentProtocolOneFinal >= 2)).Sum(u => u.AssessmentProtocolOneFinal)) /
						 _selectedTroop.Students.Count(u => (u.AssessmentProtocolOneFinal <= 5 && u.AssessmentProtocolOneFinal >= 2))).ToString("#.#");
				}

				if (_selectedTroop.Prepod != null)
				{
					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ИМЯ")
					{
						return _selectedTroop.Prepod.FirstName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ФАМИЛИЯ")
					{
						return _selectedTroop.Prepod.MiddleName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ОТЧЕСТВО")
					{
						return _selectedTroop.Prepod.LastName;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ЗВАНИЕ")
					{
						return _selectedTroop.Prepod.GetCoolnessValue; // TODO
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ДОЛЖНОСТЬ")
					{
						return _selectedTroop.Prepod.PrepodRank;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ИНИЦИАЛЫ")
					{
						return _selectedTroop.Prepod.Initials;
					}

					if (command.ToUpper() == "ВЗВОД ПРЕПОДАВАТЕЛЬ ПОДПИСЬ")
					{
						return "ВЗВОД ПРЕПОДАВАТЕЛЬ ПОДПИСЬ";
					}
				}

				// Командир взвода
				if (_selectedTroop.PlatoonCommander != null)
				{

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ИМЯ")
					{
						return _selectedTroop.PlatoonCommander.FirstName;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ФАМИЛИЯ")
					{
						return _selectedTroop.PlatoonCommander.MiddleName;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ОТЧЕСТВО")
					{
						return _selectedTroop.PlatoonCommander.LastName;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ФАКУЛЬТЕТ")
					{
						return _selectedTroop.PlatoonCommander.Faculty;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГРУППА")
					{
						return _selectedTroop.PlatoonCommander.InstGroup;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ВУС")
					{
						return _selectedTroop.PlatoonCommander.SpecialityName;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР УСЛОВИЯ ОБУЧЕНИЯ")
					{
						return _selectedTroop.PlatoonCommander.ConditionsOfEducation;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР СРЕДНИЙ БАЛЛ")
					{
						return _selectedTroop.PlatoonCommander.AvarageScore;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГОД ПОСТУПЛЕНИЯ В МАИ")
					{
						return _selectedTroop.PlatoonCommander.YearOfAddMAI;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГОД ОКОНЧАНИЯ МАИ")
					{
						return _selectedTroop.PlatoonCommander.YearOfEndMAI;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГОД ПОСТУПЛЕНИЯ НА КАФЕДРУ")
					{
						return _selectedTroop.PlatoonCommander.YearOfAddVK;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГОД ОКОНЧАНИЯ КАФЕДРЫ")
					{
						return _selectedTroop.PlatoonCommander.YearOfEndVK;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР НОМЕР ПРИКАЗА")
					{
						return _selectedTroop.PlatoonCommander.NumberOfOrder;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ДАТА ПРИКАЗА")
					{
						return _selectedTroop.PlatoonCommander.DateOfOrder;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ВОЕНКОМАТ")
					{
						return _selectedTroop.PlatoonCommander.Rectal;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ДЕНЬ РОЖДЕНИЯ")
					{
						return _selectedTroop.PlatoonCommander.Birthday;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР МЕСТО РОЖДЕНИЯ")
					{
						return _selectedTroop.PlatoonCommander.PlaceBirthday;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР НАЦИЯ")
					{
						return _selectedTroop.PlatoonCommander.Nationality;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ДОМАШНИЙ НОМЕР")
					{
						return _selectedTroop.PlatoonCommander.HomePhone;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР МОБИЛЬНЫЙНОМЕР")
					{
						return _selectedTroop.PlatoonCommander.MobilePhone;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР АДРЕС ПРОЖИВАНИЯ")
					{
						return _selectedTroop.PlatoonCommander.PlaceOfResidence;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР АДРЕС РЕГИСТРАЦИИ")
					{
						return _selectedTroop.PlatoonCommander.PlaceOfRegestration;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ШКОЛА")
					{
						return _selectedTroop.PlatoonCommander.School;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ДОЛЖНОСТЬ")
					{
						return _selectedTroop.PlatoonCommander.GetPositionValue; // TODO
					}


					if (command.ToUpper() == "ВЗВОД КОМАНДИР ВЗВОД")
					{
						return _selectedTroop.NumberTroop;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ИНИЦИАЛЫ")
					{
						return _selectedTroop.PlatoonCommander.Initials;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР СЛУЖБА В ВС")
					{
						return _selectedTroop.PlatoonCommander.Military;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР СЕМЕЙНЫЙ СТАТУС")
					{
						return _selectedTroop.PlatoonCommander.FamiliStatys;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР ГРУППА КРОВИ")
					{
						return _selectedTroop.PlatoonCommander.BloodType;
					}

					if (command.ToUpper() == "ВЗВОД КОМАНДИР СПЕЦИАЛЬНОСТЬ В ИНСТИТУТЕ")
					{
						return _selectedTroop.PlatoonCommander.SpecInst;
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

        private void ChangeTroop()
		{
			_students = _selectedTroop.Students.ToList();
			_selectedStudent = _students.First();
			ChangeSelectedStudent();
		}

        private void ChangeSelectedStudent()
		{
			_selectedStudentMather = null;
			_selectedStudentFather = null;
			if (_selectedStudent?.Relatives != null)
			{
				if (_selectedStudent.Relatives.Count != 0)
				{
					_selectedRelative = _selectedStudent.Relatives.First();
				}
				foreach (Relative item in _selectedStudent.Relatives)
				{
					if ((item.RelationDegree == "Мать" || item.RelationDegree == "Мачеха") && _selectedStudentMather == null)
					{
						_selectedStudentMather = item;
					}

					if ((item.RelationDegree == "Отец" || item.RelationDegree == "Отчим")
						&& _selectedStudentFather == null)
					{
						_selectedStudentFather = item;
					}
				}
			}
		}
	}
}
