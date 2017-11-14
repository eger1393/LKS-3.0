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
        ProgramMode progMode;

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
            troopCheck;


        private Student selectedStudent;
        private Troop selectedTroop;
        BindingList<Student> students;
        private List<string> list_Troop,
            list_Rectal,
            list_Mname,
            list_Rank,
            list_Group; 
            //findItemsSource;

        private string ValueFind_T, ValueFind_G, ValueFind_M, ValueFind_R;


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

                List_Group = DataBase.Students.Local.Where(u => u.Troop == value).Select(u => u.Group).Distinct() as List<string>;

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
                List_Mname = DataBase.Students.Local.Where(u => u.Group == value).Select(u => u.MiddleName).Distinct() as List<string>;
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
                list_Troop= value;
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

               
        public string SelectTroopNumber
        {
            get
            {
                return selectedTroop.NumberTroop;
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


        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        private void Update_List()
        {
            List_Troop = DataBase.Troops.Local.Select(u => u.NumberTroop).Distinct() as List<string>;

            List_Group = DataBase.Students.Local.Select(u => u.Group).Distinct() as List<string>;

            List_Mname = DataBase.Students.Local.Select(u => u.MiddleName).Distinct() as List<string>;

            List_Rank = DataBase.Students.Local.Select(u => u.Rank).Distinct() as List<string>;

            List_Rectal = DataBase.Students.Local.Select(u => u.Rectal).Distinct() as List<string>;
            
            
            
        }
        public RelayCommand ShowAllCommand
        {
            get
            {
                return showAllCommand ??
                 (showAllCommand = new RelayCommand(obj =>
                 {
                     Students = DataBase.Students.Local.ToBindingList();
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
                         Students = DataBase.Students.Local.Where(u => u.Troop == SelectTroopNumber).Where(u => u.Status == "Обучается") as BindingList<Student>;
                     }
                     else
                     {
                         Students = DataBase.Students.Local.Where(u => u.Status == "Обучается") as BindingList<Student>;
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
                         Students = DataBase.Students.Local.Where(u => u.Troop == SelectTroopNumber).Where(u => u.Status == "Отстранен") as BindingList<Student>;
                     }
                     else
                     {
                         Students = DataBase.Students.Local.Where(u => u.Status == "Отстранен") as BindingList<Student>;
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
                         Students = DataBase.Students.Local.Where(u => u.Troop == SelectTroopNumber).Where(u => u.Status == "На сборах") as BindingList<Student>;
                     }
                     else
                     {
                         Students = DataBase.Students.Local.Where(u => u.Status == "На сборах") as BindingList<Student>;
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
                         Students = DataBase.Students.Local.Where(u => u.Troop == SelectTroopNumber).Where(u => u.Status == "Прошел сборы") as BindingList<Student>;
                     }
                     else
                     {
                         Students = DataBase.Students.Local.Where(u => u.Status == "Прошел сборы") as BindingList<Student>;
                     }
                 }));
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

                         
                 }));
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

                      AddStudent addStudentWindow = new AddStudent(temp_student, List_Troop, List_Rectal, List_Group, ref DataBase);

                      if (addStudentWindow.ShowDialog() == true)
                      {
                          DataBase.Students.Add(temp_student);
                          DataBase.SaveChanges();
                          SelectedStudent = temp_student;
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

                      AddStudent addStudentWindow = new AddStudent(temp_student, List_Troop, List_Rectal, List_Group, ref DataBase);

                      if (addStudentWindow.ShowDialog() == true)
                      {
                          DataBase.Students.Add(temp_student);
                          DataBase.Entry(temp_student).State = EntityState.Modified;
                          DataBase.SaveChanges();
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
                    },(obj) => (progMode == ProgramMode.Admin)));
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
                      CreateReport CR_Window = new CreateReport(this);
                      CR_Window.Show();
                  }));
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
                         Student student = selectedStudent as Student;
                         DataBase.Students.Remove(student);
                         DataBase.SaveChanges();
                         Student._count--;
                     }
                     else if (res.ToString() == "No")
                     {
                         deleteCommand = null;
                         return;
                     }

                 }, (obj) => students.Count() > 0 && progMode == ProgramMode.Admin));
                }
            
        }

        public RelayCommand FindCommand
        {
            get
            {
               
               
                    return findCommand ??
                                        (findCommand = new RelayCommand(select =>
                                        {
                                            

                                        Students = DataBase.Students.Local.Where(u => u.Troop == SelectedValueFind_T || u.Group == SelectedValueFind_G || u.Rank == SelectedValueFind_R || u.MiddleName == SelectedValueFind_M) as BindingList<Student>;
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
						Templates temp = new Templates(students);
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
                        TroopChange window_TC = new TroopChange(ref DataBase);

                        if (window_TC.ShowDialog() == true)
                        {
                            selectedTroop = window_TC.troop_change();
                            window_TC.Close();
                            if (selectedTroop.StaffCount == 0)
                            {
                                MessageBox.Show("Новый взвод №" + SelectTroopNumber + "создан!", "Внимание!");
                                //Students = new IEnumerable<Student>();
                            }
                            else
                            {
                                Students = DataBase.Students.Local.Where(u => u.Troop == SelectTroopNumber) as BindingList<Student>;
                            }

                        }
                    }));
            }
        }
        public ApplicationViewModel(ProgramMode _progMode)
        {
            progMode = _progMode;

            DataBase = new ApplicationContext();

            DataBase.Students.Load();

            DataBase.Troops.Load();

            Students = DataBase.Students.Local.ToBindingList();

            Student._count = DataBase.Students.Count();

            selectedTroop = new Troop();

            Update_List();

            //TroopChange window_TC = new TroopChange(ref DataBase);

            //if(window_TC.ShowDialog() == true)
            //{
            //    selectedTroop = window_TC.troop_change();
            //    window_TC.Close();
            //    if(selectedTroop.StaffCount == 0)
            //    {
            //        MessageBox.Show("Новый взвод №"+ selectedTroop.NumberTroop +"создан!", "Внимание!");
            //    }
            //    else
            //    {
            //        Students = DataBase.Students.Local.Where(u => u.Troop == selectedTroop.NumberTroop);
            //    }

            //}


        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}

