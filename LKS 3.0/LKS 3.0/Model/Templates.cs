using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;


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

		public Templates(string fileName, List<Student> Students = null, List<Prepod> prepods = null, List<Troop> troops = null)
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
			selectedStudent = students.First(); // устанавливаем выбранного стуента
			changeSelectedStudent(); // меняем мать и отца студента

			///////////////////

			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog(); // создали новое диалоговое окно
			dlg.Filter = "Word files (*.docx)|*.docx"; // добавили фильтер

			if (troops.Count == 0)
			{
				dlg.FileName = students.First().MiddleName;
			}
			else
			{
				dlg.FileName = troops.First().NumberTroop;
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
				// получили список форматированного текста
				List<SdtElement> allFormattedText = doc.MainDocumentPart.Document.Body.Descendants<SdtElement>().ToList();

				foreach (Table table in doc.MainDocumentPart.Document.Body.Elements<Table>()) // проходим все таблицы
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
								// СТУДЕНТЫ
								// TODO Вынести все это в функцию и упростить (сейчас очень много индусского кода) 
								if (tempRow.Descendants<SdtElement>().ToList().Find(obj =>
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "СТУДЕНТЫ") != null)
								{
									tempRow.Descendants<SdtElement>().ToList().Find(obj =>
									obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "СТУДЕНТЫ").Remove();
									for (int i = 0; i < students.Count; i++)
									{
										selectedStudent = students[i];
										changeSelectedStudent();

										List<TableRow> rowList = table.Elements<TableRow>().ToList();

										IEnumerator<TableCell> IEcell = rowList[rowIndex].Descendants<TableCell>().ToList().GetEnumerator(); // перечеслитель для перебора ячеек в строке которая назодится в таблице
										foreach (TableCell cell in tempRow.Descendants<TableCell>().ToList()) // проходим по всем ячейкам
										{
											IEcell.MoveNext();// передвинули перечеслитель
											if (cell.Descendants<SdtElement>().Any()) // проверка на наличие закладок в ячейке
											{
												// ссылка на копиию, которой мы заменим текущую выбранную ячейку в строке
												TableCell tempCell = cell.Clone() as TableCell;
												IEcell.Current.Parent.ReplaceChild(tempCell, IEcell.Current); // замена
												foreach (SdtElement formattedText in tempCell.Descendants<SdtElement>().ToList())
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
													if (valueCommand != "false")
													{
														// TODO Добавить обработку ситуации когда в закладке нет текста)
														Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run;
														(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
														formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																												   // и заменил закладку обычным текстом
																												   //IEcell.Current.
													}
												}
											}
										}
										rowIndex++; // перешли на след строку
									} //
									break; // закончили работу с таблицей
								}

								// ВЗВОДА
								if (tempRow.Descendants<SdtElement>().ToList().Find(obj =>
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "ВЗВОДА") != null)
								{
									tempRow.Descendants<SdtElement>().ToList().Find(obj =>
									obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "ВЗВОДА").Remove();
									for (int i = 0; i < troops.Count; i++)
									{
										selectedTrop = troops[i];
										changeTroop();

										List<TableRow> rowList = table.Elements<TableRow>().ToList();

										IEnumerator<TableCell> IEcell = rowList[rowIndex].Descendants<TableCell>().ToList().GetEnumerator(); // перечеслитель для перебора ячеек в строке которая назодится в таблице
										foreach (TableCell cell in tempRow.Descendants<TableCell>().ToList()) // проходим по всем ячейкам
										{
											IEcell.MoveNext();// передвинули перечеслитель
											if (cell.Descendants<SdtElement>().Any()) // проверка на наличие закладок в ячейке
											{
												// ссылка на копиию, которой мы заменим текущую выбранную ячейку в строке
												TableCell tempCell = cell.Clone() as TableCell;
												IEcell.Current.Parent.ReplaceChild(tempCell, IEcell.Current); // замена
												foreach (SdtElement formattedText in tempCell.Descendants<SdtElement>().ToList())
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
													if (valueCommand != "false")
													{
														// TODO Добавить обработку ситуации когда в закладке нет текста)
														Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run;
														(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
														formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																												   // и заменил закладку обычным текстом
																												   //IEcell.Current.
													}
												}
											}
										}
										rowIndex++; // перешли на след строку
									} //
									break; // закончили работу с таблицей
								}

								//РОДСТВЕННИКИ
								if (tempRow.Descendants<SdtElement>().ToList().Find(obj =>
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "РОДСТВЕННИКИ") != null)
								{
									tempRow.Descendants<SdtElement>().ToList().Find(obj =>
									obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "РОДСТВЕННИКИ").Remove();
									for (int i = 0; i < selectedStudent.ListRelatives.Count; i++)
									{
										selectedRelative = selectedStudent.ListRelatives[i];


										List<TableRow> rowList = table.Elements<TableRow>().ToList();

										IEnumerator<TableCell> IEcell = rowList[rowIndex].Descendants<TableCell>().ToList().GetEnumerator(); // перечеслитель для перебора ячеек в строке которая назодится в таблице
										foreach (TableCell cell in tempRow.Descendants<TableCell>().ToList()) // проходим по всем ячейкам
										{
											IEcell.MoveNext();// передвинули перечеслитель
											if (cell.Descendants<SdtElement>().Any()) // проверка на наличие закладок в ячейке
											{
												// ссылка на копиию, которой мы заменим текущую выбранную ячейку в строке
												TableCell tempCell = cell.Clone() as TableCell;
												IEcell.Current.Parent.ReplaceChild(tempCell, IEcell.Current); // замена
												foreach (SdtElement formattedText in tempCell.Descendants<SdtElement>().ToList())
												{
													string valueCommand = findCommand(formattedText.Descendants<SdtAlias>().First().Val);
													if (valueCommand != "false")
													{
														// TODO Добавить обработку ситуации когда в закладке нет текста)
														Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run;
														(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
														formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																												   // и заменил закладку обычным текстом
																												   //IEcell.Current.
													}
												}
											}
										}
										rowIndex++; // перешли на след строку
									} //
									break; // закончили работу с таблицей
								}

								// Индийский код закончился(переделай эту хрень, если ты это увидел!!)
								break; // закончили работу с таблицей
							}
							rowIndex++;
						}
					}
					else // с добавлением строк
					{
						foreach (TableRow row in table.Elements<TableRow>())
						{
							if (row.Descendants<SdtElement>().Any()) // проверка на наличие закладок в строке
							{
								// TODO Снова индийский код
								// Студенты
								if (row.Descendants<SdtElement>().ToList().Find(obj =>
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "СТУДЕНТЫ") != null)
								{
									// удалили лишнюю комаду
									row.Descendants<SdtElement>().ToList().Find(obj =>
									obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "СТУДЕНТЫ").Remove();
									for (int i = 0; i < students.Count; i++)
									{
										TableRow tempRow = row.Clone() as TableRow; // создали копию строки
										selectedStudent = students[i];
										changeSelectedStudent();
										// модифицировал копию строки
										foreach (SdtElement formattedText in tempRow.Descendants<SdtElement>().ToList())
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
											if (valueCommand != "false")
											{
												// TODO Добавить обработку ситуации когда в закладке нет текста)
												Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run;
												(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
												formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																										   // и заменил закладку обычным текстом
											}
										}

										table.AppendChild(tempRow); // добавили временую стороку к таблице
									} // закончили создание таблицы
								}
								// Взвода
								if (row.Descendants<SdtElement>().ToList().Find(obj =>
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "ВЗВОДА") != null)
								{
									row.Descendants<SdtElement>().ToList().Find(obj =>
									obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "ВЗВОДА").Remove();
									for (int i = 0; i < troops.Count; i++)
									{
										selectedTrop = troops[i];
										changeTroop();
										TableRow tempRow = row.Clone() as TableRow; // создали копию строки
																					// модифицировал копию строки
										foreach (SdtElement formattedText in tempRow.Descendants<SdtElement>().ToList())
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
											if (valueCommand != "false")
											{
												// TODO Добавить обработку ситуации когда в закладке нет текста)
												Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run;
												(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
												formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																										   // и заменил закладку обычным текстом
											}
										}

										table.AppendChild(tempRow); // добавили временую стороку к таблице
									} // закончили создание таблицы
								}
								//Родственники
								if (row.Descendants<SdtElement>().ToList().Find(obj =>
								 obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "РОДСТВЕННИКИ") != null)
								{
									row.Descendants<SdtElement>().ToList().Find(obj =>
									obj.Descendants<SdtAlias>().First().Val.ToString().ToUpper() == "РОДСТВЕННИКИ").Remove();
									for (int i = 0; i < selectedStudent.ListRelatives.Count; i++)
									{
										selectedRelative = selectedStudent.ListRelatives[i];
										TableRow tempRow = row.Clone() as TableRow; // создали копию строки
																					// модифицировал копию строки
										foreach (SdtElement formattedText in tempRow.Descendants<SdtElement>().ToList())
										{
											string valueCommand = findCommand(formattedText.Descendants<SdtAlias>().First().Val);
											if (valueCommand != "false")
											{
												// TODO Добавить обработку ситуации когда в закладке нет текста)
												Run tempRun = formattedText.Descendants<Run>().First().Clone() as Run;
												(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
												formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																										   // и заменил закладку обычным текстом
											}
										}

										table.AppendChild(tempRow); // добавили временую стороку к таблице
									} // закончили создание таблицы
								}
								row.Parent.RemoveChild(row); // удалили немодифицированную строку
								break; // закончили работу с таблицей
							}

						}
					}
				}

				// проходим по всем элементам "форматированный текст"(далее просто "закладка")
				// и сверяем имя закладки со списком команд
				// как обычно здесь есть немного магии (без toList может работать не правильно)

				// как всегда небольшой костыль ( сбрасываю исходного студента на начало)
				selectedStudent = students[0];
				changeSelectedStudent();
				foreach (SdtElement formattedText in doc.MainDocumentPart.Document.Body.Descendants<SdtElement>().ToList())
				{
					string valueCommand = findCommand(formattedText.SdtProperties.GetFirstChild<SdtAlias>().Val);
					if (valueCommand != "false")
					{
						SdtContentRun contentRun = formattedText.GetFirstChild<SdtContentRun>(); // ссылка на контент
						Run tempRun = contentRun.FirstChild.Clone() as Run; // скопировал первого потомка
						(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
						formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																				   // и заменил закладку обычным текстом
					}
				}
			}
			System.Windows.MessageBox.Show("Готово!");
		}

		private string findCommand(string command)
		{
			if (command.ToUpper() == "НОВАЯ СТРОКА")
			{
				return "\n";
			}

			if (command.ToUpper() == "ТЕКУЩАЯ ДАТА")
			{
				return DateTime.Now.ToString("dd.MM.yyyy");
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

			if (command.ToUpper() == "СРУДНИЙ БАЛЛ")
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

			if (command.ToUpper() == "ГРУПП АКРОВИ")
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

				if (command.ToUpper() == "РОД ФАМИОЛИЯ")
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
					// TODO ВУС
					return "";
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

			if (command.ToUpper() == "$С$" ||
				command.ToUpper() == "$Р$" ||
				command.ToUpper() == "$О$")
			{
				return "";
			}

			return "false";
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
			//initcommand(ref command); // обновили все параметры в массиве комманд(переделать)
		}
	}
}
