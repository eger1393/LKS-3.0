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
    /// Логика взаимодействия для InfoSboriWindow.xaml
    /// </summary>
    public partial class InfoSboriWindow : Window
    {
        ApplicationContext DataBaseSb;
        public InfoSboriWindow(ref ApplicationContext temp_DataBase, BindingList<Troop> _troops)
        {
            InitializeComponent();

            DataBaseSb = temp_DataBase;

            ViewModel.SummerSboriViewModel temp_VM  = new ViewModel.SummerSboriViewModel(ref temp_DataBase, _troops);

            DataContext = temp_VM.selectedSummerSbori;

            TroopComboBox.ItemsSource = _troops.Select(u => u.NumberTroop);
            TroopComboBoxAll.ItemsSource = TroopComboBox.ItemsSource;
        }

        private void ОКbutton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
