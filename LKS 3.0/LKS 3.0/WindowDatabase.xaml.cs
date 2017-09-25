using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для WindowDatabase.xaml
    /// </summary>


    public partial class WindowDatabase : Window
    {

        enum ProgramMode { Admin, Student }
        public WindowDatabase()
        {
            InitializeComponent();
        }

        public WindowDatabase(bool flag)
        {
            InitializeComponent();

            ProgramMode ProgMode = new ProgramMode();

            if (flag)
            {
                ProgMode = ProgramMode.Admin;
                StudentsGrid.IsReadOnly = false;
            }
            else
            {
                ProgMode = ProgramMode.Student;
                StudentsGrid.IsReadOnly = true;
            }




        }

        private void StudentsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Student> Data_Student = new List<Student>(3);
            Data_Student.Add(new Student("Мещеряков А.С.", "3ВТИ-3ДБ-039", 3));
            Data_Student.Add(new Student("Балыко Е.", "3ВТИ-3ДБ-039", 3));
            Data_Student.Add(new Student("Алешин Р.", "3ВТИ-3ДБ-039", 3));
            Data_Student.Add(new Student("Голтвянский К.", "3ВТИ-3ДБ-037", 3));



            //Collection<DataGridTextColumn> D_Column = new Collection<DataGridTextColumn>();


            //DataGridTextColumn obj = new DataGridTextColumn();
            //Binding myNewBindDef = new Binding("ФИО");
            //myNewBindDef.Source = TryFindResource("student");
            //obj.Binding = myNewBindDef;
            //D_Column.Add(obj);

            //obj = new DataGridTextColumn();
            //Binding myNewBindDef2 = new Binding("Группа");
            //myNewBindDef2.Source = TryFindResource("student");
            //obj.Binding = myNewBindDef2;
            //D_Column.Add(obj);

            //obj = new DataGridTextColumn();
            //Binding myNewBindDef3 = new Binding("Курс");
            //myNewBindDef3.Source = TryFindResource("student");
            //obj.Binding = myNewBindDef3;
            //D_Column.Add(obj);

            //StudentsGrid.DataContext = D_Column;

            StudentsGrid.ItemsSource = Data_Student;
        }
    }

    public partial class Student
    {
        public Student()
        {

        }
        public Student(string fio, string group, int kurs)
        {
            this.ФИО = fio;
            this.Группа = group;
            this.Курс = kurs;
        }
        public string ФИО { get; set; }
        public string Группа { get; set; }
        public int Курс { get; set; }
    }

}