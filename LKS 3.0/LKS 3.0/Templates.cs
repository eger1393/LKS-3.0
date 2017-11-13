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
		 private List<string> commandArray = new List<string>()
		{
			"$FName$",
			"$MName$",
			"$LName$",
			"$Troop$",
			"$Group$"
		};
		//private static Dictionary<string, string> commandArray = new Dictionary<string, string>()

		IEnumerable<Student> students;
		Student selectedStudent;
		//public Templates(IEnumerable<Student> students)
		//{
		//	this.students = students;

		//	Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog(); // создали новое диалоговое окно
		//	dlg.Filter = "Word files (*.doc, *.docx)|*.doc; *.docx"; // добавили фильтер
		//	if (dlg.ShowDialog() == true) // запустили окно
		//	{
		//		Word._Application oWord = new Word.Application(); // WINWORD.EXE 


		//		Word.Document oDoc = oWord.Documents.Add(dlg.FileName);






		//		//oDoc.Bookmarks["FName"].Range.Text = students.ElementAt(1).FirstName;
		//		//oDoc.Bookmarks["MName"].Range.Text = students.ElementAt(1).MiddleName;
		//		//Microsoft.Win32.SaveFileDialog saveDlg = new Microsoft.Win32.SaveFileDialog();
		//		//saveDlg.Filter = "Word files (*.doc, *.docx)|*.doc; *.docx";
		//		//if (saveDlg.ShowDialog() == true)
		//		//{
		//		//	oDoc.SaveAs(FileName: saveDlg.FileName);
		//		//}

		//		oDoc.SaveAs(FileName: @"D:\projects\Git\LKS-3.0\LKS 3.0\LKS 3.0\bin\Debug\Templates\123.docx");

		//		oDoc.Close();
		//		oWord.Quit();
		//	}
		//}


		public Templates(IEnumerable<Student> students)
		{
			this.students = students;
			
			selectedStudent = students.ElementAt(1);
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog(); // создали новое диалоговое окно
			dlg.Filter = "Word files (*.doc, *.docx)|*.doc; *.docx"; // добавили фильтер
			if (dlg.ShowDialog() == true) // запустили окно
			{
				//File.Delete(@".\Templates\123.docx");
				//File.Copy(dlg.FileName, @".\Templates\123.docx");

				Word.Application appDoc = new Word.Application(); // создали новый вордовский процесс
				Word.Document doc = appDoc.Documents.Open(dlg.FileName, ReadOnly: false); // открыли документ
				Word.Range range = doc.Content; // запихнули весь текст из документа в range
				
				
				while (range.Find.Execute("$?{1;20}$", MatchWildcards: true, Forward: true)) // ищем команды
				{
					if (range.Text == "$NTbl$") // если встретили начало таблицы 
					{
						Word.Table selectedTable = null;
						for (int i = 1; i <= doc.Tables.Count; i++) // ищем среди всех таблиц нужную 
						{
							Word.Range item = doc.Tables[i].Range; // надо переделать сейчас работатет не правильно
							if (item.Find.Execute("$NTbl$", ReplaceWith: "", Forward: true))
							{
								selectedTable = doc.Tables[i];
								break;
							}
						}
						if (selectedTable != null) // нужная таблица найдена
						{
							List<TableCommand> tableCommand = new List<TableCommand>();

							//Word.Range findRange = selectedTable.Range;
							//while (findRange.Find.Execute("$?{1;20}$", MatchWildcards: true, Forward: true))
							//{

							//	System.Windows.MessageBox.Show(findRange.Text);

							//	findRange.Text = "";
							//	//findRange = item.Range;
							//}


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

											//System.Windows.MessageBox.Show(cellItem.Range.Text);

											//firstIndex = ++lastIndex;
										}

									} while (firstIndex != -1);

									//Word.Range findRange = selectedTable.Cell(cellItem.RowIndex, cellItem.ColumnIndex).Range;
									//System.Windows.MessageBox.Show(findRange.Text);
									//findRange.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindStop
									//while(findRange.Find.Execute("$?{1;20}$",Wrap: Word.WdFindWrap.wdFindStop, MatchWildcards: true, Replace: Word.WdReplace.wdReplaceNone))
									//	System.Windows.MessageBox.Show(findRange.Text + "   Ячейка: " + cellItem.Range.Text);
									//findRange = item.Range;

								}
							}
							//
							
							foreach (Student studentItem in students)
							{
								if(studentItem == students.First())
								{
									selectedTable.Rows[tableCommand[0].y].Delete();
								}
								selectedStudent = studentItem; // переделать
								selectedTable.Rows.Add();
								foreach(TableCommand item in tableCommand)
								{
									selectedTable.Rows[selectedTable.Rows.Count].Cells[item.x].Range.Text += findCommand(item.command);
								}
							}
							//selectedTable.Rows[tableCommand[0].y].Delete();
						}
					}
					else
					{
						range.Text = findCommand(range.Text);
						range.Find.ClearFormatting();
						range = doc.Content;
					}
				}

				//appDoc.Selection.Find.Execute("$*$", MatchWildcards: true, Forward: true);
				//appDoc.Selection.Text = "11234";
				//System.Windows.MessageBox.Show(appDoc.Selection.Text);
				doc.SaveAs(@"D:\projects\Git\LKS-3.0\LKS 3.0\LKS 3.0\bin\Debug\Templates\123.docx");
				doc.Close();
				appDoc.Quit();
				System.Windows.MessageBox.Show("ГОТОВО!");
			}
		}

		private string findCommand(string command)
		{
			if(command == commandArray[0])
			{
				return selectedStudent.FirstName;
			}

			if (command == commandArray[1])
			{
				return selectedStudent.MiddleName;
			}

			if (command == commandArray[2])
			{
				return selectedStudent.LastName;
			}

			if (command == commandArray[3])
			{
				return selectedStudent.Troop;
			}

			if (command == commandArray[4])
			{
				return selectedStudent.Group;
			}

			return null;
		}
	}
}
