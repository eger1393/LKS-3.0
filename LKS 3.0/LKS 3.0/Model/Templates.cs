using System;
using System.Collections.Generic;
using System.Linq;
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
		
		IEnumerable<Student> students;
		Student selectedStudent;



		public Templates(IEnumerable<Student> students)
		{
			this.students = students;
						
			selectedStudent = students.ElementAt(1);
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog(); // создали новое диалоговое окно
			dlg.Filter = "Word files (*.doc, *.docx)|*.doc; *.docx"; // добавили фильтер
			if (dlg.ShowDialog() == true) // запустили окно
			{
				

				Word.Application appDoc = new Word.Application(); // создали новый вордовский процесс
				Word.Document doc = appDoc.Documents.Open(dlg.FileName, ReadOnly: false); // открыли документ
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
										if(firstIndex < cellItem.Range.Text.Length)
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
								
							
							foreach (Student studentItem in students)
							{
								selectedStudent = studentItem; // переделать
								selectedTable.Rows.Add();
								//selectedTable.Rows[selectedTable.Rows.Count].Range.set_Style(selectedTable.Rows[1].Range.get_Style());
								foreach(TableCommand item in tableCommand)
								{
									//selectedTable.Rows[selectedTable.Rows.Count].Cells[item.x].Range.Text += findCommand(item.command);
									selectedTable.Cell(selectedTable.Rows.Count, item.x).Range.InsertAfter(findCommand(item.command));   //Text += findCommand(item.command);
									//selectedTable.Cell.
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

			


			if (command.ToUpper() == "$TROOP$")
			{
				return selectedStudent.Troop;
			}


			return null;
		}
	}
}
