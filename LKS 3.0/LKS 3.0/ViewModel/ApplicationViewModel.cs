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
   
    public class ApplicationViewModel : INotifyPropertyChanged
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
			openTemplate,
			showTraineesCommand,
			showDetachedCommand,
			showNaSboriCommand,
			showPastSboriCommand,
			showAllCommand,
			troopCheck,
			newSboricommand,
			editTroopCommand,
			changeRankCommand,
			infoCommand,
			infoSboriCommand,
			closeAllWordFile;



		private Student selectedStudent;

        private Troop selectedTroop;

        BindingList<Student> students;

        BindingList<Troop> troops;

        private List<string> list_Troop,
            list_Rectal,
            list_Mname,
            list_Rank,
            list_Group,
            list_Speciality,
            list_SpecInst;


        private string ValueFind_T, ValueFind_G, ValueFind_M, ValueFind_R;

        private string selectTroopNumber;

        private string currentPrepod;

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

                List_Group = DataBase.Students.Local.Where(u => u.Troop == value).Select(u => u.Group).Distinct().ToList();

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
                List_Mname = DataBase.Students.Local.Where(u => u.Group == value).Select(u => u.MiddleName).Distinct().ToList();
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

        public List<string> List_Troop
        {
            get { return list_Troop; }
            set
            {
                list_Troop = value;
                OnPropertyChanged();
            }

        }
        public List<string> List_Rectal
        {
            get { return list_Rectal; }
            set
            {
                list_Rectal = value;
                OnPropertyChanged();
            }

        }
        public List<string> List_Mname
        {
            get { return list_Mname;  }
            set
            {
                list_Mname = value;
                OnPropertyChanged();
            }

        }
        public List<string> List_Rank
        {
            get { return list_Rank; }
            set
                {
                list_Rank = value;
                OnPropertyChanged();
            }

        }
        public List<string> List_Group
        {
            get { return list_Group; }
            set
            {
                list_Group = value;
                OnPropertyChanged();
            }

        }

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        public Troop SelectedTroop
        {
            get { return selectedTroop; }
            set
            {
                selectedTroop = value;
                OnPropertyChanged("SelectedStudent");
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
            get { return students; }
            set
            {

                students = value;
                OnPropertyChanged("Students");
            }
        }

        public BindingList<Troop> Troops
        {
            get { return troops; }
            set
            {

                troops = value;
                OnPropertyChanged("Troops");
            }
        }

        private void Update_List()
        {
            List_Troop = DataBase.Troops.Local.Select(u => u.NumberTroop).Distinct().ToList();

            List_Group = DataBase.Students.Local.Select(u => u.Group).Distinct().ToList();

            List_Mname = DataBase.Students.Local.Select(u => u.MiddleName).Distinct().ToList();

            List_Rank = DataBase.Students.Local.Select(u => u.Rank).Distinct().ToList();

            List_Rectal = DataBase.Students.Local.Select(u => u.Rectal).Distinct().ToList();

            List_Speciality = DataBase.Students.Local.Select(u => u.SpecialityName).Distinct().ToList();

            List_SpecInst = DataBase.Students.Local.Select(u => u.SpecInst).Distinct().ToList();

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
                     if(selectedTroop.NumberTroop !=  null)
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
                     if (selectedTroop.NumberTroop != null)
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
                     if (selectedTroop.NumberTroop != null)
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
                     if (selectedTroop.NumberTroop != null)
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


                     View.NewSbori NewSboriWindow = new View.NewSbori (ref DataBase, List_Troop);

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
                     
                     
                     EditPrepods EditPrepodsWindow = new EditPrepods(ref DataBase, SelectedTroop);

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
                      Student temp_student = new Student(SelectTroopNumber);

                      Update_List();

                      AddStudent addStudentWindow = new AddStudent(temp_student, List_Troop, List_Rectal, List_Group, List_Speciality, List_SpecInst, ref DataBase);

                      if (addStudentWindow.ShowDialog() == true)
                      {
                          DataBase.Students.Add(temp_student);
                          DataBase.SaveChanges();

                          if(SelectedTroop.NumberTroop != null)
                          {
                              SelectedTroop.ListStudents.Add(temp_student);

                              Students = new BindingList<Student>(selectedTroop.ListStudents);
                              SelectedTroop.StaffCount = SelectedTroop.ListStudents.Count;
                              SelectedStudent = temp_student;
                          }
                          else
                          {
                              Troop temp = Troops.FirstOrDefault(u => u.NumberTroop == temp_student.Troop);
                              temp.ListStudents.Add(temp_student);
                              temp.StaffCount = temp.ListStudents.Count;
                             
                              SelectedStudent = temp_student;
                          }
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

                      Update_List();

                      AddStudent addStudentWindow = new AddStudent(temp_student, List_Troop, List_Rectal, List_Group, List_Speciality, List_SpecInst, ref DataBase);

                      if (addStudentWindow.ShowDialog() == true)
                      {
                          DataBase.Students.Add(temp_student);
                          DataBase.Entry(temp_student).State = EntityState.Modified;
                          DataBase.SaveChanges();


                          //TO DO 
                          if (SelectedTroop.NumberTroop != null)
                          {
                              int i = SelectedTroop.ListStudents.IndexOf(temp_student);
                              SelectedTroop.ListStudents.RemoveAt(i);
                              SelectedTroop.ListStudents.Insert(i, temp_student);
                              SelectedTroop.StaffCount = SelectedTroop.ListStudents.Count;
                              Students = new BindingList<Student>(selectedTroop.ListStudents);
                          }
                          else
                          {
                              Troop temp = Troops.Where(u => u.NumberTroop == temp_student.Troop).First();
                              int i = temp.ListStudents.IndexOf(temp_student);
                              temp.ListStudents.RemoveAt(i);
                              temp.ListStudents.Insert(i, temp_student);
                              SelectedTroop.StaffCount = SelectedTroop.ListStudents.Count;
                          }

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
                      Student temp_stud = selectedStudent as Student;
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
                         Student temp_student = selectedStudent as Student;
                         Student._count--;
                         Students.Remove(temp_student);
                         DataBase.Relatives.RemoveRange(temp_student.ListRelatives);

                         if (SelectedTroop.NumberTroop != null)
                         {
                             SelectedTroop.ListStudents.Remove(temp_student);
                             SelectedTroop.StaffCount = SelectedTroop.ListStudents.Count;
                             Students = new BindingList<Student>(selectedTroop.ListStudents);
                         }
                         else
                         {
                             Troop temp = Troops.FirstOrDefault(u => u.NumberTroop == temp_student.Troop);
                             temp.ListStudents.Remove(temp_student);
                             temp.StaffCount = temp.ListStudents.Count;

                             if(temp.PlatoonCommander == temp_student)
                             {
                                 temp.Id_PC = 0;
                             }
                         }
                         DataBase.SaveChanges();
                     }
                     else if (res.ToString() == "No")
                     {
                         deleteCommand = null;
                         return;
                     }

                 }, (obj) => students.Count() > 0 && (ProgMode.ProgramMode == ProgramMode.Admin)));
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
		public RelayCommand OpenTemplate
		{
			get
			{
				return openTemplate ??
					(openTemplate = new RelayCommand(obj =>
					{
						//Templates temp = new Templates(students,);
					}));
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
                            selectedTroop = window_TC.troop_change();

                            window_TC.Close();

                            Students = new BindingList<Student>(selectedTroop.ListStudents);

                            SelectTroopNumber = selectedTroop.NumberTroop;

                        }
                    }));
            }
        }

        public string CurrentPrepod
        {
            get
            {
                return currentPrepod;
            }

            set
            {
                currentPrepod = value;
                OnPropertyChanged();
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
                    }));
            }
        }

        public List<string> List_Speciality
        {
            get
            {
                return list_Speciality;
            }

            set
            {
                list_Speciality = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand InfoCommand
        {
            get
            {
                return infoCommand ??
                    (infoCommand = new RelayCommand(obj =>
                    {
                        LKS_3._0.View.InfoWindow Info = new View.InfoWindow(Students, List_Troop, List_Group, List_Speciality);
                        if (Info.ShowDialog() == true)
                        {

                        }
                    }));
            }
        }

        public List<string> List_SpecInst
        {
            get
            {
                return list_SpecInst;
            }

            set
            {
                list_SpecInst = value;
                OnPropertyChanged();
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
                    }));
            }
        }

        public void Load_DB()
        {

            DataBase = new ApplicationContext();

            selectedTroop = new Troop();

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
                    item.PlatoonCommander = DataBase.Students.Local.FirstOrDefault(u => u.Id == item.Id_PC);
                }
                if (item.SboriTroop)
                {
                    item.ListStudents = new BindingList<Student>(DataBase.Students.Local.Where(u => u.NumSboriTroop == item.NumberTroop).ToList());
                    item.StaffCount = item.ListStudents.Count;
                }   
                else
                {
                    item.ListStudents = new BindingList<Student>(DataBase.Students.Local.Where(u => u.Troop == item.NumberTroop).ToList());
                    item.StaffCount = item.ListStudents.Count;
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

    }
}

