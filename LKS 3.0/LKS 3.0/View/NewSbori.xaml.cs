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

        public NewSbori(ref ApplicationContext temp_DataBase)
        {
            InitializeComponent();

            DataBaseSb = temp_DataBase;

            comboBoxCurrent.ItemsSource = DataBaseSb.Troops.Local.Where(u => u.ToString().Count() > 1);

            comboBoxSbori.ItemsSource = DataBaseSb.Troops.Local.Where(u => u.ToString().Count() == 1);

            comboBoxPrepods.ItemsSource = DataBaseSb.Prepods.Local.ToBindingList();

            DataContext = new ViewModel.NewSboriViewModel(ref temp_DataBase);
        }

        private void Exelent_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult res = MessageBox.Show("Закрыть окно?", "Внимание!", MessageBoxButton.YesNo);
            if (res.ToString() == "Yes")
            {
                DialogResult = true;
                Close();
            }
            else if (res.ToString() == "No")
            {
                DataBaseSb.SaveChanges();
            }
       
        }

        private void Cancel_Copy_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void buttonSelectAll_Click(object sender, RoutedEventArgs e)
        {
            LBCurrent.SelectAll();
        }

        private void buttonInSelect_Click(object sender, RoutedEventArgs e)
        {
            foreach ( var item in LBCurrent.SelectedItems)
            {

            }
        }

        private void buttonSboriSelectAll_Click(object sender, RoutedEventArgs e)
        {
            LBSbori.SelectAll();
        }
    }
}
