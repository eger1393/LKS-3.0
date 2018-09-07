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
        ApplicationContext temp_database;

        Troop t_troop;

        BindingList<Troop> _Troops;

        public TroopChange(ref ApplicationContext database)
        {
            InitializeComponent();

            temp_database = database;

            _Troops = temp_database.Troops.Local.ToBindingList();

            

            CbTroop.ItemsSource = _Troops.Where(u => u.SboriTroop == false && u.NumberTroop != null).Distinct().ToList();
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            if(CbTroop.Text != "")
            {
                t_troop = _Troops.FirstOrDefault(u => u.NumberTroop == CbTroop.Text);
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

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            if(TB_TroopName.Text != "")
            {
                //Troop._count++;

                t_troop = new Troop(TB_TroopName.Text);

                //t_troop.Id = Troop._count;

                MessageBox.Show("Новый взвод № " + t_troop.NumberTroop + " создан!", "Внимание!");

                _Troops.Add(t_troop);

                temp_database.SaveChanges();// оно тут надо или нет???

                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введите название взвода!", "Внимание!");

            }
         
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
