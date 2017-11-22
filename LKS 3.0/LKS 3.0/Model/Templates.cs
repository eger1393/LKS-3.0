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

			if (Students == null && troops != null)
			{
				this.students = troops.First().ListStudents.ToList();
			}
			else
			{
				this.students = Students;
			}
				selectedStudent = students.First(); // устанавливаем выбранного стуента
				changeSelectedStudent(); // меняем мать и отца студента
			System.IO.File.Copy(fileName, @"D:\projects\Git\LKS-3.0\LKS 3.0\LKS 3.0\bin\Debug\Templates\123.docx", true);



			Word.Application appDoc = new Word.Application(); // создали новый вордовский процесс
			Word.Document doc = appDoc.Documents.Open(@"D:\projects\Git\LKS-3.0\LKS 3.0\LKS 3.0\bin\Debug\Templates\123.docx", ReadOnly: false); // открыли документ
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


						foreach (Word.Row rowItem in selectedTable.Rows) // Проходим все ячейки таблицы
						{
							foreach (Word.Cell cellItem in rowItem.Cells) // и записываем все команды стречающиеся там
							{
								int firstIndex = 0, lastIndex = 0; // попутно удаляя все команды

								do //todo переделать исспользуя регулярки
								{
									if (firstIndex < cellItem.Range.Text.Length)
										firstIndex = cellItem.Range.Text.IndexOf('$', firstIndex);
									if (firstIndex != -1)
									{
										lastIndex = cellItem.Range.Text.IndexOf('$', firstIndex + 1);
										tableCommand.Add(new TableCommand(cellItem.ColumnIndex, cellItem.RowIndex,
											cellItem.Range.Text.Substring(firstIndex, lastIndex - firstIndex + 1)));
										cellItem.Range.Text = cellItem.Range.Text.Remove(firstIndex, lastIndex - firstIndex + 1);


									}

								} while (firstIndex != -1);



							}
						}
						//

						selectedTable.Rows[tableCommand[0].y].Delete();

						if (tableCommand[0].command.ToUpper() == "$S$")
						{
							foreach (Student studentItem in students)
							{
								selectedStudent = studentItem; // переделать
								changeSelectedStudent(); // костыль 
								selectedTable.Rows.Add();
								//selectedTable.Rows[selectedTable.Rows.Count].Range.set_Style(selectedTable.Rows[1].Range.get_Style());
								foreach (TableCommand item in tableCommand)
								{
									//selectedTable.Rows[selectedTable.Rows.Count].Cells[item.x].Range.Text += findCommand(item.command);
									selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(findCommand(item.command));   //Text += findCommand(item.command);
																																		 //selectedTable.Cell.
								}
							}
						}

						// КАК всегда немного костылей

						if (tableCommand[0].command.ToUpper() == "$R$")
						{
							foreach (Relative relativeItem in selectedStudent.ListRelatives)
							{
								selectedRelative = relativeItem; // переделать
								selectedTable.Rows.Add();
								//selectedTable.Rows[selectedTable.Rows.Count].Range.set_Style(selectedTable.Rows[1].Range.get_Style());
								foreach (TableCommand item in tableCommand)
								{
									//selectedTable.Rows[selectedTable.Rows.Count].Cells[item.x].Range.Text += findCommand(item.command);
									selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(findCommand(item.command));   //Text += findCommand(item.command);
																																		 //selectedTable.Cell.
								}
							}
						}

						

					}
				}
				else
				{
					range.Text = findCommand(range.Text);
					range.Find.ClearFormatting();
					range = doc.Content;
				}
			}


			doc.SaveAs(@"D:\projects\Git\LKS-3.0\LKS 3.0\LKS 3.0\bin\Debug\Templates\123.docx");
			doc.Close();
			appDoc.Quit();
			System.Windows.MessageBox.Show("ГОТОВО!");

		}

		private string findCommand(string command)
		{

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




			//
			//БЛОК РОДСТВЕННИКОВ
			//

			if (command.ToUpper() == "$RELFNAME$")
			{
				return selectedStudentMather.FirstName;
			}

			if (command.ToUpper() == "$RELMNAME$")
			{
				return selectedStudentMather.MiddleName;
			}

			if (command.ToUpper() == "$RELLNAME$")
			{
				return selectedStudentMather.LastName;
			}

			if (command.ToUpper() == "$RELMAIDNAME$")
			{
				return selectedStudentMather.MaidenName;
			}

			if (command.ToUpper() == "$RELBIRTHDAY$")
			{
				return selectedStudentMather.Birthday;
			}

			if (command.ToUpper() == "$RELREGISTR$")
			{
				return selectedStudentMather.PlaceOfRegestration;
			}

			if (command.ToUpper() == "$RELRESIDE$")
			{
				return selectedStudentMather.PlaceOfResidence;
			}

			if (command.ToUpper() == "$RELMOBIL$")
			{
				return selectedStudentMather.MobilePhone;
			}

			if (command.ToUpper() == "$RELRELATION$")
			{
				return selectedStudentMather.RelationDegree;
			}

			if (command.ToUpper() == "$RELHEALTH$")
			{
				return selectedStudentMather.HealthStatus;
			}

			//Мать

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

			// ОТЕЦ(ОТЧИМ)

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

			// Взвод

			if(command.ToUpper() == "$TRNUM$")
			{
				return selectedTrop.NumberTroop;
			}

			if (command.ToUpper() == "$TPRFNAME$")
			{
				return selectedTrop.responsiblePrepod.FirstName;
			}

			if (command.ToUpper() == "$TPRMNAME$")
			{
				return selectedTrop.responsiblePrepod.MiddleName;
			}

			if (command.ToUpper() == "$TPRLNAME$")
			{
				return selectedTrop.responsiblePrepod.LastName;
			}

			if (command.ToUpper() == "$TPRCOOLNESS$")
			{
				return selectedTrop.responsiblePrepod.Coolness;
			}

			// Командир взвода

			if (command.ToUpper() == "$TCOMFNAME$")
			{
				return selectedTrop.platoonCommander.FirstName;
			}

			if (command.ToUpper() == "$TCOMMNAME$")
			{
				return selectedTrop.platoonCommander.MiddleName;
			}

			if (command.ToUpper() == "$TCOMLNAME$")
			{
				return selectedTrop.platoonCommander.LastName;
			}

			if (command.ToUpper() == "$TCOMFACULTY$")
			{
				return selectedTrop.platoonCommander.Faculty;
			}

			if (command.ToUpper() == "$TCOMGROUP$")
			{
				return selectedTrop.platoonCommander.Group;
			}

			if (command.ToUpper() == "$TCOMSPNAME$")
			{
				return selectedTrop.platoonCommander.SpecialityName;
			}

			if (command.ToUpper() == "$TCOMCONDEDUC$")
			{
				return selectedTrop.platoonCommander.ConditionsOfEducation;
			}

			if (command.ToUpper() == "$TCOM$AVERSCORE")
			{
				return selectedTrop.platoonCommander.AvarageScore;
			}

			if (command.ToUpper() == "$TCOMADDMAI$")
			{
				return selectedTrop.platoonCommander.YearOfAddMAI;
			}

			if (command.ToUpper() == "$TCOMENDMAI$")
			{
				return selectedTrop.platoonCommander.YearOfEndMAI;
			}

			if (command.ToUpper() == "$TCOMADDMIL$")
			{
				return selectedTrop.platoonCommander.YearOfAddVK;
			}

			if (command.ToUpper() == "$TCOMENDMIL$")
			{
				return selectedTrop.platoonCommander.YearOfEndVK;
			}

			if (command.ToUpper() == "$TCOMNUMORDER$")
			{
				return selectedTrop.platoonCommander.NumberOfOrder;
			}

			if (command.ToUpper() == "$TCOMDATEORDER$")
			{
				return selectedTrop.platoonCommander.DateOfOrder;
			}

			if (command.ToUpper() == "$TCOMRECTAL$")
			{
				return selectedTrop.platoonCommander.Rectal;
			}

			if (command.ToUpper() == "$TCOMBIRTHDAY$")
			{
				return selectedTrop.platoonCommander.Birthday;
			}

			if (command.ToUpper() == "$TCOMPLACEBIRTH$")
			{
				return selectedTrop.platoonCommander.PlaceBirthday;
			}

			if (command.ToUpper() == "$TCOMNATION$")
			{
				return selectedTrop.platoonCommander.Nationality;
			}

			if (command.ToUpper() == "$TCOMHOMEPRONE$")
			{
				return selectedTrop.platoonCommander.HomePhone;
			}

			if (command.ToUpper() == "$TCOMMOBPHONE$")
			{
				return selectedTrop.platoonCommander.MobilePhone;
			}

			if (command.ToUpper() == "$TCOMPLACERESID$")
			{
				return selectedTrop.platoonCommander.PlaceOfResidence;
			}

			if (command.ToUpper() == "$TCOMPLACEREGISTR$")
			{
				return selectedTrop.platoonCommander.PlaceOfRegestration;
			}

			if (command.ToUpper() == "$TCOMSCHOOL$")
			{
				return selectedTrop.platoonCommander.School;
			}

			if (command.ToUpper() == "$TCOMRANK$")
			{
				return selectedTrop.platoonCommander.Rank;
			}

			if (command.ToUpper() == "$TCOMTROOP$")
			{
				return selectedTrop.platoonCommander.Troop;
			}




			return null;
		}

		void changeTroop ()
		{
			students = selectedTrop.ListStudents.ToList();
		}

		void changeSelectedStudent()
		{
			selectedStudentMather = null;
			selectedStudentFather = null;
			if (selectedStudent.ListRelatives != null)
			{
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
