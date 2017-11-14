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
    /// Логика взаимодействия для NewSbori.xaml
    /// </summary>
    public partial class NewSbori : Window
    {
        ApplicationContext DataBaseSb;
        public NewSbori(ref ApplicationContext temp_DataBase, IEnumerable<string> List_Troop)
        {
            InitializeComponent();

            DataBaseSb = temp_DataBase;

            temp_DataBase.Prepods.Load();

            comboBoxCurrent.ItemsSource = List_Troop;

            comboBoxPrepods.ItemsSource = temp_DataBase.Prepods.Local.Select(u => u.ToString());

            DataContext = new ViewModel.NewSboriViewModel(ref temp_DataBase);
        }
    }
}
