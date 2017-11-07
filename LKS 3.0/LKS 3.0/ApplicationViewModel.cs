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

namespace LKS_3._0
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        ProgramMode progMode;

        public ApplicationContext DataBase;

        RelayCommand addCommand;
        RelayCommand createReportCommand;
        RelayCommand findCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;
        RelayCommand saveChangeCommand;
        RelayCommand checkPassCommand;

        IEnumerable<Student> students;

        IEnumerable<string> list_Troop;
        IEnumerable<string> list_Rectal;
        private Student selectedStudent;
        private string findText;
       public string FindText
        {
            get { return findText; }
            set
            {
                if (value == "")
                {
                    Students = DataBase.Students.Local.ToBindingList();
                }
                findText = value;
                OnPropertyChanged("FindText");
            }
        }
        public IEnumerable<Student> Students
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

       
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Student temp_student = new Student();
                      list_Troop = DataBase.Students.Local.Select(u => u.Troop).Distinct();
                      list_Rectal = DataBase.Students.Local.Select(u => u.Rectal).Distinct();
                      AddStudent addStudentWindow = new AddStudent(temp_student, list_Troop, list_Rectal);

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
                      list_Troop = DataBase.Students.Local.Select(u => u.Troop).Distinct();
                      list_Rectal = DataBase.Students.Local.Select(u => u.Rectal).Distinct();
                      AddStudent addStudentWindow = new AddStudent(temp_student, list_Troop, list_Rectal);
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
                        // получаем выделенный объект
                        Student student = selectedStudent as Student;
                        DataBase.Students.Remove(student);
                        DataBase.SaveChanges();
                    }, (obj) => students.Count() > 0));
            }
        }

        public RelayCommand FindCommand
        {
            get
            {
               
               
                    return findCommand ??
                                        (findCommand = new RelayCommand(select =>
                                        {
                                            switch ((int)select)
                                            {
                                                case 0:
                                                    {
                                                        Students = DataBase.Students.Local.Where(u => u.MiddleName == FindText);
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        Students = DataBase.Students.Local.Where(u => u.Troop == FindText);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Students = DataBase.Students.Local.Where(u => u.Group == FindText);
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Students = DataBase.Students.Local.Where(u => u.Rank == FindText);
                                                        break;
                                                    }
                                                default:
                                                    break;
                                            }
                                        }, (obj) => FindText != ""));
                
                
            }
        }
        public ApplicationViewModel(ProgramMode _progMode)
        {
            progMode = _progMode;

            DataBase = new ApplicationContext();

            DataBase.Students.Load();

            Students = DataBase.Students.Local.ToBindingList();



            //Students = new ObservableCollection<Student>
            //{
            //   new Student("Мещеряков", "Антон", "Сергеевич", "3ВТИ-3ДБ-039", "410", "+7(985)191-84-48"),
            //   new Student("Голвянский", "Кирилл", "Сергеевич", "3ВТИ-3ДБ-037", "410", "+7(985)222-84-48"),
            //   new Student("Алешин", "Роман", "Анатольевич", "3ВТИ-3ДБ-039", "410", "+7(988)123-22-13")
            // };
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}

