using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Data.Entity;

namespace LKS_3._0.View
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        List<string> List_T, List_G, List_S;
        List<int> List_K;
        BindingList<Student> Students;
        BindingList<Student> temp_students;
        private void buttonCalc_Click(object sender, RoutedEventArgs e)
        {
            switch (comboBoxInfo.SelectedIndex)
            {
                case 0:
                    {
                        textBlockAll.Text = Students.Count.ToString();
                        break;
                    }
                default:
                    {
                        textBlockAll.Text = Students.Where(u => u.Troop == comboBoxInfo.Text).Count().ToString();
                        break;
                    }

            }

            if (comboBoxInfo.SelectedIndex != 0)
            {
                temp_students = new BindingList<Student>(Students.Where(u => u.Troop == comboBoxInfo.Text).ToList());
            }
            else
            {
                temp_students = Students;
            }

            switch (comboBoxKrit.SelectedIndex)
            {
                case 0:
                    {
                        
                        textBlockKrit.Text = temp_students.Where(u => u.SpecialityName == comboBoxValue.Text).Count().ToString();
                        break;
                    }

                case 1:
                    {
                        textBlockKrit.Text = temp_students.Where(u => u.Group == comboBoxValue.Text).Count().ToString();
                        break;
                    }

                case 2:
                    {
                        textBlockKrit.Text = temp_students.Where(u => u.Kurs == (int)comboBoxValue.SelectedItem).Count().ToString();
                        break;
                    }

                default:
                    {
                        break;
                    }
                   
            }
        }

        public InfoWindow(ref ApplicationContext data, List<string> list_Troop, List<string> list_Group, List<string> list_Speciality)
        {

            InitializeComponent();

			Students = data.Students.Local.ToBindingList();
            List_T = list_Troop;
            List_T.Insert(0, "Все взвода");

            List_G = list_Group;

            List_S = list_Speciality;

            int[] List_Kurs = { 2,3,4 };
            List_K = new List<int>(List_Kurs);

            
            comboBoxInfo.ItemsSource = List_T;
            
        }

        private void comboBoxKrit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxValue.ItemsSource = null;

            switch (comboBoxKrit.SelectedIndex)
            {
                case 0:
                    {
                        comboBoxValue.ItemsSource = List_S;
                        break;
                    }

                case 1:
                    {
                        comboBoxValue.ItemsSource = List_G;
                        break;
                    }

                case 2:
                    {
                        comboBoxValue.ItemsSource = List_K;
                        break;
                    }

                default:
                    break;
            }
            
        }
    }
}
