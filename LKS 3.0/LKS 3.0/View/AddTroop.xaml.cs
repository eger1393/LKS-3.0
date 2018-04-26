﻿using System;
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

namespace LKS_3._0.View
{
    /// <summary>
    /// Логика взаимодействия для AddTroop.xaml
    /// </summary>
    public partial class AddTroop : Window
    {
        Troop tr_temp;
        public AddTroop(Troop temp)
        {
            InitializeComponent();

            DataContext = temp;

            tr_temp = temp;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(checkBox_Sbori.IsChecked == true)
            {
                foreach (var item in tr_temp.Students)
                {
                    item.Status = "На сборах";
                }
            }
            else
            {
                foreach (var item in tr_temp.Students)
                {
                    item.Status = "Обучается";
                }
            }
            DialogResult = true;
            Close();
        }
    }
}
