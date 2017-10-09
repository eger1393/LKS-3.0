using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.Entity;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using System.Data.SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для WindowDatabase.xaml
    /// </summary>

    public partial class WindowDatabase : Window
    {
        ApplicationContext dbStudent;
        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {

            }
            public DbSet<Student> Students { get; set; }
        }
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

            dbStudent = new ApplicationContext();

            dbStudent.Students.Load();

            StudentsGrid.ItemsSource = dbStudent.Students;

        }

        private void Binding_columns()
        {
            Type T = typeof(Student);
            PropertyInfo[] Property_Arr = T.GetProperties();
            foreach (PropertyInfo el in Property_Arr)
            {
                RusNameAttribute temp_attribute = (RusNameAttribute)el.GetCustomAttribute(typeof(RusNameAttribute));

                DataGridTextColumn temp_column = new DataGridTextColumn();
                temp_column.Header = temp_attribute.Get_RussianTittle;

                Binding myNewBindDef = new Binding(el.Name);
                temp_column.Binding = myNewBindDef;

                StudentsGrid.Columns.Add(temp_column);
            }
        }
        private void StudentsGrid_Loaded(object sender, RoutedEventArgs e)
        {   
            dbStudent.Students.Add(new Student(1,"Мещеряков", "Антон", "Сергеевич", "3ВТИ-3ДБ-039", "410", "+7(985)191-84-48"));
            dbStudent.Students.Add(new Student(2,"Голвянский", "Кирилл", "Сергеевич", "3ВТИ-3ДБ-037", "410", "+7(985)222-84-48"));
            dbStudent.Students.Add(new Student(3,"Алешин", "Роман", "Анатольевич", "3ВТИ-3ДБ-039", "410", "+7(988)123-22-13"));
            dbStudent.SaveChanges();

            Binding_columns();    
        }

        private void StudentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            show_student((Student)StudentsGrid.SelectedItem);
        }

        private void show_student(Student temp)
        {
            if (temp != null)
            {
                Label_FIO.Content = temp.MiddleName + " " + temp.FirstName + " " + temp.LastName;
                Label_vzvod.Content = temp.Troop;
                //Label_rang.Content = temp.Rank;
                Label_phone.Content = temp.MobilePhone;
            }
            else
            {
                Label_FIO.Content = "";
                Label_vzvod.Content = "";
                Label_rang.Content = "";
                Label_phone.Content = "";
            }
        }

    }
    [System.AttributeUsage(AttributeTargets.All)] //, Inherited = false, AllowMultiple = true)
    public class RusNameAttribute : Attribute
    {
        readonly string RussianTittle;

        public RusNameAttribute(string RusName)
        {
            this.RussianTittle = RusName;
        }

        public string Get_RussianTittle
        {
            get { return RussianTittle; }
        }
    }
    public partial class Student
    {
        public enum Student_Rank
        {
            Командир_взвода = 1,
            Заместитель_КВ,
            КО1,
            КО2,
            КО3,
            Журналист,
            Заместитель_журналиста,
            Студент
        }
        public Student() // Конструктор по умолчанию
        {
            ID = 0;
            MiddleName = "";
            FirstName = "";
            LastName = "";
            MobilePhone = "";
            //HomePhone = "";
            Group = "";
            //SpecialityName = "";
            //Rank = 0;
            //Nationality = 0;
            //Citizenship = "";
        }

        public Student(int ID,string M_name, string F_name, string L_name, string group, string troop,string phone) //, Student_Rank rang)
        {
            this.ID = ID;
            this.MiddleName = M_name;
            this.FirstName = F_name;
            this.LastName = L_name;
            this.Group = group;
            this.Troop = troop;
            this.MobilePhone = phone;
            //this.Rank = rang;
        }

        public int ID
        { get; set; }

        [RusName("Фамилия")]
        public string MiddleName // Фамилия
        { get; set; }

        [RusName("Имя")]
        public string FirstName // Имя
        { get; set; }
        [RusName("Отчество")]
        public string LastName // Отчество
        { get; set; }
        [RusName("Взвод")]
        public string Troop // Взвод
        { get; set; }

        [RusName("Группа")]
        public string Group
        { get; set; } // Группа студента

        [RusName("Телефон")]
        public string MobilePhone // Номер моильного телефона
        { get; set; }

 

        //[RusName("Звание")]
        //public Student_Rank Rank // Звание студента (перечисление)
        //{ get; set; }

        //string HomePhone // Номер домашнего телефона
        //{ get; set; }


        //// TODO добавить перечесление специальностей после уточнения(?), перечисление званий, национальностей

        //// возможно извенить поле на целочисленное и исспользовать перечисление
        //string SpecialityName
        //{ get; set; } // Название специальности



        //ushort Nationality // Национальность (перечисление)
        //{ get; set; }

        //string Citizenship // Гражданство
        //{ get; set; }

        //public string Добавить_поле { get; set; }



    }

}