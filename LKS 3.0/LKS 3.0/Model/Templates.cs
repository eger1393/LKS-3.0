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



		public Templates(string fileName, List<Student> Students = null, List<Prepod> prepods = null, List<Troop> troops = null)
		{
			// КОСТЫЛЬ
			if(Students == null)
			{
				Students = new List<Student>();
			}

			if(troops == null)
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



			Word.Application appDoc = new Word.Application(); // создали новый вордовский процесс
			Word.Document doc = appDoc.Documents.Open(fileName, ReadOnly: false); // открыли документ
			Word.Range range = doc.Content; // запихнули весь текст из документа в range


			while (range.Find.Execute("$?{1;20}$", MatchWildcards: true, Forward: true)) // ищем команды
			{
				
				if (range.Text == "$NTbl$") // если встретили начало таблицы 
				{ 
					Word.Table selectedTable = null;
					for (int i = 1; i <= doc.Tables.Count; i++)
					{
						Word.Range item = doc.Tables[i].Range;
						if (item.Find.Execute("$NTbl$", ReplaceWith: "", Forward: true))
						{
							selectedTable = doc.Tables[i];
							break;
						}
					}
					if (selectedTable != null) // нужная таблица найдена
					{
						List<TableCommand> tableCommand = new List<TableCommand>();

						int r = selectedTable.Rows.Count;
						int c = selectedTable.Columns.Count;
						//foreach (Word.Row rowItem in selectedTable.Rows) // Проходим все ячейки таблицы
						//{
						//	foreach (Word.Cell cellItem in rowItem.Cells) // и записываем все команды стречающиеся там
						//	{
						 
							for(int j = 1; j <= selectedTable.Columns.Count; j++)
							{ 
								int firstIndex = 0, lastIndex = 0; // попутно удаляя все команды

								do //todo переделать исспользуя регулярки
								{
									if (firstIndex < selectedTable.Cell(selectedTable.Rows.Count, j).Range.Text.Length)
										firstIndex = selectedTable.Cell(selectedTable.Rows.Count, j).Range.Text.IndexOf('$', firstIndex);
									if (firstIndex != -1)
									{
										lastIndex = selectedTable.Cell(selectedTable.Rows.Count, j).Range.Text.IndexOf('$', firstIndex + 1);
										tableCommand.Add(new TableCommand(j, selectedTable.Rows.Count,
											selectedTable.Cell(selectedTable.Rows.Count, j).Range.Text.Substring(firstIndex, lastIndex - firstIndex + 1)));
										selectedTable.Cell(selectedTable.Rows.Count, j).Range.Text = selectedTable.Cell(selectedTable.Rows.Count, j).Range.Text.Remove(firstIndex, lastIndex - firstIndex + 1);


									}

								} while (firstIndex != -1);



							}

						//

						//selectedTable.Cell(selectedTable.Rows.Count, 1).Range.Rows.Delete();
						//selectedTable.Rows[tableCommand[0].y].Delete();

						if (tableCommand[0].command.ToUpper() == "$S$")
						{
							int num = 0;
							foreach (Student studentItem in students)
							{
								num++;
								selectedStudent = studentItem; // переделать
								changeSelectedStudent(); // костыль 
								selectedTable.Rows.Add();
								//selectedTable.Rows[selectedTable.Rows.Count].Range.set_Style(selectedTable.Rows[1].Range.get_Style());
								foreach (TableCommand item in tableCommand)
								{
									if (item.command.ToUpper() == "$NUM$")
									{
										selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(num.ToString());
									}
									else
									{
										//selectedTable.Rows[selectedTable.Rows.Count].Cells[item.x].Range.Text += findCommand(item.command);
										selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(findCommand(item.command));   //Text += findCommand(item.command);
									}																						 //selectedTable.Cell.
								}
							}
						}

						// КАК всегда немного костылей

						if (tableCommand[0].command.ToUpper() == "$R$")
						{
							int num = 0;
							foreach (Relative relativeItem in selectedStudent.ListRelatives)
							{
								selectedRelative = relativeItem; // переделать
								selectedTable.Rows.Add();
								num++;
								//selectedTable.Rows[selectedTable.Rows.Count].Range.set_Style(selectedTable.Rows[1].Range.get_Style());
								foreach (TableCommand item in tableCommand)
								{
									if (item.command.ToUpper() == "$NUM$")
									{
										selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(num.ToString());
									}
									else
									{
										//selectedTable.Rows[selectedTable.Rows.Count].Cells[item.x].Range.Text += findCommand(item.command);
										selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(findCommand(item.command));   //Text += findCommand(item.command);
									}																									 //selectedTable.Cell.
								}
							}
						}

						selectedTable.Cell(tableCommand[0].y, 1).Range.Rows.Delete();


					}
				}
				else
				{
					if (range.Text.ToUpper() != "$PHOTO$")
					{
						range.Text = findCommand(range.Text);
					}else
					{
						range.Text = "";
						range.InlineShapes.AddPicture(@"D:\projects\Git\LKS-3.0\LKS 3.0\LKS 3.0\bin\Debug\Image\1.jpg",Range:range);
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
			}else
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

		private string findCommand(string command)
		{
			// Студент
			if (command.ToUpper() == "$FNAME$")
			{
				return selectedStudent.FirstName;
			}

			if (command.ToUpper() == "$MNAME$")
			{
				return selectedStudent.MiddleName;
			}

			if (command.ToUpper() == "$LNAME$")
			{
				return selectedStudent.LastName;
			}

			if (command.ToUpper() == "$FACULTY$")
			{
				return selectedStudent.Faculty;
			}

			if (command.ToUpper() == "$GROUP$")
			{
				return selectedStudent.Group;
			}

			if (command.ToUpper() == "$SPNAME$")
			{
				return selectedStudent.SpecialityName;
			}

			if (command.ToUpper() == "$CONDEDUC$")
			{
				return selectedStudent.ConditionsOfEducation;
			}

			if (command.ToUpper() == "$$AVERSCORE")
			{
				return selectedStudent.AvarageScore;
			}

			if (command.ToUpper() == "$ADDMAI$")
			{
				return selectedStudent.YearOfAddMAI;
			}

			if (command.ToUpper() == "$ENDMAI$")
			{
				return selectedStudent.YearOfEndMAI;
			}

			if (command.ToUpper() == "$ADDMIL$")
			{
				return selectedStudent.YearOfAddVK;
			}

			if (command.ToUpper() == "$ENDMIL$")
			{
				return selectedStudent.YearOfEndVK;
			}

			if (command.ToUpper() == "$NUMORDER$")
			{
				return selectedStudent.NumberOfOrder;
			}

			if (command.ToUpper() == "$DATEORDER$")
			{
				return selectedStudent.DateOfOrder;
			}

			if (command.ToUpper() == "$RECTAL$")
			{
				return selectedStudent.Rectal;
			}

			if (command.ToUpper() == "$BIRTHDAY$")
			{
				return selectedStudent.Birthday;
			}

			if (command.ToUpper() == "$PLACEBIRTH$")
			{
				return selectedStudent.PlaceBirthday;
			}

			if (command.ToUpper() == "$NATION$")
			{
				return selectedStudent.Nationality;
			}

			if (command.ToUpper() == "$HOMEPRONE$")
			{
				return selectedStudent.HomePhone;
			}

			if (command.ToUpper() == "$MOBPHONE$")
			{
				return selectedStudent.MobilePhone;
			}

			if (command.ToUpper() == "$PLACERESID$")
			{
				return selectedStudent.PlaceOfResidence;
			}

			if (command.ToUpper() == "$PLACEREGISTR$")
			{
				return selectedStudent.PlaceOfRegestration;
			}

			if (command.ToUpper() == "$SCHOOL$")
			{
				return selectedStudent.School;
			}

			if (command.ToUpper() == "$RANK$")
			{
				return selectedStudent.Rank;
			}


			if (command.ToUpper() == "$TROOP$")
			{
				return selectedStudent.Troop;
			}

			if (command.ToUpper() == "$INIT$")
			{
				return selectedStudent.initials();
			}



			//
			//БЛОК РОДСТВЕННИКОВ
			//
			if (selectedRelative != null)
			{
				if (command.ToUpper() == "$RELFNAME$")
				{
					return selectedRelative.FirstName;
				}

				if (command.ToUpper() == "$RELMNAME$")
				{
					return selectedRelative.MiddleName;
				}

				if (command.ToUpper() == "$RELLNAME$")
				{
					return selectedRelative.LastName;
				}

				if (command.ToUpper() == "$RELMAIDNAME$")
				{
					return selectedRelative.MaidenName;
				}

				if (command.ToUpper() == "$RELBIRTHDAY$")
				{
					return selectedRelative.Birthday;
				}

				if (command.ToUpper() == "$RELREGISTR$")
				{
					return selectedRelative.PlaceOfRegestration;
				}

				if (command.ToUpper() == "$RELRESIDE$")
				{
					return selectedRelative.PlaceOfResidence;
				}

				if (command.ToUpper() == "$RELMOBIL$")
				{
					return selectedRelative.MobilePhone;
				}

				if (command.ToUpper() == "$RELRELATION$")
				{
					return selectedRelative.RelationDegree;
				}

				if (command.ToUpper() == "$RELHEALTH$")
				{
					return selectedRelative.HealthStatus;
				}

				if (command.ToUpper() == "$RELINIT")
				{
					return selectedRelative.initials();
				}
			}
			//Мать
			if (selectedStudentMather != null)
			{
				if (command.ToUpper() == "$MATHFNAME$")
				{
					return selectedStudentMather.FirstName;
				}

				if (command.ToUpper() == "$MATHMNAME$")
				{
					return selectedStudentMather.MiddleName;
				}

				if (command.ToUpper() == "$MATHLNAME$")
				{
					return selectedStudentMather.LastName;
				}

				if (command.ToUpper() == "$MATHMAIDNAME$")
				{
					return selectedStudentMather.MaidenName;
				}

				if (command.ToUpper() == "$MATHBIRTHDAY$")
				{
					return selectedStudentMather.Birthday;
				}

				if (command.ToUpper() == "$MATHREGISTR$")
				{
					return selectedStudentMather.PlaceOfRegestration;
				}

				if (command.ToUpper() == "$MATHRESIDE$")
				{
					return selectedStudentMather.PlaceOfResidence;
				}

				if (command.ToUpper() == "$MATHMOBIL$")
				{
					return selectedStudentMather.MobilePhone;
				}

				if (command.ToUpper() == "$MATHRELATION$")
				{
					return selectedStudentMather.RelationDegree;
				}

				if (command.ToUpper() == "$MATHHEALTH$")
				{
					return selectedStudentMather.HealthStatus;
				}

				if (command.ToUpper() == "$MATHINIT")
				{
					return selectedStudentMather.initials();
				}
			}
			// ОТЕЦ(ОТЧИМ)
			if (selectedStudentFather != null)
			{
				if (command.ToUpper() == "$FATHFNAME$")
				{
					return selectedStudentFather.FirstName;
				}

				if (command.ToUpper() == "$FATHMNAME$")
				{
					return selectedStudentFather.MiddleName;
				}

				if (command.ToUpper() == "$FATHLNAME$")
				{
					return selectedStudentFather.LastName;
				}

				if (command.ToUpper() == "$FATHMAIDNAME$")
				{
					return selectedStudentFather.MaidenName;
				}

				if (command.ToUpper() == "$FATHBIRTHDAY$")
				{
					return selectedStudentFather.Birthday;
				}

				if (command.ToUpper() == "$FATHREGISTR$")
				{
					return selectedStudentFather.PlaceOfRegestration;
				}

				if (command.ToUpper() == "$FATHRESID$")
				{
					return selectedStudentFather.PlaceOfResidence;
				}

				if (command.ToUpper() == "$FATHMOBIL$")
				{
					return selectedStudentFather.MobilePhone;
				}

				if (command.ToUpper() == "$FATHRELATION$")
				{
					return selectedStudentFather.RelationDegree;
				}

				if (command.ToUpper() == "$FATHHEALTH$")
				{
					return selectedStudentFather.HealthStatus;
				}

				if (command.ToUpper() == "$FATHINIT")
				{
					return selectedStudentFather.initials();
				}
			}

			// Взвод
			if (selectedTrop != null)
			{
				if (command.ToUpper() == "$TRNUM$")
				{
					return selectedTrop.NumberTroop;
				}

				if (command.ToUpper() == "$TRCOUNT")
				{
					return selectedTrop.StaffCount.ToString();
				}

				if (command.ToUpper() == "$TPRFNAME$")
				{
					return selectedTrop.ResponsiblePrepod.FirstName;
				}

				if (command.ToUpper() == "$TPRMNAME$")
				{
					return selectedTrop.ResponsiblePrepod.MiddleName;
				}

				if (command.ToUpper() == "$TPRLNAME$")
				{
					return selectedTrop.ResponsiblePrepod.LastName;
				}

				if (command.ToUpper() == "$TPRCOOLNESS$")
				{
					return selectedTrop.ResponsiblePrepod.Coolness;
				}

				if (command.ToUpper() == "$TPRINIT")
				{
					return selectedTrop.ResponsiblePrepod.initials();
				}

				// Командир взвода

				if (command.ToUpper() == "$TCOMFNAME$")
				{
					return selectedTrop.PlatoonCommander.FirstName;
				}

				if (command.ToUpper() == "$TCOMMNAME$")
				{
					return selectedTrop.PlatoonCommander.MiddleName;
				}

				if (command.ToUpper() == "$TCOMLNAME$")
				{
					return selectedTrop.PlatoonCommander.LastName;
				}

				if (command.ToUpper() == "$TCOMFACULTY$")
				{
					return selectedTrop.PlatoonCommander.Faculty;
				}

				if (command.ToUpper() == "$TCOMGROUP$")
				{
					return selectedTrop.PlatoonCommander.Group;
				}

				if (command.ToUpper() == "$TCOMSPNAME$")
				{
					return selectedTrop.PlatoonCommander.SpecialityName;
				}

				if (command.ToUpper() == "$TCOMCONDEDUC$")
				{
					return selectedTrop.PlatoonCommander.ConditionsOfEducation;
				}

				if (command.ToUpper() == "$TCOM$AVERSCORE")
				{
					return selectedTrop.PlatoonCommander.AvarageScore;
				}

				if (command.ToUpper() == "$TCOMADDMAI$")
				{
					return selectedTrop.PlatoonCommander.YearOfAddMAI;
				}

				if (command.ToUpper() == "$TCOMENDMAI$")
				{
					return selectedTrop.PlatoonCommander.YearOfEndMAI;
				}

				if (command.ToUpper() == "$TCOMADDMIL$")
				{
					return selectedTrop.PlatoonCommander.YearOfAddVK;
				}

				if (command.ToUpper() == "$TCOMENDMIL$")
				{
					return selectedTrop.PlatoonCommander.YearOfEndVK;
				}

				if (command.ToUpper() == "$TCOMNUMORDER$")
				{
					return selectedTrop.PlatoonCommander.NumberOfOrder;
				}

				if (command.ToUpper() == "$TCOMDATEORDER$")
				{
					return selectedTrop.PlatoonCommander.DateOfOrder;
				}

				if (command.ToUpper() == "$TCOMRECTAL$")
				{
					return selectedTrop.PlatoonCommander.Rectal;
				}

				if (command.ToUpper() == "$TCOMBIRTHDAY$")
				{
					return selectedTrop.PlatoonCommander.Birthday;
				}

				if (command.ToUpper() == "$TCOMPLACEBIRTH$")
				{
					return selectedTrop.PlatoonCommander.PlaceBirthday;
				}

				if (command.ToUpper() == "$TCOMNATION$")
				{
					return selectedTrop.PlatoonCommander.Nationality;
				}

				if (command.ToUpper() == "$TCOMHOMEPRONE$")
				{
					return selectedTrop.PlatoonCommander.HomePhone;
				}

				if (command.ToUpper() == "$TCOMMOBPHONE$")
				{
					return selectedTrop.PlatoonCommander.MobilePhone;
				}

				if (command.ToUpper() == "$TCOMPLACERESID$")
				{
					return selectedTrop.PlatoonCommander.PlaceOfResidence;
				}

				if (command.ToUpper() == "$TCOMPLACEREGISTR$")
				{
					return selectedTrop.PlatoonCommander.PlaceOfRegestration;
				}

				if (command.ToUpper() == "$TCOMSCHOOL$")
				{
					return selectedTrop.PlatoonCommander.School;
				}

				if (command.ToUpper() == "$TCOMRANK$")
				{
					return selectedTrop.PlatoonCommander.Rank;
				}

				if (command.ToUpper() == "$TCOMTROOP$")
				{
					return selectedTrop.PlatoonCommander.Troop;
				}

				if (command.ToUpper() == "$TCOMINIT")
				{
					return selectedTrop.PlatoonCommander.initials();
				}
			}



			return null;
		}

		void changeTroop ()
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
