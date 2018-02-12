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

namespace LKS_3._0
{
   
    public class ApplicationViewModel : INotifyPropertyChanged, IDisposable
    {
        public ApplicationContext DataBase;

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
            infoCommand,
            infoSboriCommand,
            closeAllWordFile,
            changeKursCommand,
			createReportUniversityCommand,
			ordersCommand;

        private Student selectedStudent;
        private string ValueFind_T, ValueFind_G, ValueFind_M, ValueFind_R;
        private Troop selectedTroop;
        private string selectTroopNumber;
        private BindingList<Student> students;
        private BindingList<Troop> troops;
        private BindingList<string> list_Troop, list_Mname, list_Rank, list_Group;

        public string SelectedValueFind_T
        {
            get
            {
                return ValueFind_T;
            }
            set
            {
                if (value == null)
                {
                    Students = DataBase.Students.Local.ToBindingList();
                }

                List_Group = new BindingList<string>(DataBase.Students.Local.Where(u => u.Troop == value).Select(u => u.Group).Distinct().ToList());

                ValueFind_T = value;
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
                if (value == null)
                {
                    Students = DataBase.Students.Local.ToBindingList();
                }
                List_Mname = new BindingList<string>(DataBase.Students.Local.Where(u => u.Group == value).Select(u => u.MiddleName).Distinct().ToList());
                ValueFind_G = value;
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
                if (value == null)
                {
                    Students = DataBase.Students.Local.ToBindingList();
                        }
                ValueFind_M = value;
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
                if (value == null)
                {
                    Students = DataBase.Students.Local.ToBindingList();
                        }
                ValueFind_R = value;
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
            List_Troop = new BindingList<string>(DataBase.Troops.Where(u => u.SboriTroop == false).Select(u => u.NumberTroop).Distinct().ToList());

            List_Group = new BindingList<string>(DataBase.Students.Select(u => u.Group).Distinct().ToList());

            List_Mname = new BindingList<string>(DataBase.Students.Select(u => u.MiddleName).Distinct().ToList());

            List_Rank = new BindingList<string>(DataBase.Students.Select(u => u.Rank).Distinct().ToList());

        }

		public RelayCommand CreateReportUniversityCommand
		{
			get
			{
				return createReportUniversityCommand ??
					(createReportUniversityCommand = new RelayCommand(obj =>
				   {
					   View.CreateReportUniversity Wind = new View.CreateReportUniversity(
						   new ViewModel.CreateReportUniversityViewModel(Students, Troops));
					   Wind.Show();
				   }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
			}
		}

		public RelayCommand CloseAllWordFile
		{
			get
			{
				return closeAllWordFile ??
					(closeAllWordFile = new RelayCommand(obj =>
					{
						System.Diagnostics.Process Process2 = null;
						Process2 = System.Diagnostics.Process.Start(@"clean.bat");
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
                     Students = DataBase.Students.Local.ToBindingList();
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
                         Students = new BindingList<Student>(SelectedTroop.ListStudents.Where(u => u.Status == "Обучается").ToList());
                     }
                     else
                     {
                         Students = new BindingList<Student>(DataBase.Students.Local.Where(u => u.Status == "Обучается").ToList());
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
                         Students = new BindingList<Student>(SelectedTroop.ListStudents.Where(u => u.Status == "Отстранен").ToList());
                     }
                     else
                     {
                         Students = new BindingList<Student>(DataBase.Students.Local.Where(u => u.Status == "Отстранен").ToList());
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
                         Students = new BindingList<Student>(SelectedTroop.ListStudents.Where(u => u.Status == "На сборах").ToList());
                     }
                     else
                     {
                         Students = new BindingList<Student>(DataBase.Students.Local.Where(u => u.Status == "На сборах").ToList());
                     }
                 }));
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
                         Students = new BindingList<Student>(SelectedTroop.ListStudents.Where(u => u.Status == "Прошел сборы").ToList());
                     }
                     else
                     {
                         Students = new BindingList<Student>(DataBase.Students.Local.Where(u => u.Status == "Прошел сборы").ToList());
                     }
                 }));
            }
        }
        public RelayCommand NewSboriCommand
        {
            get
            {
                return newSboricommand ??
                 (newSboricommand = new RelayCommand(obj =>
                 {


                     View.NewSbori NewSboriWindow = new View.NewSbori (ref DataBase);

                     if(NewSboriWindow.ShowDialog() == true)
                     {
                         DataBase.SaveChanges();
                     }


                 },(obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }
        public RelayCommand EditPrepodsCommand
        {
            get
            {
                return editPrepodsCommand ??
                 (editPrepodsCommand = new RelayCommand(obj =>
                 {
                     
                     
                     EditPrepods EditPrepodsWindow = new EditPrepods(ref DataBase);

                     EditPrepodsWindow.ShowDialog();

                         
                 }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      while (SelectedTroop.NumberTroop == null)
                      {
                          СheckTroop.Execute(obj);
                      }

                      Student temp_student = new Student(SelectTroopNumber);
                      AddStudent addStudentWindow = new AddStudent(temp_student, ref DataBase);

                      if (addStudentWindow.ShowDialog() == true)
                      {
                          DataBase.Students.Add(temp_student);
                          SelectedTroop.ListStudents.Add(temp_student);
                          Students = SelectedTroop.ListStudents;
                          SelectedTroop.StaffCount = SelectedTroop.ListStudents.Count;
                          SelectedStudent = temp_student;

                          DataBase.SaveChanges();
                      }

                  }));
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;

                      // получаем выделенный объект
                      Student temp_student = selectedItem as Student;
                      AddStudent addStudentWindow = new AddStudent(temp_student, ref DataBase);

                      if (addStudentWindow.ShowDialog() == true)
                      {
                        DataBase.Students.Add(temp_student);
                        DataBase.Entry(temp_student).State = EntityState.Modified;
                        DataBase.SaveChanges();

                          Troop temp_Troop = DataBase.Troops.FirstOrDefault(u => u.NumberTroop == temp_student.Troop);
                          temp_Troop.ListStudents = new BindingList<Student>(DataBase.Students.Where(u => u.Troop == temp_Troop.NumberTroop).ToList());
                          temp_Troop.StaffCount = temp_Troop.ListStudents.Count;
                          
                          SelectedStudent = temp_student;
                      }                     
                  }));
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
                      Student temp_stud = selectStudent as Student;
                      DataBase.Students.Local.Insert(temp_stud.Id, temp_stud);
                      DataBase.SaveChanges();
                  }));
            }
        }
        public RelayCommand CreateReportCommand
        {
            get
            {
                return createReportCommand ??
                  (createReportCommand = new RelayCommand(obj =>
                  {
                      CreateReport CR_Window = new CreateReport(new ViewModel.CreateReportViewModel(Students, Troops, null));
                      CR_Window.Show();
                  }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                 (deleteCommand = new RelayCommand(selectedItem =>
                 {
                         // если ни одного объекта не выделено, выходим
                         if (selectedItem == null) return;


                     MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить студента?", "Внимание!", MessageBoxButton.YesNo);
                     if (res.ToString() == "Yes")
                     {
                         Student temp_student = SelectedStudent as Student;
                         Student._count--;
                         Students.Remove(temp_student);
                         DataBase.Relatives.RemoveRange(temp_student.ListRelatives);

                        Troop temp = Troops.FirstOrDefault(u => u.NumberTroop == temp_student.Troop);
                        temp.ListStudents.Remove(temp_student);
                        temp.StaffCount = temp.ListStudents.Count;

                        if(temp.PlatoonCommander == temp_student)
                        {
                            temp.Id_PC = 0;
                        }
                         
                         DataBase.SaveChanges();
                     }
                     else if (res.ToString() == "No")
                     {
                         deleteCommand = null;
                         return;
                     }

                 }, (obj) => Students.Count() > 0 && (ProgMode.ProgramMode == ProgramMode.Admin)));
                }
            
        }
        public RelayCommand FindCommand
        {
            get
            {
               
               
                    return findCommand ??
                                        (findCommand = new RelayCommand(select =>
                                        {


                                            Students = new BindingList<Student>(DataBase.Students.Local.Where(u => u.Troop == SelectedValueFind_T || u.Group == SelectedValueFind_G || u.Rank == SelectedValueFind_R || u.MiddleName == SelectedValueFind_M).ToList());
                                            if (Students.Count() == 0)
                                                    {
                                                MessageBox.Show("Ни один студент не найден!", "Ошибка!");
                                            }
                                        }, (obj) => SelectedValueFind_G != null || SelectedValueFind_T != null || SelectedValueFind_M != null || SelectedValueFind_R != null));
                
                
            }
        }

        public RelayCommand СheckTroop
        {
            get
            {
                return troopCheck ??
                    (troopCheck = new RelayCommand(obj =>
                    {
                        TroopChange window_TC = new TroopChange(ref DataBase, Troops);

                        if (window_TC.ShowDialog() == true)
                        {
                            SelectedTroop = window_TC.troop_change();

                            window_TC.Close();

                            Students = SelectedTroop.ListStudents;

                            SelectTroopNumber = SelectedTroop.NumberTroop;

                        }
                    }));
            }
        }

        public RelayCommand EditTroopCommand
        {
            get
            {
                return editTroopCommand ??
                    (editTroopCommand = new RelayCommand(obj =>
                    {
                        View.EditTroop window_TC = new View.EditTroop(ref DataBase, Troops);

                        if (window_TC.ShowDialog() == true)
                        {
                            DataBase.SaveChanges();
                        }
                    }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }

        public RelayCommand ChangeRankCommand
        {
            get
            {
                return changeRankCommand ??
                    (changeRankCommand = new RelayCommand(selectedItem =>
                    {
                        if (selectedItem == null) return;

                        Student temp_student = selectedItem as Student;

                        View.ChangeRankWindow window = new View.ChangeRankWindow(temp_student);

                        if (window.ShowDialog() == true)
                        {
                            DataBase.SaveChanges();
                        }
                    },(obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }


       

        public RelayCommand InfoCommand
        {
            get
            {
                return infoCommand ??
                    (infoCommand = new RelayCommand(obj =>
                    {
                        //LKS_3._0.View.InfoWindow Info = new View.InfoWindow(ref DataBase, List_Troop, List_Group, List_Speciality);
                        //if (Info.ShowDialog() == true)
                        //{

                        //}
                    }));
            }
        }


        

        public RelayCommand InfoSboriCommand
        {
            get
            {
                return infoSboriCommand ??
                    (infoSboriCommand = new RelayCommand(obj =>
                    {
                        LKS_3._0.View.InfoSboriWindow Info = new View.InfoSboriWindow(ref DataBase, Troops);
                        if (Info.ShowDialog() == true)
                        {
                            DataBase.SaveChanges();
                        }
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
                      DataBase.SaveChanges();
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
                            DataBase.SaveChanges();
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
                      View.SummerOrders win = new View.SummerOrders(ref DataBase, _temp_students, Troops);

                      win.ShowDialog();

                      DataBase.SaveChanges();
                  }, (obj) => (ProgMode.ProgramMode == ProgramMode.Admin)));
            }
        }

        public void Load_DB()
        {

            DataBase = new ApplicationContext();

            SelectedTroop = new Troop();

            DataBase.Students.Load();

            Student._count = DataBase.Students.Count();

            DataBase.Troops.Load();

            DataBase.Relatives.Load();

            DataBase.Prepods.Load();

            Students = DataBase.Students.Local.ToBindingList();

            Troops = DataBase.Troops.Local.ToBindingList();

            foreach (Troop item in Troops)
            {
                if (item.Id_RP != 0)
                {
                    item.ResponsiblePrepod = DataBase.Prepods.Local.FirstOrDefault(u => u.Id == item.Id_RP);
                   
                }
                if (item.Id_PC != 0)
                {
                    item.PlatoonCommander = Students.FirstOrDefault(u => u.Id == item.Id_PC);
                }
                if (item.SboriTroop)
                {
                    item.ListStudents = new BindingList<Student>(Students.Where(u => u.NumSboriTroop == item.NumberTroop).ToList());
                    item.StaffCount = item.ListStudents.Count;
                }   
                else
                {
                    item.ListStudents = new BindingList<Student>(Students.Where(u => u.Troop == item.NumberTroop).ToList());
                    item.StaffCount = item.ListStudents.Count;
                }
               
               if(item.StaffCount != 0)
                {
                    item.Vus = item.ListStudents.FirstOrDefault().SpecialityName;
                }     

            }

            foreach (Student item in Students)
            {
                item.ListRelatives = new BindingList<Relative>(DataBase.Relatives.Local.Where(u => u.IdStudent == item.Id).ToList());

            }


        }



        public ApplicationViewModel()
        {
            Load_DB();

            Update_List();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void Dispose()
        {
            ((IDisposable)DataBase).Dispose();
        }
    }
}

