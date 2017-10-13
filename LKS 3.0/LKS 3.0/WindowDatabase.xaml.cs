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

            Binding_columns();

            DataContext = new ApplicationViewModel();
      
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
    }
  
}