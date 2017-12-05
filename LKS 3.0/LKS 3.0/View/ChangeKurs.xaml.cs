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
using System.Windows;
namespace LKS_3._0.View
{
    /// <summary>
    /// Логика взаимодействия для ChangeKurs.xaml
    /// </summary>
    public partial class ChangeKurs : Window
    {
        BindingList<Student> students;
        public ChangeKurs(BindingList<Student> _students)
        {
            InitializeComponent();

            students = _students;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(radioButtonNext.IsChecked == true)
            {
                foreach (var item in students)
                {
                    if (item.Kurs < 4)
                        item.Kurs++;
                }
                Close();
            }
            else if (radioButtonPrev.IsChecked == true)
            {
                foreach (var item in students)
                {
                    if (item.Kurs >1)
                        item.Kurs--;
                }
                Close();
            }
            else
            {
                MessageBox.Show("Выберите операцию!", "Ошибка!");
            }
        }
    }
}
