﻿using System;
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
//using System.Windows.Shapes;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для WindowDatabase.xaml
    /// </summary>


    public partial class WindowDatabase : Window
    {
        bool connect;

        public WindowDatabase(bool flag, bool connect, bool data)
        {
            InitializeComponent();

            this.connect = connect;

            if (flag)
            {
                ProgMode.ProgramMode = ProgramMode.Admin;

            }
            else
            {
                ProgMode.ProgramMode = ProgramMode.Student;

            }

            DataContext = new ApplicationViewModel(connect, data);

            Binding_columns();

        }

        private void Binding_columns()
        {
            Type T = typeof(Student);
            PropertyInfo[] Property_Arr = T.GetProperties();
            foreach (PropertyInfo el in Property_Arr)
            {
                RusNameAttribute temp_attribute = (RusNameAttribute)el.GetCustomAttribute(typeof(RusNameAttribute));
                if (temp_attribute != null && (temp_attribute.Get_RussianTittle != "Звание"))
                {
                    DataGridTextColumn temp_column = new DataGridTextColumn();
                    temp_column.Header = temp_attribute.Get_RussianTittle;

                    Binding myNewBindDef = new Binding(el.Name);
                    temp_column.Binding = myNewBindDef;

                    StudentsGrid.Columns.Add(temp_column);
                }

            }
        }

        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();

            Student student = (Student)e.Row.DataContext;

            if (student.IsSuspended)
            {
                e.Row.Background = new SolidColorBrush(Colors.Yellow);
            }
            else if (student.Status == "Отстранен")
            {
                e.Row.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                e.Row.Background = new SolidColorBrush(Colors.LightGray);
            }
                
        }

        private void FindBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void _1_Checked(object sender, RoutedEventArgs e)
        {
            _1.IsChecked = true;
            _2.IsChecked = false;
            _3.IsChecked = false;
            _4.IsChecked = false;
            _5.IsChecked = false;
        }

        private void _2_Checked(object sender, RoutedEventArgs e)
        {
            _1.IsChecked = false;
            _2.IsChecked = true;
            _3.IsChecked = false;
            _4.IsChecked = false;
            _5.IsChecked = false;
        }

        private void _3_Checked(object sender, RoutedEventArgs e)
        {
            _1.IsChecked = false;
            _2.IsChecked = false;
            _3.IsChecked = true;
            _4.IsChecked = false;
            _5.IsChecked = false;
        }

        private void _4_Checked(object sender, RoutedEventArgs e)
        {
            _1.IsChecked = false;
            _2.IsChecked = false;
            _3.IsChecked = false;
            _4.IsChecked = true;
            _5.IsChecked = false;
        }

        private void _5_Checked(object sender, RoutedEventArgs e)
        {
            _1.IsChecked = false;
            _2.IsChecked = false;
            _3.IsChecked = false;
            _4.IsChecked = false;
            _5.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _1.IsChecked = false;
            _2.IsChecked = false;
            _3.IsChecked = false;
            _4.IsChecked = false;
            _5.IsChecked = false;
        }

        private void W_Data_Closed(object sender, EventArgs e)
        {
            if (connect)
            {
                UpdateLocalDataBase();
            }
        }

        public void UpdateLocalDataBase()
        {
            System.Diagnostics.Process _Process = null;
            _Process = System.Diagnostics.Process.Start(@"mysql2sqlite.exe");
        }
    }


}