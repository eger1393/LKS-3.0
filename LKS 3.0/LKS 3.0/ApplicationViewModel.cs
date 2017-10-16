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
        ApplicationContext DataBase;

        RelayCommand addCommand;
        //RelayCommand saveCommand;
        //RelayCommand editCommand;
        //RelayCommand deleteCommand;

        IEnumerable<Student> students;

        private Student selectedStudent;

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
                          DataBase.Students.Add(temp_student);
                          DataBase.SaveChanges();
                      SelectedStudent = temp_student;
                  }));
            }
        }

        //public RelayCommand SaveCommand
        //{
        //    get
        //    {
        //        return saveCommand ??
        //          (saveCommand = new RelayCommand(obj =>
        //          {
        //              DataBase.SaveChanges();
        //              DataBase.Dispose();
        //          }));
        //    }
        //}
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

