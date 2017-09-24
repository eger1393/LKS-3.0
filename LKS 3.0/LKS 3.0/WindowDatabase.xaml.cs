using System;
using System.Collections.Generic;
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

         enum ProgramMode {Admin, Student}
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
    }

    public partial class Student
    {
        public string FIO { get; set; }
        public string Group { get; set; }
        public int Kurs { get; set; }
    }
}
