using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Data.Entity;
using System.Windows;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Data.Odbc;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.OleDb;
using LKS_3._0.Model;

namespace LKS_3._0
{
   
    public class ApplicationViewModel : INotifyPropertyChanged, IDisposable
    {
        public ApplicationContext DataBaseContext;
		bool connect, database_officer;

        private RelayCommand addCommand,
            createReportCommand,
            findCommand,
            editCommand,
            deleteCommand,
            saveChangeCommand,
            checkPassCommand,
            editPrepodsCommand,
            showTraineesCommand,
            showDetachedCommand,
            showNaSboriCommand,
            showPastSboriCommand,
            showAllCommand,
            addNoteCommand,
            troopCheck,
            newSboricommand,
            editTroopCommand,
            changeRankCommand,
            exportCommand,
			dataImportFromXL,
			infoSboriCommand,
            closeAllWordFile,
            changeKursCommand,
            isSuspendedСommand,
            createReportUniversityCommand,
            ordersCommand,
            showInfoAdministrationsMillKaf,
            settingDB,
            uploadDB;

        private Student selectedStudent;
        private string ValueFind_T, ValueFind_G, ValueFind_M, ValueFind_R;
        private Troop selectedTroop;
        private string selectTroopNumber;
        private BindingList<Student> students;
        private BindingList<Troop> troops;
        private BindingList<string> list_Troop, list_Mname, list_Rank, list_Group;
        string maev_path = Environment.CurrentDirectory + "/maev.mdb";


        public string SelectedValueFind_T
        {
            get
            {
                return ValueFind_T;
            }
            set
            {
                ValueFind_T = value;
                if (value == null)
                {
                    Students = DataBaseContext.Students.Local.ToBindingList();
                }

                //List_Group = new BindingList<string>(DataBaseContext.Students.Local.Where(u => u.Troop.FirstOrDefault(z => z.SboriTroop == false).NumberTroop == value).Select(u => u.InstGroup).Distinct().ToList());

				
			}

        }
        public string SelectedValueFind_G
        {
            get
            {
                return ValueFind_G;
            }
            set
            {
                ValueFind_G = value;
                if (value == null)
                {
                    Students = DataBaseContext.Students.Local.ToBindingList();
                }
                //List_Mname = new BindingList<string>(DataBaseContext.Students.Local.Where(u => u.InstGroup == value).Select(u => u.MiddleName).Distinct().ToList());
                
            }
        }
        public string SelectedValueFind_M
                        {
            get
            {
                return ValueFind_M;
                        }
            set
                        {
                ValueFind_M = value;
                if (value == null)
                {
                    Students = DataBaseContext.Students.Local.ToBindingList();
                        }
                
            }
        }
        public string SelectedValueFind_R
                        {
            get
            {
                return ValueFind_R;
                        }
            set
                        {
                ValueFind_R = value;
                if (value == null)
                {
                    Students = DataBaseContext.Students.Local.ToBindingList();
                        }
                
                }
        }

		public BindingList<string> List_Troop
		{
			get
			{
				return list_Troop;
			}
			set
			{
				list_Troop = value;
				OnPropertyChanged();
			}
		}
		public BindingList<string> List_Mname
		{
			get
			{
				return list_Mname;
			}
			set
			{
				list_Mname = value;
				OnPropertyChanged();
			}
		}
		public BindingList<string> List_Rank
		{
			get
			{
				return list_Rank;
			}
			set
			{
				list_Rank = value;
				OnPropertyChanged();
			}
		}
		public BindingList<string> List_Group
		{
			get
			{
				return list_Group;
			}
			set
			{
				list_Group = value;
				OnPropertyChanged();
			}
		}


		public Student SelectedStudent
		{
			get
			{
				return selectedStudent;
			}
			set
			{
				selectedStudent = value;
				OnPropertyChanged();
			}
		}

		public Troop SelectedTroop
		{
			get
			{
				return selectedTroop;
			}
			set
			{
				selectedTroop = value;
				OnPropertyChanged();
			}
		}
		public string SelectTroopNumber
		{
			get
			{
				return selectTroopNumber;
			}
			set
			{
				selectTroopNumber = value;
				OnPropertyChanged();
			}
		}
		public BindingList<Student> Students
		{
			get
			{
				return students;
			}
			set
			{
				students = value;
				OnPropertyChanged();
			}
		}

		public BindingList<Troop> Troops
		{
			get
			{
				return troops;
			}
			set
			{
				troops = value;
				OnPropertyChanged();
			}
		}

        private void Update_List()
        {
            List_Troop = new BindingList<string>(Troops.Where(u => u.SboriTroop == false).Select(u => u.NumberTroop).ToList());

            List_Group = new BindingList<string>(Students.Select(u => u.InstGroup).Distinct().ToList());

            List_Mname = new BindingList<string>(Students.Select(u => u.MiddleName).Distinct().ToList());

            List_Rank = new BindingList<string>(Students.Select(u => u.Rank).Distinct().ToList());

		}

		public RelayCommand CreateReportUniversityCommand
		{
			get
			{
                try
                {
                    return createReportUniversityCommand ??
                    (createReportUniversityCommand = new RelayCommand(obj =>
                    {
                        View.CreateReportUniversity Wind = new View.CreateReportUniversity(
                            new ViewModel.CreateReportUniversityViewModel(ref DataBaseContext, Students, Troops));
                        Wind.Show();
                    }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Неизвестная ошибка! Перезапустите программу", "Внимание!");
                    return null;
                }
				
			}
		}

		public RelayCommand CloseAllWordFile
		{
			get
			{
                try { 
				return closeAllWordFile ??
					(closeAllWordFile = new RelayCommand(obj =>
					{
						System.Diagnostics.Process Process2 = null;
						Process2 = System.Diagnostics.Process.Start(@"clean.bat");
					}, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка! Закройте окна Microsoft Word вручную", "Внимание!");
                    return null;
                }
            }
		}
        public RelayCommand SettingDB
        {
            get
            {
                return settingDB ??
                    (settingDB = new RelayCommand(obj =>
                    {
                        View.WindowSetting Wind = new View.WindowSetting();
                        Wind.Show();
                    }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }
        public RelayCommand UploadDB
        {
            get
            {
                return uploadDB ??
                    (uploadDB = new RelayCommand(obj =>
                    {
                        DataBaseContext.Dispose();
                        Connect_DB(connect, database_officer);
                    }));
            }
        }

        public RelayCommand ShowAllCommand
        {
            get
            {
                return showAllCommand ??
                 (showAllCommand = new RelayCommand(obj =>
                 {
                     Students = DataBaseContext.Students.Local.ToBindingList();
                     SelectedTroop = new Troop();
                     List_Troop = null;
                     List_Group = null;
                     List_Mname = null;
                     List_Rank = null;
                     SelectTroopNumber = null;
                     Update_List();
                 }));
            }
        }
        public RelayCommand ShowTraineesCommand
        {
            get
            {
                return showTraineesCommand ??
                 (showTraineesCommand = new RelayCommand(obj =>
                 {
                     if(SelectedTroop.NumberTroop !=  null)
                     {
                         Students = new BindingList<Student>(SelectedTroop.Students.Where(u => u.Status == "Обучается").ToList());
                     }
                     else
                     {
                         Students = new BindingList<Student>(DataBaseContext.Students.Local.Where(u => u.Status == "Обучается").ToList());
                     }
                 }));
            }
        }
        public RelayCommand ShowDetachedCommand
        {
            get
            {
                return showDetachedCommand ??
                 (showDetachedCommand = new RelayCommand(obj =>
                 {
                     if (SelectedTroop.NumberTroop != null)
                     {
                         Students = new BindingList<Student>(SelectedTroop.Students.Where(u => u.Status == "Отстранен").ToList());
                     }
                     else
                     {
                         Students = new BindingList<Student>(DataBaseContext.Students.Local.Where(u => u.Status == "Отстранен").ToList());
                     }
                 }));
            }
        }
        public RelayCommand ShowNaSboriCommand
        {
            get
            {
                return showNaSboriCommand ??
                 (showNaSboriCommand = new RelayCommand(obj =>
                 {
                     if (SelectedTroop.NumberTroop != null)
                     {
                         Students = new BindingList<Student>(SelectedTroop.Students.Where(u => u.Status == "На сборах").ToList());
                     }
                     else
                     {
                         Students = new BindingList<Student>(DataBaseContext.Students.Local.Where(u => u.Status == "На сборах").ToList());
                     }
                 }));
            }
        }

		public RelayCommand ShowInfoAdministrationsMillKaf
		{
			get
			{
				return showInfoAdministrationsMillKaf ??
					(showInfoAdministrationsMillKaf = new RelayCommand(obj =>
					{
						LKS_3._0.View.InfoAdministrationMilKaf Info = new View.InfoAdministrationMilKaf(ref DataBaseContext);
                        if (Info.ShowDialog() == true)
                        {

						}

					}, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
			}
		}

		public RelayCommand ShowPastSboriCommand
        {
            get
            {
                return showPastSboriCommand ??
                 (showPastSboriCommand = new RelayCommand(obj =>
                 {
                     if (SelectedTroop.NumberTroop != null)
                     {
                         Students = new BindingList<Student>(SelectedTroop.Students.Where(u => u.Status == "Прошел сборы").ToList());
                     }
                     else
                     {
                         Students = new BindingList<Student>(DataBaseContext.Students.Local.Where(u => u.Status == "Прошел сборы").ToList());
                     }
                 }));
            }
        }
        public RelayCommand NewSboriCommand
        {
            get
            {
                try
                {
                    return newSboricommand ??
                (newSboricommand = new RelayCommand(obj =>
                {
                    View.NewSbori NewSboriWindow = new View.NewSbori(ref DataBaseContext);

                    if (NewSboriWindow.ShowDialog() == true)
                    {
                        DataBaseContext.SaveChanges();
                    }


                    }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Неизвестная ошибка! Попробуйте еще раз", "Внимание!");
                    object obj = new Object();
                    UploadDB.Execute(obj);
                    return null;
                }
               
            }
        }
        public RelayCommand EditPrepodsCommand
        {
            get
            {
                try {
                return editPrepodsCommand ??
                 (editPrepodsCommand = new RelayCommand(obj =>
                 {
                     
                     
                     EditPrepods EditPrepodsWindow = new EditPrepods(ref DataBaseContext);

					 EditPrepodsWindow.ShowDialog();


				 }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Неизвестная ошибка! Попробуйте еще раз", "Внимание!");
                    object obj = new Object();
                    UploadDB.Execute(obj);
                    return null;
                }
            }
		}
		public RelayCommand AddCommand
		{
			get
			{
                try {
				return addCommand ??
				  (addCommand = new RelayCommand(obj =>
				  {
					  while (SelectedTroop.NumberTroop == null)
					  {
						  СheckTroop.Execute(obj);
					  }

                      Student temp_student = new Student(SelectedTroop);

                      AddStudent addStudentWindow = new AddStudent(temp_student, ref DataBaseContext);

                      if (addStudentWindow.ShowDialog() == true)
                      {
                          DataBaseContext.Students.Add(temp_student);

                          //temp_student.UpdateIdRelatives();

                          DataBaseContext.SaveChanges();

                          SelectedStudent = temp_student;
                          //SelectedTroop.Students.Add(temp_student);

                          Students = SelectedTroop.Students;

                          //SelectedTroop.StaffCount = SelectedTroop.Students.Count;
                      }

				  }));
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при добавлении студента! Проверьте вводимые данные и попробуйте еще раз!", "Внимание!");
                    object obj = new Object();
                    UploadDB.Execute(obj);
                    return null;
                }
            }
		}
		public RelayCommand EditCommand
		{
			get
			{
                try { 
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                  if (selectedItem == null) return;

                  // получаем выделенный объект
                  Student temp_student = selectedItem as Student;
                  AddStudent addStudentWindow = new AddStudent(temp_student, ref DataBaseContext);

                  if (addStudentWindow.ShowDialog() == true)
                  {
                      DataBaseContext.Entry(temp_student).State = EntityState.Modified;
                      DataBaseContext.SaveChanges();
                      
                      Students = new BindingList<Student>(Students.Skip(0).ToList());
                      SelectedStudent = temp_student;
                      }                     
                  }));
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при редактировании! Попробуйте еще раз.", "Внимание!");
                    object obj = new Object();
                    UploadDB.Execute(obj);
                    return null;
                }
            }
        }
        public RelayCommand CheckPassword
        {
            get
            {
                return checkPassCommand ??
                    (checkPassCommand = new RelayCommand(obj =>
                    {
                        CheckPass Check_Pass = new CheckPass();
                    if (Check_Pass.ShowDialog() == true)
                        {
                            
                        }       
                    },(obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }
        public RelayCommand SaveChangeCommand
        {
            get
            {
                return saveChangeCommand ??
                  (saveChangeCommand = new RelayCommand(selectStudent =>
                  {
                      ShowAllCommand.Execute(selectedStudent);
                  }));
            }
        }
        public RelayCommand CreateReportCommand
        {
            get
            {
                try { 
                return createReportCommand ??
                  (createReportCommand = new RelayCommand(obj =>
                  {
                      CreateReport CR_Window = new CreateReport(new ViewModel.CreateReportViewModel(ref DataBaseContext, Students, Troops, null));
                      CR_Window.Show();
                  }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Неизвестная ошибка! Попробуйте еще раз", "Внимание!");
                    object obj = new Object();
                    UploadDB.Execute(obj);
                    return null;
                }
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                try { 
                return deleteCommand ??
                 (deleteCommand = new RelayCommand(selectedItem =>
                 {
                         // если ни одного объекта не выделено, выходим
                         if (selectedItem == null) return;


                     MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить студента?", "Внимание!", MessageBoxButton.YesNo);
                     if (res.ToString() == "Yes")
                     {
                         Student temp_student = SelectedStudent as Student;
                         //Student._count--;
                         DataBaseContext.Students.Remove(temp_student);
                         DataBaseContext.Relatives.RemoveRange(temp_student.Relatives);


                         
                        //Troop temp = Troops.FirstOrDefault(u => u.NumberTroop == temp_student.Troop[0].NumberTroop);
                        //temp.Students.Remove(temp_student);
                        //temp.StaffCount = temp.Students.Count;

                         //if (temp.PlatoonCommander == temp_student)
                         //{
                         //    temp.Id_PC = 0;
                         //}

                         DataBaseContext.SaveChanges();
                         Students = new BindingList<Student>(Students.Skip(0).ToList());
                         //Students = new BindingList<Student>(DataBaseContext.Students.ToList());

                     }
                     else if (res.ToString() == "No")
                     {
                         deleteCommand = null;
                         return;
                     }

				 }, (obj) => Students.Count() > 0 && (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка при удалении! Перезапустите программу и попробуйте еще раз", "Внимание!");
                    return null;
                }
            }

		}
		public RelayCommand FindCommand
		{
			get
			{


				return findCommand ??
									(findCommand = new RelayCommand(select =>
									{
                                        var result = new BindingList<Student>(DataBaseContext.Students.ToList());

                                        if (!string.IsNullOrEmpty(SelectedValueFind_T))
                                        {
                                            result = new BindingList<Student>(result.Where(u => u.Troop.FirstOrDefault(c => c.SboriTroop == false).NumberTroop == SelectedValueFind_T).ToList());
                                        }
                                        if (!string.IsNullOrEmpty(SelectedValueFind_G))
                                        {
                                            result = new BindingList<Student>(result.Where(u => u.InstGroup == SelectedValueFind_G).ToList());
                                        }
                                        if (!string.IsNullOrEmpty(SelectedValueFind_R))
                                        {
                                            result = new BindingList<Student>(result.Where(u => u.Rank == SelectedValueFind_R).ToList());
                                        }
                                        if (!string.IsNullOrEmpty(SelectedValueFind_M))
                                        {
                                            result = new BindingList<Student>(result.Where(u => u.MiddleName == SelectedValueFind_M).ToList());
                                        }

                                        Students = result;
                                        if (Students.Count() == 0)
                                        {
                                            MessageBox.Show("Ни один студент не найден!", "Ошибка!");
                                        }
                                    }));
                
                
            }
        }

        public RelayCommand СheckTroop
        {
            get
            {
                try
                {
                    return troopCheck ??
                        (troopCheck = new RelayCommand(obj =>
                        {
                            TroopChange window_TC = new TroopChange(ref DataBaseContext, Troops);

                            if (window_TC.ShowDialog() == true)
                            {
                                SelectedTroop = window_TC.troop_change();

                                window_TC.Close();

                                Students = SelectedTroop.Students;

                                SelectTroopNumber = SelectedTroop.NumberTroop;

                            }
                        }));
                
                }
                catch (Exception)
                {
                    MessageBox.Show("Неизвестная ошибка! Попробуйте еще раз", "Внимание!");
                    object obj = new Object();
                    UploadDB.Execute(obj);
                    return null;
                }
}
		}

        public RelayCommand EditTroopCommand
        {
            get
            {
                try { 
                return editTroopCommand ??
                    (editTroopCommand = new RelayCommand(obj =>
                    {
                        View.EditTroop window_TC = new View.EditTroop(ref DataBaseContext);

                        if (window_TC.ShowDialog() == true)
                        {
                            DataBaseContext.SaveChanges();
                            DataBaseContext.Dispose();
                            Connect_DB(connect, database_officer);
                        }
                    }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Неизвестная ошибка! Попробуйте еще раз", "Внимание!");
                    object obj = new Object();
                    UploadDB.Execute(obj);
                    return null;
                }
            }
        }

		public RelayCommand ChangeRankCommand
		{
			get
			{
                try
                {
                    return changeRankCommand ??
                        (changeRankCommand = new RelayCommand(selectedItem =>
                        {
                            if (selectedItem == null) return;

                            Student temp_student = selectedItem as Student;

                            View.ChangeRankWindow window = new View.ChangeRankWindow(temp_student);

                            if (window.ShowDialog() == true)
                            {
                                DataBaseContext.SaveChanges();
                                Students = new BindingList<Student>(Students.Skip(0).ToList());
                            }
                        }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
                catch (Exception)
                {
                    MessageBox.Show("Неизвестная ошибка! Перезапустите программу", "Внимание!");
                    return null;
                }
}
        }



        private void ImportForAcsess()
        {
            string path = Environment.CurrentDirectory + "/sold.mdb"; ;
            string connection_string = "Provider=Microsoft.JET.OLEDB.4.0;data source=" + path + "";

            string sqlExpression = "SELECT * FROM КПУ";
            using (var odbc_connection = new OleDbConnection(connection_string))
            {
                odbc_connection.Open();
                OleDbCommand command = new OleDbCommand(sqlExpression, odbc_connection);
                OleDbDataReader reader = command.ExecuteReader();
                Troop t_troop = new Troop("111");
                Troops.Add(t_troop);
                while (reader.Read())
                {

                    Student temp_student = new Student(t_troop);
                    temp_student.FirstName = (string)reader["Имя"];
                    temp_student.MiddleName = (string)reader["Фамилия"];
                    temp_student.LastName = (string)reader["Отчество"];
                    temp_student.Nationality = "русский";
                    temp_student.Birthday = Convert.ToDateTime(reader["Дата рождения"]).ToShortDateString();
                    temp_student.PlaceBirthday = (string)reader["М/рождения"];
                    temp_student.Collness = "лейтенант";
                    temp_student.SpecialityName = (string)reader["ВУС"];
                    temp_student.YearOfEndMAI = reader["Год окончания ВУЗа"].ToString();
                    temp_student.YearOfEndVK = reader["Год окончания В/К"].ToString();
                    temp_student.ForeignLanguage = "английским";
                    temp_student.LanguageRank = "читает и переводит со словарем";
                    temp_student.Military = "нет";
                    temp_student.Rectal = (string)reader["Состоит на учете"];
                    temp_student.FamiliStatys = "холост";
                    temp_student.PlaceOfRegestration = (string)reader["Домашний адрес"];
                    temp_student.Growth = (string)reader["Рост"];
                    //temp_student.ClothihgSize = (string)reader["Одежда"];
                    temp_student.ClothihgSize = (string)reader["Одежда размер"];
                    temp_student.CapSize = (string)reader["Головной убор"];
                    temp_student.ShoeSize = (string)reader["Обувь"];
                    temp_student.MaskSize = (string)reader["Противогаз"];
                    temp_student.BloodType = (string)reader["Группа крови"];
                    temp_student.MobilePhone = (string)reader["Телефон"];
                    temp_student.SpecInst = (string)reader["Специальность гр"];

                    DataBaseContext.Students.Add(temp_student);

                   // string middle_name_r = (string)reader["Фамилия б/р"];
                   // try
                   // {
                   //     var item = Students.First(u => ((u.MiddleName == middle_name_r)
                   //|| (u.MiddleName == (middle_name_r.ToString().Remove(middle_name_r.ToString().Count() - 1)))));
                   //     Relative temp_r = new Relative();
                   //     temp_r.MiddleName = (string)reader["Фамилия б/р"];
                   //     temp_r.FirstName = (string)reader["Имя б/р"];
                   //     temp_r.LastName = (string)reader["Отчество б/р"];
                   //     temp_r.RelationDegree = (temp_r.MiddleName[temp_r.MiddleName.Count() - 1] == 'а') ? "мать" : "отец";
                   //     temp_r.Birthday = Convert.ToDateTime(reader["Дата рождения б/р"]).ToShortDateString();
                   //     item.Relatives.Add(temp_r);
                   //     item.UpdateIdRelatives();
                   // }
                   // catch (Exception)
                   // {
                   //     MessageBox.Show("Ошибка импорта!", "Ошибка!");
                   // }

                }



                List<Student> students = Troops.First(u => u.NumberTroop == "111").Students.ToList();

                while (reader.Read())
                {
                    string middle_name_r = (string)reader["Фамилия б/р"];
                    try
                    {
                        var item = students.First(u => ((u.MiddleName == middle_name_r)
                   || (u.MiddleName == (middle_name_r.ToString().Remove(middle_name_r.ToString().Count() - 1)))));
                        Relative temp_r = new Relative();
                        temp_r.MiddleName = (string)reader["Фамилия б/р"];
                        temp_r.FirstName = (string)reader["Имя б/р"];
                        temp_r.LastName = (string)reader["Отчество б/р"];
                        temp_r.RelationDegree = (temp_r.MiddleName[temp_r.MiddleName.Count() - 1] == 'а') ? "мать" : "отец";
                        temp_r.Birthday = Convert.ToDateTime(reader["Дата рождения б/р"]).ToShortDateString();
                        item.Relatives.Add(temp_r);
                        item.UpdateIdRelatives();
                    }
                    catch (Exception)
                    {

                    }

                }

            

                DataBaseContext.SaveChanges();
                odbc_connection.Close();

            }
        }

		public RelayCommand ExportCommand
		{
			get
			{
				return exportCommand ??
					(exportCommand = new RelayCommand(obj =>
					{
                        Export2MaevDB();
                        //ImportForAcsess();
                    }));
			}
		}

		public RelayCommand DataImportFromXL
		{
			get
			{
				return dataImportFromXL ??
					(dataImportFromXL = new RelayCommand(obj =>
					{
						Templates.DataImportFromXL(ref DataBaseContext);
					}));
			}
		}

		public static bool IsVowel(char c)
		{
			return "феёиоуыэюя".Contains(c);
		}

		public static string[] NameToDP(Student s)
		{
			string[] res = new string[3] { "", "", "" };

			if (IsVowel(s.LastName[s.LastName.Length - 2]) &&
				s.LastName.Last() == 'й')
				res[0] = s.LastName.Remove(s.LastName.Length - 2) + "ому";
			else if (!IsVowel(s.LastName.Last()) && s.LastName.Last() != 'ц'
				&& s.LastName.Last() != 'х')
				res[0] = s.LastName + 'у';
			else
				res[0] = s.LastName;

			if (s.MiddleName.Last() == 'ч')
				res[1] = s.MiddleName + 'у';
			else
				res[1] = s.MiddleName;

			if (s.FirstName.Last() == 'я' || s.FirstName.Last() == 'а')
				res[2] = s.FirstName.Remove(s.FirstName.Length - 1) + 'е';
			else if (s.FirstName.Last() == 'й' || s.FirstName.Last() == 'ь')
				res[2] = s.FirstName.Remove(s.FirstName.Length - 1) + 'ю';
			else if (!IsVowel(s.FirstName.Last()))
				res[2] = s.FirstName + 'у';
			else
				res[2] = s.FirstName;

			return res;
		}

        private void Export2MaevDB()
        {
            int counter = 0;

            View.ProgressBar ProgressWin = new View.ProgressBar();
            ProgressWin.Show();
            //var Progress = ProgressWin.Progress_Bar;

            string path = Environment.CurrentDirectory + @"\Acsess\"  + "maev_new.mdb";
            try
            {
                File.Copy(maev_path, path, true);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка создания временнего файла: " + e.Message);
                return;
            }

			string connection_string;

			switch (Environment.OSVersion.Version.Major)
			{
				case 5:
					connection_string = "Driver={Microsoft Access Driver (*.mdb)};DBQ=" + path + ";";
					break;
				case 6:
					connection_string = "Provider=Microsoft.JET.OLEDB.4.0;data source=" + path + "";
					break;
				default:
					connection_string = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};DBQ=" + path + ";";
					break;
			}

            var odbc_connection = new OleDbConnection(connection_string);
            try
            {
                odbc_connection.Open();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }


			//Очищаем файл-шаблон
			var cmd = new OleDbCommand("DELETE FROM КПУ"); //КПУ
			cmd.Connection = odbc_connection;
			cmd.ExecuteNonQuery();


			//Выбираем студентов на экспорт, которые буду на сборах
			var students_to_export = Students.Where(u => u.Status == "На сборах");


			//Запрос добавления студента в таблицу КПУ, сначала основные данные
			foreach (var s in students_to_export)
			{


				cmd.CommandText = String.Format(@"INSERT INTO КПУ (Фамилия,Имя,Отчество,К_НАЦ)
SELECT '{0}', '{1}', '{2}', К_НАЦ FROM национальность WHERE национальность='{3}'",
													s.LastName, s.FirstName, s.MiddleName, s.Nationality != null ? s.Nationality : "Русский");

				cmd.ExecuteNonQuery();
				cmd.CommandText = "SELECT @@Identity";
				var reader = cmd.ExecuteReader();

				reader.Read();
				int id = reader.GetInt32(0);
				reader.Close();

				String birthplace = s.PlaceBirthday != null ? birthplace = s.PlaceBirthday : birthplace = "Неизвестно";

				//Дописываем даты
				s.Birthday = s.Birthday.Length > 0 ? s.Birthday : "01.01.1990";
				cmd.CommandText = String.Format(@"UPDATE КПУ SET [Дата рождения]={0}, " +
					"[М/рождения]='{1}' WHERE к_код={2}", "# " + s.Birthday[6] + s.Birthday[7] + s.Birthday[8] + s.Birthday[9] + "-" + s.Birthday[3] + s.Birthday[4] + "-" + s.Birthday[0] + s.Birthday[1] + " 12.00.00#", birthplace, id);
				cmd.ExecuteNonQuery();

				String home_address = "Неизвестно",
					phone_number = "Нет",
					speciality_name = "Неизвестно",
					cell_number = "Неизвестно";

				if (s.PlaceOfResidence != null)
					home_address = s.PlaceOfResidence;

				if (s.HomePhone != null)
					phone_number = s.HomePhone;
				else if (s.MobilePhone != null)
					phone_number = s.MobilePhone;

				if (s.MobilePhone != null)
					cell_number = s.MobilePhone;
				else if (s.HomePhone != null)
					cell_number = s.HomePhone;



				if (s.SpecialityName.Trim().Length > 0)
					speciality_name = s.SpecialityName;

				var name_dp = NameToDP(s);

                try
                {
                    //Дописываем остальную информацию
                    cmd.CommandText = "UPDATE КПУ SET ВУЗ=@var1,[Год окончания ВУЗа]=@var2,[Год окончания В/К]=@var3,[Состоит на учете]=@var4,[Специальность воен]=@var5,[Рост]=@var6,[Одежда]=@var7,[Одежда размер]=@var8,[Головной убор]=@var9,[Противогаз]=@var10,[Домашний адрес]=@var11,[Телефон]=@var12,[Группа крови]=@var13,[Факультет]=@var14,[Специальность гр]=@var15,[Обувь]=@var16,[Фамилия ДП]=@var17,[Имя ДП]=@var18,[Отчество ДП]=@var19,ВУС =@var20,[В/кафедра]=@var21, [№ приказа]=@var22, [дата приказа]=@var23 WHERE к_код=@var24";

					cmd.Parameters.Add("@var1", OleDbType.Char).Value = "МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ(национальный исследовательский университет)(МАИ)";
					cmd.Parameters.Add("@var2", OleDbType.Char).Value = s.YearOfEndMAI != null ? s.YearOfEndMAI : "1990";
					cmd.Parameters.Add("@var3", OleDbType.Char).Value = s.YearOfEndVK != null ? s.YearOfEndVK : "1990";
					cmd.Parameters.Add("@var4", OleDbType.Char).Value = s.Rectal != null ? s.Rectal : "Неизвестно";
					cmd.Parameters.Add("@var5", OleDbType.Char).Value = "Боевое применение частей и подразделений войсковой ПВО";

					cmd.Parameters.Add("@var6", OleDbType.Char).Value = s.Growth != null ? s.Growth : "0";
					cmd.Parameters.Add("@var7", OleDbType.Char).Value = s.ClothihgSize != null ? s.ClothihgSize : "0";
					cmd.Parameters.Add("@var8", OleDbType.Char).Value = s.ClothihgSize != null ? s.ClothihgSize : "0";
					cmd.Parameters.Add("@var9", OleDbType.Char).Value = s.CapSize != null ? s.CapSize : "0";
					cmd.Parameters.Add("@var10", OleDbType.Char).Value = s.MaskSize != null ? "№" + s.MaskSize : "№0";

					cmd.Parameters.Add("@var11", OleDbType.Char).Value = home_address + " т. " + cell_number;
					cmd.Parameters.Add("@var12", OleDbType.Char).Value = phone_number;
					cmd.Parameters.Add("@var13", OleDbType.Char).Value = s.BloodType.Length > 3 ? "2+" : s.BloodType;
					cmd.Parameters.Add("@var14", OleDbType.Char).Value = s.Faculty != null ? s.Faculty : "0";
					cmd.Parameters.Add("@var15", OleDbType.Char).Value = speciality_name != null ? speciality_name : "Нет";

					cmd.Parameters.Add("@var16", OleDbType.Char).Value = s.ShoeSize != null ? s.ShoeSize : "43";
					cmd.Parameters.Add("@var17", OleDbType.Char).Value = name_dp[0];
					cmd.Parameters.Add("@var18", OleDbType.Char).Value = name_dp[2];
					cmd.Parameters.Add("@var19", OleDbType.Char).Value = name_dp[1];
					cmd.Parameters.Add("@var20", OleDbType.Char).Value = "042600";

                    cmd.Parameters.Add("@var21", OleDbType.Char).Value = "Военная кафедра МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ(национальный исследовательский университет)(МАИ)";
                    cmd.Parameters.Add("@var22", OleDbType.Char).Value = s.NumberOfOrder != null ? s.NumberOfOrder : "Нет";
                    cmd.Parameters.Add("@var23", OleDbType.Char).Value = s.DateOfOrder != "" ? Convert.ToDateTime(s.DateOfOrder) : Convert.ToDateTime("01.01.1990");
                    cmd.Parameters.Add("@var24", OleDbType.Char).Value = id.ToString();

					/*"годен к военной службе"*/ /*[Категория годности] = '{21}'*/


				}
				catch (OleDbException e)
				{
					MessageBox.Show(e.Message, "Ошибка!");
				}
				cmd.ExecuteNonQuery();
				cmd.Parameters.Clear();

				//Дописываем значния языков
				//cmd.CommandText = String.Format(@"UPDATE КПУ SET ");
				//int i = 1;
				//foreach (var k in s.Languages.Keys)
				//{
				//    if (k == "русский")
				//        continue;
				//    if (k == "")
				//        continue;
				//    var select_lang = new OdbcCommand("SELECT К_ЯЗ FROM [иностранный язык] " +
				//            "WHERE [Иностранный язык] LIKE '" + k.ToLower().Substring(0, k.Length - 1)
				//            + "_'");
				//    select_lang.Connection = odbc_connection;
				//    var r = select_lang.ExecuteReader();
				//    r.Read();

				//    Int32 lang_id;
				//    try
				//    {
				//        lang_id = r.GetInt32(0);
				//    }
				//    catch (Exception)
				//    {
				//        continue;
				//    }
				//    finally
				//    {
				//        r.Close();
				//    }

				//    if (i != 1)
				//        cmd.CommandText += ", ";

				//    cmd.CommandText += "[К_ЯЗ" + (i > 1 ? " " + i.ToString() : "") + "]" +
				//        "=" + lang_id.ToString() + ", ";
				//    cmd.CommandText += "[К_СТ/ВЛ" + (i > 1 ? " " + i.ToString() : "") + "]" +
				//        "=" + s.Languages[k];

				//    i++;
				//}

				//if (i != 1)
				//{
				//    cmd.CommandText += " WHERE к_код=" + id.ToString();

				//    try
				//    {
				//        cmd.ExecuteNonQuery();
				//    }
				//    catch (Exception e)
				//    {
				//        MessageBox.Show(e.Message + "\n" + cmd.CommandText);
				//        break;
				//    }
				//}

				String[] parenting_levels = { "Мать", "Отец", "Отчим", "Мачеха", "Брат", "Сестра", "Жена", "Сын", "Дочь" };

                foreach (var r in s.Relatives)
                {
                    var select_parenting_level = new OleDbCommand(@"SELECT [к-С/Р] FROM [степень родства]
        WHERE [Степень родства]='" + r.RelationDegree.ToLower() + "'");
					select_parenting_level.Connection = odbc_connection;

					var rd = select_parenting_level.ExecuteReader();

					rd.Read();
					Int32 type_id = rd.GetInt32(0);
					rd.Close();

					// Записываем информацию о родственниках
					switch (r.RelationDegree)
					{
						case "Мать": // Мать
						case "Жена": // Жена
							cmd.CommandText = String.Format(@"UPDATE КПУ SET [к-С/Р]={0},
    [Фамилия б/р]='{1}', [Имя б/р]='{3}', 
    [Отчество б/р]='{4}', [Дата рождения б/р]='{5}', [Адрес б/р (жены)]='{6}'  WHERE к_код=" + id, //removed  ({2})
								type_id, r.LastName, r.MaidenName != null && r.MaidenName.Length > 1 ? r.MaidenName : "Неизвестно",
								r.FirstName, r.MiddleName, r.Birthday.ToString(),
								(r.PlaceOfResidence != null && r.PlaceOfResidence.Length > 1 ? r.PlaceOfResidence : r.PlaceOfRegestration != null && r.PlaceOfRegestration.Length > 1 ? r.PlaceOfRegestration : "Неизвестно") + " т." + r.MobilePhone);
							//file.WriteLine(r.NameString + " " + r.AddressDoc + " " + r.AddressFact);
							break;

						default:
							cmd.CommandText = String.Format(@"UPDATE КПУ SET [к-С/Р]={0},
    [Фамилия б/р]='{1}', [Имя б/р]='{2}',
    [Отчество б/р]='{3}', [Дата рождения б/р]='{4}', [Адрес б/р (жены)]='{5}' WHERE к_код=" + id,
						type_id, r.LastName, r.FirstName, r.MiddleName, r.Birthday.ToString(),
						 (r.PlaceOfResidence != null && r.PlaceOfResidence.Length > 1 ? r.PlaceOfResidence : r.PlaceOfRegestration != null && r.PlaceOfRegestration.Length > 1 ? r.PlaceOfRegestration : "Неизвестно") + " т." + r.MobilePhone);

							//file.WriteLine(r.NameString + " " + r.AddressDoc + " " + r.AddressFact);
							break;
					}


					cmd.ExecuteNonQuery();
					break; // we need only first non-son/daughter relative
				}

				++counter;
			}

			odbc_connection.Close();

  
            MessageBoxResult res = MessageBox.Show(String.Format("Студентов экспортировано: {0}", counter), "Успешно!", MessageBoxButton.OK);
            if (res.ToString() == "OK")
            {
                //ProgressWin.DialogResult = true;
                ProgressWin.Close();
            }
            
        }


        public RelayCommand InfoSboriCommand
        {
            get
            {
                return infoSboriCommand ??
                    (infoSboriCommand = new RelayCommand(obj =>
                    {
						if(database_officer)
						{
							LKS_3._0.View.InfoSboriWindowOff Info = new View.InfoSboriWindowOff(ref DataBaseContext, Troops, database_officer);
							if (Info.ShowDialog() == true)
							{
								DataBaseContext.SaveChanges();
							}
						}
						else
						{
                            View.InfoSboriWindowSold Info = new View.InfoSboriWindowSold(ref DataBaseContext, Troops, database_officer);

                            if (Info.ShowDialog() == true)
                            {
                                DataBaseContext.SaveChanges();
                            }
                        }
                        
                    }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }

        public RelayCommand IsSuspendedСommand
        {
            get
            {
                return isSuspendedСommand ??
                  (isSuspendedСommand = new RelayCommand(selectedItem =>
                  {
                      if (selectedItem == null) return;

                      Student temp_student = selectedItem as Student;
                      
                      if(temp_student.IsSuspended)
                      {
                          temp_student.IsSuspended = false;
                      }
                      else
                      {
                          temp_student.IsSuspended = true;
                      }

                      DataBaseContext.SaveChanges();
                      Students = new BindingList<Student>(Students.Skip(0).ToList());

                  }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }

        public RelayCommand ChangeKursCommand
        {
            get
            {
                return changeKursCommand ??
                  (changeKursCommand = new RelayCommand(obj =>
                  {
                      View.ChangeKurs wind = new View.ChangeKurs(Students);
                      wind.ShowDialog();
                      DataBaseContext.SaveChanges();
                      
                  }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }

		public RelayCommand AddNoteCommand
		{
			get
			{
				return addNoteCommand ??
					(addNoteCommand = new RelayCommand(obj =>
					{
						if (obj == null) return;

						Student tepm_student = obj as Student;
						View.AddNoteStudent AddNewNote = new View.AddNoteStudent(tepm_student);

                        if (AddNewNote.ShowDialog() == true)
                        {
                            DataBaseContext.SaveChanges();
                        }
                    }));
            }
        }

        public RelayCommand OrdersCommand
        {
            get
            {
                return ordersCommand ??
                  (ordersCommand = new RelayCommand(obj =>
                  {
                      BindingList<Student> _temp_students = new BindingList<Student>(Students.Where(u => u.Status == "На сборах").ToList());
                      View.SummerOrders win = new View.SummerOrders(ref DataBaseContext, _temp_students, Troops, database_officer);

					  win.ShowDialog();

                      DataBaseContext.SaveChanges();
                  }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }

		public void Load_DB()
		{

            Students = new BindingList<Student>(DataBaseContext.Students.Include(c => c.Troop).ToList());

            Troops = new BindingList<Troop>(DataBaseContext.Troops.Include(c => c.Students).ToList());

            BindingList<Relative> Relatives = new BindingList<Relative>(Students.SelectMany(c => c.Relatives).ToList());

            BindingList<Prepod> Prepods = new BindingList<Prepod>(DataBaseContext.Prepods.Include(c => c.Troops).ToList());

            DataBaseContext.Relatives.Load();

            DataBaseContext.Prepods.Load();

            SelectedTroop = new Troop();

            //foreach (Troop item in Troops)
            //{
            //    if (item.Id_PC != 0)
            //    {
            //        item.PlatoonCommander = Students.FirstOrDefault(u => u.Id == item.Id_PC);
            //    }
            //}

        }

        public void Connect_DB(bool _connect, bool _data)
        {
            this.connect = _connect;
			this.database_officer = _data;
            View.ProgressBar ProgressWin = new View.ProgressBar();
            ProgressWin.Show();

            try
            {
                CreateConnection(connect, database_officer);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения! Проверьте настройки подключения!", "Ошибка!");
                ProgressWin.Close();
                return;
            }

            //try
            //{
                Load_DB();

                Update_List();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Ошибка загрузки данных!", "Ошибка!");
            //    ProgressWin.Close();
            //    return;
            //}
            ProgressWin.Close();
        }

		public ApplicationViewModel(bool _connect, bool _data)
		{
            Connect_DB(_connect, _data);
        }

        public void CreateConnection(bool connect, bool data)
        {
            if(connect)
            {
                var str_connect = new MySql.Data.MySqlClient.MySqlConnection() { ConnectionString = "server="+Properties.Settings.Default.Server+";user id="+Properties.Settings.Default.User+";database=db_vk" };
                DataBaseContext = new ApplicationContext(str_connect);
            }
            else
            {
				if(data)
				{
					var str_connect = new System.Data.SQLite.SQLiteConnection() { ConnectionString = "Data Source=.\\DataBaseVK_Off.sqlite" };
					DataBaseContext = new ApplicationContext(str_connect);
				}
				else
				{
					var str_connect = new System.Data.SQLite.SQLiteConnection() { ConnectionString = "Data Source=.\\DataBaseVK_Sold.sqlite" };
					DataBaseContext = new ApplicationContext(str_connect);
				}
				
                
            }

            
        }

        
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

        public void Dispose()
        {
            ((IDisposable)DataBaseContext).Dispose();
        }
    }
}

