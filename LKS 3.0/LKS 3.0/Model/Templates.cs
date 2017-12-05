using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

using System.IO;

//using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop;

namespace LKS_3._0
{

	class Templates
	{

		List<Student> students;
		Student selectedStudent;
		Relative selectedStudentMather,
			selectedStudentFather,
			selectedRelative;
		Troop selectedTrop;

		Dictionary<string, string> command; // массив комманд

		public Templates(string fileName, List<Student> Students = null, List<Prepod> prepods = null, List<Troop> troops = null)
		{
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
									 //System.IO.File.Copy(fileName, @"D:\projects\Git\LKS-3.0\LKS 3.0\LKS 3.0\bin\Debug\Templates\123.docx", true);



			try
			{


				Word.Application appDoc = new Word.Application(); // создали новый вордовский процесс
				Word.Document doc = appDoc.Documents.Open(fileName, ReadOnly: false); // открыли документ
				Word.Range range = doc.Content; // запихнули весь текст из документа в range


				while (range.Find.Execute("$?{1;20}$", MatchWildcards: true)) // ищем команды
				{

					if (range.Text == "$НОВТБ$") // если встретили начало таблицы 
					{
						Word.Table selectedTable = null;
						for (int i = 1; i <= doc.Tables.Count; i++)
						{
							Word.Range item = doc.Tables[i].Range;
							if (doc.Tables[i].Range.Find.Execute("$НОВТБ$", ReplaceWith: "", Forward: true))
							{
								selectedTable = doc.Tables[i];
								break;
							}
						}
						if (selectedTable != null) // нужная таблица найдена
						{
							List<TableCommand> tableCommand = new List<TableCommand>();
							int i;
							if (selectedTable.Range.Find.Execute("$О$", Forward: true)) // костыль
							{
								i = 2;
							}
							else
							{
								i = selectedTable.Rows.Count;
							}

							for (int j = 1; j <= selectedTable.Columns.Count; j++)
							{
								int firstIndex = 0, lastIndex = 0; // попутно удаляя все команды

								do //todo переделать исспользуя регулярки
								{
									if (firstIndex < selectedTable.Cell(i, j).Range.Text.Length)
										firstIndex = selectedTable.Cell(i, j).Range.Text.IndexOf('$', firstIndex);
									if (firstIndex != -1)
									{
										lastIndex = selectedTable.Cell(i, j).Range.Text.IndexOf('$', firstIndex + 1);
										tableCommand.Add(new TableCommand(j, i,
											selectedTable.Cell(i, j).Range.Text.Substring(firstIndex, lastIndex - firstIndex + 1)));
										selectedTable.Cell(i, j).Range.Text = selectedTable.Cell(i, j).Range.Text.Remove(firstIndex, lastIndex - firstIndex + 1);

									}

								} while (firstIndex != -1);
							}

							if (tableCommand.Find(obj => obj.command.ToUpper() == "$О$") != null)
							{
								selectedTable.Rows.Add(selectedTable.Rows[3]); // костыль который правит поехавшее форматирование
								selectedTable.Cell(2, 1).Range.Rows.Delete();
								int num = 0;
								int y = 0;
								foreach (Student studentItem in students)
								{
									num++;
									selectedStudent = studentItem; // переделать
									changeSelectedStudent(); // костыль 
									foreach (TableCommand item in tableCommand)
									{
										if (item.command.ToUpper() == "$НОМЕР$")
										{
											selectedTable.Cell(item.y + y, item.x).Range.InsertAfter(num.ToString());
										}
										else
										{
											selectedTable.Cell(item.y + y, item.x).Range.InsertAfter(findCommand(item.command));
										}
									}
									y++;
								}
							}

							if (tableCommand.Find(obj => obj.command.ToUpper() == "$С$") != null)
							{
								int num = 0;
								foreach (Student studentItem in students)
								{
									num++;
									selectedStudent = studentItem; // переделать
									changeSelectedStudent(); // костыль 
									selectedTable.Rows.Add();
									foreach (TableCommand item in tableCommand)
									{
										if (item.command.ToUpper() == "$НОМЕР$")
										{
											selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(num.ToString());
										}
										else
										{
											selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(findCommand(item.command.ToUpper()));
										}
									}
								}
								selectedTable.Cell(tableCommand[0].y, 1).Range.Rows.Delete();
							}

							// КАК всегда немного костылей

							if (tableCommand.Find(obj => obj.command.ToUpper() == "$Р$") != null)
							{
								int num = 0;
								foreach (Relative relativeItem in selectedStudent.ListRelatives)
								{
									selectedRelative = relativeItem; // переделать
									selectedTable.Rows.Add();
									num++;

									foreach (TableCommand item in tableCommand)
									{
										if (item.command.ToUpper() == "$НОМЕР$")
										{
											selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(num.ToString());
										}
										else
										{
											selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(findCommand(item.command));   //Text += findCommand(item.command);
										}                                                                                                    //selectedTable.Cell.
									}
								}
								selectedTable.Cell(tableCommand[0].y, 1).Range.Rows.Delete();
							}




						}
					}
					else
					{
						if (range.Text.ToUpper() != "$ФОТО$")
						{
							range.Text = findCommand(range.Text);
						}
						else
						{
							range.Text = "";
							range.InlineShapes.AddPicture(selectedStudent.ImagePath, Range: range);
						}
						range.Find.ClearFormatting();
						range = doc.Content;
					}
				}

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
					doc.SaveAs(dlg.FileName);

				}

				//appDoc.Visible = true;
				doc.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
				appDoc.Quit();
				System.Windows.MessageBox.Show("ГОТОВО!");
			}

			catch
			{
				System.Windows.MessageBox.Show("Ошибка, закройте все процессы ворда и попробуйте еще раз.");
				return;
		}

	}

	private void initcommand(ref Dictionary<string, string> command)
	{
		command = new Dictionary<string, string>()
			{
				{ "$N$", "\n" },
				{ "$ИМЯ$",selectedStudent.FirstName },
				{ "$ФАМИЛИЯ$", selectedStudent.MiddleName },
				{ "$ОТЧЕСТВО$", selectedStudent.LastName },
				{ "$ФАКУЛЬТЕТ$", selectedStudent.Faculty },
				{ "$ГРУППА$", selectedStudent.Group },
				{ "$ВУС$", selectedStudent.SpecialityName },
				{ "$УСЛОБУЧ$", selectedStudent.ConditionsOfEducation },
				{ "$СРБАЛЛ$", selectedStudent.AvarageScore },
				{ "$ПОСТМАИ$", selectedStudent.YearOfAddMAI },
				{ "$ОКОНЧМАИ$", selectedStudent.YearOfEndMAI },
				{ "$ПОСТВОЕНКАФ$", selectedStudent.YearOfAddVK },
				{ "$ОКОНЧВОЕНКАФ$", selectedStudent.YearOfEndVK },
				{ "$НОМЕРПРИКАЗА$", selectedStudent.NumberOfOrder },
				{ "$ДАТАПРИКАЗА$", selectedStudent.DateOfOrder },
				{ "$ВОЕНКОМАТ$", selectedStudent.Rectal },
				{ "$ДЕНЬРОЖД$", selectedStudent.Birthday },
				{ "$МЕСТОРОЖД$",  selectedStudent.PlaceBirthday },
				{ "$НАЦИЯ$", selectedStudent.Nationality },
				{ "$ДОМНОМЕР$", selectedStudent.HomePhone },
				{ "$МОБНОМЕР$", selectedStudent.MobilePhone },
				{ "$АДРЕСПРОЖИВАНИЯ$", selectedStudent.PlaceOfResidence },
				{ "$АДРЕСРЕГИСТРАЦИИ$", selectedStudent.PlaceOfRegestration },
				{ "$ШКОЛА$", selectedStudent.School },
				{ "$ДОЛЖНОСТЬ$", selectedStudent.Rank },
				{ "$ВЗВОД$", selectedStudent.Troop },
				{ "$ИНИЦИАЛЫ$", selectedStudent.initials() },
				{ "$СЛУЖБАВВС$", selectedStudent.Military },
				{ "$СЕМЕЙНЫЙСТАТУС$", selectedStudent.FamiliStatys },
				{ "$ГРУППАКРОВИ$", selectedStudent.BloodType },
				{ "$СПЕЦВИНСТ$", selectedStudent.SpecInst },

				{ "$РОДИМЯ$", selectedRelative.FirstName },
				{ "$РОДФАМИОЛИЯ$", selectedRelative.MiddleName },
				{ "$РОДОТЧЕСТВО$", selectedRelative.LastName },
				{ "$РОДДЕВИЧФАМИЛИЯ$", selectedRelative.MaidenName },
				{ "$РОДДЕНЬРОЖД$", selectedRelative.Birthday },
				{ "$РОД$АДРЕСГЕРИСТРАЦИИ", selectedRelative.PlaceOfRegestration },
				{ "$РОДАДРЕСПРОЖИВАНИЯ$", selectedRelative.PlaceOfResidence },
				{ "$РОДМОБНОМЕР$", selectedRelative.MobilePhone },
				{ "$РОДСТЕПЕНЬРОДСТВА$", selectedRelative.RelationDegree },
				{ "$РОДСОСТЗДОРОВЬЯ$", selectedRelative.HealthStatus },
				{ "$РОДИНИЦИАЛЫ$", selectedRelative.initials() },

				{ "$МАТЬИМЯ$", selectedStudentMather.FirstName },
				{ "$МАТЬФИМИЛИЯ$", selectedStudentMather.MiddleName },
				{ "$МАТЬОТЧЕСТВО$", selectedStudentMather.LastName},
				{ "$МАТЬДЕВИЧЬЯФАМИЛИЯ$", selectedStudentMather.MaidenName },
				{ "$МАТЬДЕНЬРОЖД$", selectedStudentMather.Birthday },
				{ "$МАТЬАДРЕСРЕГИСТРАЦИИ$",selectedStudentMather.PlaceOfRegestration },
				{ "$МАТЬАДРЕСПРОЖИВАНИЯ$", selectedStudentMather.PlaceOfResidence },
				{ "$МАТЬМОБНОМЕР$", selectedStudentMather.MobilePhone },
				{ "$МАТЬСТЕПРОДСТВА$", selectedStudentMather.RelationDegree },
				{ "$МАТЬСОСТЗДОРОВЬЯ$", selectedStudentMather.HealthStatus },
				{ "$МАТЬИНИЦИАЛЫ$", selectedStudentMather.initials() },

				{ "$ОТЕЦИМЯ$", selectedStudentFather.FirstName },
				{ "$ОТЕЦФАМИЛИЯ$", selectedStudentFather.MiddleName },
				{ "$ОТЕЦОТЧЕСТВО$", selectedStudentFather.LastName },
				{ "$FATHMAIDNAME$",selectedStudentFather.MaidenName },
				{ "$ОТЕЦДЕНЬРОЖД$",selectedStudentFather.Birthday },
				{ "$ОТЕЦАДРЕСРЕГИСТРАЦИИ$",selectedStudentFather.PlaceOfRegestration },
				{ "$ОТЕЦАДРЕСПРОЖИВАНИЯ$", selectedStudentFather.PlaceOfResidence },
				{ "$ОТЕЦМОБНОМЕР$", selectedStudentFather.MobilePhone },
				{ "$ОТЕЦСТЕПРОДСТВА$", selectedStudentFather.RelationDegree },
				{ "$ОТЕЦСОСТЗДОРОВЬЯ$",selectedStudentFather.HealthStatus },
				{ "$ОТЕЦИНИЦИАЛЫ$", selectedStudentFather.initials() },

				{ "$ВЗНОМЕР$", selectedTrop.NumberTroop },

				{ "$ВЗКОЛВОЧЕЛ$", selectedTrop.StaffCount.ToString() },
				{ "$ВЗПИМЯ$",selectedTrop.ResponsiblePrepod.FirstName },
				{ "$ВЗПФАМИЛИЯ$", selectedTrop.ResponsiblePrepod.MiddleName },
				{ "$ВЗПОТЧЕСТВО$", selectedTrop.ResponsiblePrepod.LastName },
				{ "$ВЗПЗВАНИЕ$", selectedTrop.ResponsiblePrepod.Coolness },
				{ "$ВЗПДОЛЖНОСТЬ$", selectedTrop.ResponsiblePrepod.PrepodRank },
				{ "$ВЗПИНИЦИАЛЫ$",selectedTrop.ResponsiblePrepod.initials() },

				{ "$ВЗКОМИМЯ$", selectedTrop.PlatoonCommander.FirstName },
				{ "$ВЗКОМФАМИЛИЯ$", selectedTrop.PlatoonCommander.MiddleName },
				{ "$TCOMLNAME$", selectedTrop.PlatoonCommander.LastName },
				{ "$TCOMFACULTY$", selectedTrop.PlatoonCommander.Faculty },
				{ "$TCOMGROUP$", selectedTrop.PlatoonCommander.Group },
				{ "$TCOMSPNAME$", selectedTrop.PlatoonCommander.SpecialityName },
				{ "$TCOMCONDEDUC$", selectedTrop.PlatoonCommander.ConditionsOfEducation },
				{ "$TCOMAVERSCORE$", selectedTrop.PlatoonCommander.AvarageScore },
				{ "$TCOMADDMAI$", selectedTrop.PlatoonCommander.YearOfAddMAI },
				{ "$TCOMENDMAI$", selectedTrop.PlatoonCommander.YearOfEndMAI },
				{ "$TCOMADDMIL$",selectedTrop.PlatoonCommander.YearOfAddVK },
				{ "$TCOMENDMIL$", selectedTrop.PlatoonCommander.YearOfEndVK },
				{ "$TCOMNUMORDER$", selectedTrop.PlatoonCommander.NumberOfOrder },
				{ "$TCOMDATEORDER$", selectedTrop.PlatoonCommander.DateOfOrder },
				{ "$TCOMRECTAL$", selectedTrop.PlatoonCommander.Rectal },
				{ "$TCOMBIRTHDAY$", selectedTrop.PlatoonCommander.Birthday },
				{ "$TCOMPLACEBIRTH$", selectedTrop.PlatoonCommander.PlaceBirthday },
				{ "$TCOMNATION$", selectedTrop.PlatoonCommander.Nationality },
				{ "$TCOMHOMEPRONE$", selectedTrop.PlatoonCommander.HomePhone },
				{ "$TCOMMOBPHONE$", selectedTrop.PlatoonCommander.MobilePhone },
				{ "$TCOMPLACERESID$", selectedTrop.PlatoonCommander.PlaceOfResidence },
				{ "$TCOMPLACEREGISTR$", selectedTrop.PlatoonCommander.PlaceOfRegestration },
				{ "$TCOMSCHOOL$", selectedTrop.PlatoonCommander.School },
				{ "$TCOMRANK$", selectedTrop.PlatoonCommander.Rank },
				{ "$TCOMTROOP$", selectedTrop.PlatoonCommander.Troop },
				{ "$TCOMINIT$", selectedTrop.PlatoonCommander.initials() },

				{ "$S$", "" },
				{ "$R$", "" },
				{ "$O$", "" },
			};
	}

	private string findCommand(string command)
	{
		if (command.ToUpper() == "$НСТР$")
		{
			return "\n";
		}

		if (command.ToUpper() == "$ТЕКДАТА$")
		{
			return DateTime.Now.ToString("dd.MM.yyyy");
		}

		// Студент
		if (command.ToUpper() == "$ИМЯ$")
		{
			return selectedStudent.FirstName;
		}

		if (command.ToUpper() == "$ФАМИЛИЯ$")
		{
			return selectedStudent.MiddleName;
		}

		if (command.ToUpper() == "$ОТЧЕСТВО$")
		{
			return selectedStudent.LastName;
		}

		if (command.ToUpper() == "$ФАКУЛЬТЕТ$")
		{
			return selectedStudent.Faculty;
		}

		if (command.ToUpper() == "$ГРУППА$")
		{
			return selectedStudent.Group;
		}

		if (command.ToUpper() == "$ВУС$")
		{
			return selectedStudent.SpecialityName;
		}

		if (command.ToUpper() == "$УСЛОБУЧ$")
		{
			return selectedStudent.ConditionsOfEducation;
		}

		if (command.ToUpper() == "$СРБАЛЛ$")
		{
			return selectedStudent.AvarageScore;
		}

		if (command.ToUpper() == "$ПОСТМАИ$")
		{
			return selectedStudent.YearOfAddMAI;
		}

		if (command.ToUpper() == "$ОКОНЧМАИ$")
		{
			return selectedStudent.YearOfEndMAI;
		}

		if (command.ToUpper() == "$ПОСТВОЕНКАФ$")
		{
			return selectedStudent.YearOfAddVK;
		}

		if (command.ToUpper() == "$ОКОНЧВОЕНКАФ$")
		{
			return selectedStudent.YearOfEndVK;
		}

		if (command.ToUpper() == "$НОМЕРПРИКАЗА$")
		{
			return selectedStudent.NumberOfOrder;
		}

		if (command.ToUpper() == "$ДАТАПРИКАЗА$")
		{
			return selectedStudent.DateOfOrder;
		}

		if (command.ToUpper() == "$ВОЕНКОМАТ$")
		{
			return selectedStudent.Rectal;
		}

		if (command.ToUpper() == "$ДЕНЬРОЖД$")
		{
			return selectedStudent.Birthday;
		}

		if (command.ToUpper() == "$МЕСТОРОЖД$")
		{
			return selectedStudent.PlaceBirthday;
		}

		if (command.ToUpper() == "$НАЦИЯ$")
		{
			return selectedStudent.Nationality;
		}

		if (command.ToUpper() == "$ДОМНОМЕР$")
		{
			return selectedStudent.HomePhone;
		}

		if (command.ToUpper() == "$МОБНОМЕР$")
		{
			return selectedStudent.MobilePhone;
		}

		if (command.ToUpper() == "$АДРЕСПРОЖИВАНИЯ$")
		{
			return selectedStudent.PlaceOfResidence;
		}

		if (command.ToUpper() == "$АДРЕСРЕГИСТРАЦИИ$")
		{
			return selectedStudent.PlaceOfRegestration;
		}

		if (command.ToUpper() == "$ШКОЛА$")
		{
			return selectedStudent.School;
		}

		if (command.ToUpper() == "$ДОЛЖНОСТЬ$")
		{
			return selectedStudent.Rank;
		}


		if (command.ToUpper() == "$ВЗВОД$")
		{
			return selectedStudent.Troop;
		}

		if (command.ToUpper() == "$ИНИЦИАЛЫ$")
		{
			return selectedStudent.initials();
		}

		if (command.ToUpper() == "$СЛУЖБАВВС$")
		{
			return selectedStudent.Military;
		}

		if (command.ToUpper() == "$СЕМЕЙНЫЙСТАТУС$")
		{
			return selectedStudent.FamiliStatys;
		}

		if (command.ToUpper() == "$ГРУППАКРОВИ$")
		{
			return selectedStudent.BloodType;
		}

		if (command.ToUpper() == "$СПЕЦВИНСТ$")
		{
			return selectedStudent.SpecInst;
		}



		//
		//БЛОК РОДСТВЕННИКОВ
		//
		if (selectedRelative != null)
		{
			if (command.ToUpper() == "$РОДИМЯ$")
			{
				return selectedRelative.FirstName;
			}

			if (command.ToUpper() == "$РОДФАМИОЛИЯ$")
			{
				return selectedRelative.MiddleName;
			}

			if (command.ToUpper() == "$РОДОТЧЕСТВО$")
			{
				return selectedRelative.LastName;
			}

			if (command.ToUpper() == "$РОДДЕВИЧФАМИЛИЯ$")
			{
				return selectedRelative.MaidenName;
			}

			if (command.ToUpper() == "$РОДДЕНЬРОЖД$")
			{
				return selectedRelative.Birthday;
			}

			if (command.ToUpper() == "$РОДАДРЕСГЕРИСТРАЦИИ$")
			{
				return selectedRelative.PlaceOfRegestration;
			}

			if (command.ToUpper() == "$РОДАДРЕСПРОЖИВАНИЯ$")
			{
				return selectedRelative.PlaceOfResidence;
			}

			if (command.ToUpper() == "$РОДМОБНОМЕР$")
			{
				return selectedRelative.MobilePhone;
			}

			if (command.ToUpper() == "$РОДСТЕПЕНЬРОДСТВА$")
			{
				return selectedRelative.RelationDegree;
			}

			if (command.ToUpper() == "$РОДСОСТЗДОРОВЬЯ$")
			{
				return selectedRelative.HealthStatus;
			}

			if (command.ToUpper() == "$РОДИНИЦИАЛЫ$")
			{
				return selectedRelative.initials();
			}
		}
		//Мать
		if (selectedStudentMather != null)
		{
			if (command.ToUpper() == "$МАТЬИМЯ$")
			{
				return selectedStudentMather.FirstName;
			}

			if (command.ToUpper() == "$МАТЬФИМИЛИЯ$")
			{
				return selectedStudentMather.MiddleName;
			}

			if (command.ToUpper() == "$ФАТЬОТЧЕСТВО$")
			{
				return selectedStudentMather.LastName;
			}

			if (command.ToUpper() == "$МАТЬДЕВИЧЬЯФАМИЛИЯ$")
			{
				return selectedStudentMather.MaidenName;
			}

			if (command.ToUpper() == "$МАТЬДЕНЬРОЖД$")
			{
				return selectedStudentMather.Birthday;
			}

			if (command.ToUpper() == "$МАТЬАДРЕСРЕГИСТРАЦИИ$")
			{
				return selectedStudentMather.PlaceOfRegestration;
			}

			if (command.ToUpper() == "$МАТЬАДРЕСПРОЖИВАНИЯ$")
			{
				return selectedStudentMather.PlaceOfResidence;
			}

			if (command.ToUpper() == "$МАТЬМОБНОМЕР$")
			{
				return selectedStudentMather.MobilePhone;
			}

			if (command.ToUpper() == "$МАТЬСТЕПРОДСТВА$")
			{
				return selectedStudentMather.RelationDegree;
			}

			if (command.ToUpper() == "$МАТЬСОСТЗДОРОВЬЯ$")
			{
				return selectedStudentMather.HealthStatus;
			}

			if (command.ToUpper() == "$МАТЬИНИЦИАЛЫ$")
			{
				return selectedStudentMather.initials();
			}
		}
		// ОТЕЦ(ОТЧИМ)
		if (selectedStudentFather != null)
		{
			if (command.ToUpper() == "$ОТЕЦИМЯ$")
			{
				return selectedStudentFather.FirstName;
			}

			if (command.ToUpper() == "$ОТЕЦФАМИЛИЯ$")
			{
				return selectedStudentFather.MiddleName;
			}

			if (command.ToUpper() == "$ОТЕЦОТЧЕСТВО$")
			{
				return selectedStudentFather.LastName;
			}

			if (command.ToUpper() == "$ОТЕЦДЕВФАМИЛИЯ$")
			{
				return selectedStudentFather.MaidenName;
			}

			if (command.ToUpper() == "$ОТЕЦДЕНЬРОЖД$")
			{
				return selectedStudentFather.Birthday;
			}

			if (command.ToUpper() == "$ОТЕЦАДРЕСРЕГИСТРАЦИИ$")
			{
				return selectedStudentFather.PlaceOfRegestration;
			}

			if (command.ToUpper() == "$ОТЕЦАДРЕСПРОЖИВАНИЯ$")
			{
				return selectedStudentFather.PlaceOfResidence;
			}

			if (command.ToUpper() == "$ОТЕЦМОБНОМЕР$")
			{
				return selectedStudentFather.MobilePhone;
			}

			if (command.ToUpper() == "$ОТЕЦСТЕПРОДСТВА$")
			{
				return selectedStudentFather.RelationDegree;
			}

			if (command.ToUpper() == "$ОТЕЦСОСТЗДОРОВЬЯ$")
			{
				return selectedStudentFather.HealthStatus;
			}

			if (command.ToUpper() == "$ОТЕЦИНИЦИАЛЫ$")
			{
				return selectedStudentFather.initials();
			}
		}

		// Взвод
		if (selectedTrop != null)
		{
			if (command.ToUpper() == "$ВЗНОМЕР$")
			{
				return selectedTrop.NumberTroop;
			}

			if (command.ToUpper() == "$ВЗКОЛВОЧЕЛ$")
			{
				return selectedTrop.StaffCount.ToString();
			}

			if (command.ToUpper() == "$ВЗДЕНЬПРИХОДА$")
			{
				// TODO ВОЗВРАЩАТЬ ДЕНЬ ПРИХОДА
				return "";
			}

			if (command.ToUpper() == "$ВЗВУС$")
			{
				// TODO ВУС
				return "";
			}

			if (command.ToUpper() == "$ВЗПИМЯ$")
			{
				return selectedTrop.ResponsiblePrepod.FirstName;
			}

			if (command.ToUpper() == "$ВЗПФАМИЛИЯ$")
			{
				return selectedTrop.ResponsiblePrepod.MiddleName;
			}

			if (command.ToUpper() == "$ВЗПОТЧЕСТВО$")
			{
				return selectedTrop.ResponsiblePrepod.LastName;
			}

			if (command.ToUpper() == "$ВЗПЗВАНИЕ$")
			{
				return selectedTrop.ResponsiblePrepod.Coolness;
			}

			if (command.ToUpper() == "$ВЗПДОЛЖНОСТЬ$")
			{
				return selectedTrop.ResponsiblePrepod.PrepodRank;
			}

			if (command.ToUpper() == "$ВЗПИНИЦИАЛЫ$")
			{
				return selectedTrop.ResponsiblePrepod.initials();
			}

			// Командир взвода

			if (command.ToUpper() == "$ВЗКОМКИМЯ$")
			{
				return selectedTrop.PlatoonCommander.FirstName;
			}

			if (command.ToUpper() == "$ВЗКОМИМЯ$")
			{
				return selectedTrop.PlatoonCommander.FirstName;
			}

			if (command.ToUpper() == "$ВЗКОМФАМИЛИЯ$")
			{
				return selectedTrop.PlatoonCommander.MiddleName;
			}

			if (command.ToUpper() == "$ВЗКОМОТЧЕСТВО$")
			{
				return selectedTrop.PlatoonCommander.LastName;
			}

			if (command.ToUpper() == "$ВЗКОМФАКУЛЬТЕТ$")
			{
				return selectedTrop.PlatoonCommander.Faculty;
			}

			if (command.ToUpper() == "$ВЗКОМГРУППА$")
			{
				return selectedTrop.PlatoonCommander.Group;
			}

			if (command.ToUpper() == "$ВЗКОМВУС$")
			{
				return selectedTrop.PlatoonCommander.SpecialityName;
			}

			if (command.ToUpper() == "$ВЗКОМУСЛОБУЧ$")
			{
				return selectedTrop.PlatoonCommander.ConditionsOfEducation;
			}

			if (command.ToUpper() == "$ВЗКОМСРБАЛЛ$")
			{
				return selectedTrop.PlatoonCommander.AvarageScore;
			}

			if (command.ToUpper() == "$ВЗКОМПОСТМАИ$")
			{
				return selectedTrop.PlatoonCommander.YearOfAddMAI;
			}

			if (command.ToUpper() == "$ВЗКОМОКОНЧМАИ$")
			{
				return selectedTrop.PlatoonCommander.YearOfEndMAI;
			}

			if (command.ToUpper() == "$ВЗКОМПОСТВОЕНКАФ$")
			{
				return selectedTrop.PlatoonCommander.YearOfAddVK;
			}

			if (command.ToUpper() == "$ВЗКОМОКОНЧВОЕНКАФ$")
			{
				return selectedTrop.PlatoonCommander.YearOfEndVK;
			}

			if (command.ToUpper() == "$ВЗКОМНОМЕРПРИКАЗА$")
			{
				return selectedTrop.PlatoonCommander.NumberOfOrder;
			}

			if (command.ToUpper() == "$ВЗКОМДАТАПРИКАЗА$")
			{
				return selectedTrop.PlatoonCommander.DateOfOrder;
			}

			if (command.ToUpper() == "$ВЗКОМВОЕНКОМАТ$")
			{
				return selectedTrop.PlatoonCommander.Rectal;
			}

			if (command.ToUpper() == "$ВЗКОМДЕНЬРОЖД$")
			{
				return selectedTrop.PlatoonCommander.Birthday;
			}

			if (command.ToUpper() == "$ВЗКОММЕСТОРОЖД$")
			{
				return selectedTrop.PlatoonCommander.PlaceBirthday;
			}

			if (command.ToUpper() == "$ВЗКОМНАЦИЯ$")
			{
				return selectedTrop.PlatoonCommander.Nationality;
			}

			if (command.ToUpper() == "$ВЗКОМДОМНОМЕР$")
			{
				return selectedTrop.PlatoonCommander.HomePhone;
			}

			if (command.ToUpper() == "$ВЗКОММОБНОМЕР$")
			{
				return selectedTrop.PlatoonCommander.MobilePhone;
			}

			if (command.ToUpper() == "$ВЗКОМАДРЕСПРОЖИВАНИЯ$")
			{
				return selectedTrop.PlatoonCommander.PlaceOfResidence;
			}

			if (command.ToUpper() == "$ВЗКОМАДРЕСРЕГИСТРАЦИИ$")
			{
				return selectedTrop.PlatoonCommander.PlaceOfRegestration;
			}

			if (command.ToUpper() == "$ВЗКОМШКОЛА$")
			{
				return selectedTrop.PlatoonCommander.School;
			}

			if (command.ToUpper() == "$ВЗКОМДОЛЖНОСТЬ$")
			{
				return selectedTrop.PlatoonCommander.Rank;
			}


			if (command.ToUpper() == "$ВЗКОМВЗВОД$")
			{
				return selectedTrop.PlatoonCommander.Troop;
			}

			if (command.ToUpper() == "$ВЗКОМИНИЦИАЛЫ$")
			{
				return selectedTrop.PlatoonCommander.initials();
			}

			if (command.ToUpper() == "$ВЗКОМСЛУЖБАВВС$")
			{
				return selectedTrop.PlatoonCommander.Military;
			}

			if (command.ToUpper() == "$ВЗКОМСЕМЕЙНЫЙСТАТУС$")
			{
				return selectedTrop.PlatoonCommander.FamiliStatys;
			}

			if (command.ToUpper() == "$ВЗКОМГРУППАКРОВИ$")
			{
				return selectedTrop.PlatoonCommander.BloodType;
			}

			if (command.ToUpper() == "$ВЗКОМСПЕЦВИНСТ$")
			{
				return selectedTrop.PlatoonCommander.SpecInst;
			}
		}

		if (command.ToUpper() == "$С$" ||
			command.ToUpper() == "$Р$" ||
			command.ToUpper() == "$О$")
		{
			return "";
		}



		return command.Substring(1, command.Length - 2);
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
