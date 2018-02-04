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
					if(!table.Descendants<SdtElement>().Any()) // проверка на наличие закладок в текущей таблице
					{
						continue; 
					}

					foreach (TableRow row in table.Elements<TableRow>())
					{
						if(row.Descendants<SdtElement>().Any()) // проверка на наличие закладок в строке
						{
							for(int i = 0; i < students.Count; i++)
							{
								TableRow tempRow = row.Clone() as TableRow; // создали копию строки
								selectedStudent = students[i];
								changeSelectedStudent();
								// модифицировал копию строки
								foreach (SdtElement formattedText in tempRow.Descendants<SdtElement>().ToList())
								{
									string valueCommand = findCommand(formattedText.Descendants<SdtAlias>().First().Val);
									if (valueCommand != "false")
									{
										SdtContentRun contentRun = formattedText.GetFirstChild<SdtContentRun>(); // ссылка на контент
										Run tempRun = contentRun.FirstChild.Clone() as Run; // скопировал первого потомка
										(tempRun.LastChild as Text).Text = valueCommand; // задаю нужный текст
										formattedText.Parent.ReplaceChild(tempRun, formattedText); // взял родителя закладки,
																								   // и заменил закладку обычным текстом
									}
								}

								table.AppendChild(tempRow); // добавили временую стороку к таблице
							} // закончили создание таблицы
							row.Parent.RemoveChild(row); // удалили немодифицированную строку
							break; // закончили работу с таблицей
						}

					}
					//foreach (TableCell cell in table.Descendants<TableCell>()) // для каждой получаем список ячеек
					//{
					
						//foreach (SdtElement formattedText in cell.Descendants<SdtElement>().ToList())
						//{
						//	string command = formattedText.Descendants<SdtAlias>().First().Val;
						//	if (findCommand(command) != "false")
						//	{
						//		tableCommand.Add(
						//			new TableCommand(1, 1, command));
						//	}
						//}
					//}
				}

				// проходим по всем элементам "форматированный текст"(далее просто "закладка")
				// и сверяем имя закладки со списком команд
				// как обычно здесь есть немного магии (без toList может работать не правильно)
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
		}

		private string findCommand(string command)
		{
			if (command.ToUpper() == "$НС$")
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
					return selectedTrop.Day;
				}

				if (command.ToUpper() == "$ВЗВУС$")
				{
					// TODO ВУС
					return "";
				}

				if (selectedTrop.ResponsiblePrepod != null)
				{
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
				}

				// Командир взвода
				if (selectedTrop.PlatoonCommander != null)
				{

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
			}

			if (command.ToUpper() == "$С$" ||
				command.ToUpper() == "$Р$" ||
				command.ToUpper() == "$О$")
			{
				return "";
			}

			return "false";
			//TODO
			if (command.Length > 2) // TODO костыль
			{
				return command.Substring(1, command.Length - 2);
			}
			else
			{
				return "";
			}
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
