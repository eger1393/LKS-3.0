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

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для TroopChange.xaml
    /// </summary>
    public partial class TroopChange : Window
    {
        ApplicationContext temp_database;
        Troop t_troop;
        IEnumerable<string> ListTroop;
        public TroopChange(ref ApplicationContext database)
        {
            InitializeComponent();

            temp_database = database;

            ListTroop = temp_database.Troops.Local.Select(u => u.NumberTroop);

            CbTroop.ItemsSource = ListTroop;
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            t_troop = temp_database.Troops.Local.Where(u => u.NumberTroop == CbTroop.Text).First();
            DialogResult = true;
        }
        public Troop troop_change()
        {
            return t_troop;
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            Troop._count++;
            t_troop = new Troop(TB_TroopName.Text);
            t_troop.Id = Troop._count;
            MessageBox.Show("Новый взвод №" + t_troop.NumberTroop + "создан!", "Внимание!");
            temp_database.Troops.Add(t_troop);
            temp_database.SaveChanges();
            DialogResult = true;
        }
    }
}
