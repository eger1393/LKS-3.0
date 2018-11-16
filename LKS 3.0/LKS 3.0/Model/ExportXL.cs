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

//using WORD = Microsoft.Office.Interop.Word; // исспользую для печати файла

namespace LKS_3._0.Model
{
	class ExportXL
	{
		Troop troop;

		public ExportXL(string fileName, ref ApplicationContext temp_DataBase)
		{
			troop = new Troop();
			troop.Students = new System.ComponentModel.BindingList<Student>();
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog(); // создали новое диалоговое окно
			dlg.Filter = "Word files (*.docx)|*.docx";
			dlg.ShowDialog();
			using (WordprocessingDocument doc = WordprocessingDocument.Open(dlg.FileName, true)) // открыли документ
			{
				foreach (Table table in doc.MainDocumentPart.Document.Body.Elements<Table>()) // проходим все таблицы
				{
					foreach (TableRow row in table.Elements<TableRow>())
					{
						var cellList = row.Elements<TableCell>().ToList();
						troop.Students.Add(new Student()
						{
							MiddleName = cellList[0].InnerText,
							FirstName = cellList[1].InnerText,
							LastName = cellList[2].InnerText,
							Birthday = cellList[3].InnerText,
							PlaceOfRegestration = cellList[4].InnerText,
							HomePhone = cellList[5].InnerText,
							MobilePhone = cellList[6].InnerText,
							VkName = cellList[7].InnerText,
							YearOfAddMAI = cellList[8].InnerText,
							YearOfEndMAI = cellList[9].InnerText,
							InstGroup = cellList[10].InnerText,
							Faculty = cellList[11].InnerText,
							Kurs = 4
						});
					}
				}
			}
			temp_DataBase.Troops.Add(troop);
			temp_DataBase.SaveChanges();
		}
	}
}
