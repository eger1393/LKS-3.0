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

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для TroopChange.xaml
    /// </summary>
    public partial class TroopChange : Window
    {
        Troop t_troop;

        BindingList<Troop> _Troops;

        public TroopChange(ref ApplicationContext database, BindingList<Troop> troops)
        {
            InitializeComponent();

            _Troops = troops;

            CbTroop.ItemsSource = _Troops.Where(u => u.SboriTroop == false && u.NumberTroop != null).Distinct().ToList();
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            if(CbTroop.Text != "")
            {
                t_troop = (Troop)CbTroop.SelectedItem;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Выберите взвод!", "Внимание!");
            }

            
        }
        public Troop troop_change()
        {
            return t_troop;
        }

        private void TbOnlyDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text.ToString()[0]))
            {
                e.Handled = true;
            }
        }
    }
}
