﻿using System;
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
        public ApplicationContext DataBase;

        RelayCommand addCommand;
        RelayCommand createReportCommand;
        RelayCommand findCommand;
        RelayCommand deleteCommand;
        RelayCommand saveChangeCommand;

        IEnumerable<Student> students;

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
					  AddStudent addStudentWindow = new AddStudent(temp_student);
                      if (addStudentWindow.ShowDialog() == true)
                      {
                          DataBase.Students.Add(temp_student);
                          DataBase.SaveChanges();
                          SelectedStudent = temp_student;
                      }                     
                  }));
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
        public ApplicationViewModel()
        {
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

