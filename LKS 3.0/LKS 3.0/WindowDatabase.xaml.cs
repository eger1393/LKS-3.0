﻿using System;
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
using System.Reflection;

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для WindowDatabase.xaml
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All)] //, Inherited = false, AllowMultiple = true)
    sealed class RusNameAttribute : Attribute
    {
        readonly string positionalString;

        public RusNameAttribute(string RusName)
        {
            this.positionalString = RusName;
        }

        public string PositionalString
        {
            get { return positionalString; }
        }
    }

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

            Type t = typeof(Student);
            PropertyInfo[] m = t.GetProperties();
            foreach (PropertyInfo el in m)
            {
                label111.Content += ("|" + el.Name + "+" + el.Attributes);
            }
        


        }

        private void StudentsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Student> Data_Student = new List<Student>(3);
            Data_Student.Add(new Student("Мещеряков","Антон","Сергеевич","3ВТИ-3ДБ-039","410","+7(985)191-84-48",Student.Student_Rank.Студент));
            Data_Student.Add(new Student("Голвянский", "Кирилл", "Сергеевич", "3ВТИ-3ДБ-037", "410", "+7(985)222-84-48", Student.Student_Rank.Командир_взвода));
            Data_Student.Add(new Student("Алешин", "Роман", "Анатольевич", "3ВТИ-3ДБ-039", "410", "+7(988)123-22-13", Student.Student_Rank.Журналист));

            //int length = 7;
    
            //for (int i = 0; i <= length; i++)
            //{
                DataGridTextColumn obj = new DataGridTextColumn();
                obj.Header = "Фамилия";
                Binding myNewBindDef = new Binding("FirstName");
                obj.Binding = myNewBindDef;
                StudentsGrid.Columns.Add(obj);
            //}

            StudentsGrid.ItemsSource = Data_Student;

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
                Label_rang.Content = temp.Rank;
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
            MiddleName = "";
            FirstName = "";
            LastName = "";
            MobilePhone = "";
            HomePhone = "";
            Group = "";
            SpecialityName = "";
            Rank = 0;
            Nationality = 0;
            Citizenship = "";
        }

        public Student(string M_name, string F_name, string L_name, string group, string troop,string phone, Student_Rank rang)
        {
            this.MiddleName = M_name;
            this.FirstName = F_name;
            this.LastName = L_name;
            this.Group = group;
            this.Troop = troop;
            this.MobilePhone = phone;
            this.Rank = rang;
        }


        [RusNameAttribute("Фамилия")]
        public string MiddleName // Имя
        { get; set; }

        public string FirstName // Фамилия
        { get; set; }

        public string LastName // Отчество
        { get; set; }

        public string Troop // Отчество
        { get; set; }

        public string MobilePhone // Номер моильного телефона
        { get; set; }

        string HomePhone // Номер домашнего телефона
        { get; set; }

        public string Group
        { get; set; } // Группа студента

        // TODO добавить перечесление специальностей после уточнения(?), перечисление званий, национальностей

        // возможно извенить поле на целочисленное и исспользовать перечисление
        string SpecialityName
        { get; set; } // Название специальности

        public Student_Rank Rank // Звание студента (перечисление)
        { get; set; }

        ushort Nationality // Национальность (перечисление)
        { get; set; }

        string Citizenship // Гражданство
        { get; set; }

        //public string Добавить_поле { get; set; }
    

       
    }

}