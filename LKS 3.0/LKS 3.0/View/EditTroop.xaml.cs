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
    /// Логика взаимодействия для EditTroop.xaml
    /// </summary>
    public partial class EditTroop : Window
    {

        string[] days = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб" };
        public EditTroop(ref ApplicationContext temp_database)
        {
            InitializeComponent();

            comboBoxPrepods.ItemsSource = temp_database.Prepods.Local.ToBindingList();

            DataContext = new ViewModel.EditTroopViewModel(ref temp_database);

            Binding_columns();

        }

        private void Binding_columns()
        {
            Type T = typeof(Troop);
            PropertyInfo[] Property_Arr = T.GetProperties();
            foreach (PropertyInfo el in Property_Arr)
            {

                TroopGrid.IsReadOnly = true;
                RusNameAttribute temp_attribute = (RusNameAttribute)el.GetCustomAttribute(typeof(RusNameAttribute));
                if (temp_attribute != null)
                {
                    if(temp_attribute.Get_RussianTittle == "Взвод для сборов?")
                    {
                        DataGridCheckBoxColumn _temp_column = new DataGridCheckBoxColumn();
                        _temp_column.Header = temp_attribute.Get_RussianTittle;
                        _temp_column.IsReadOnly = false;
                        Binding _myNewBindDef = new Binding(el.Name);
                        _temp_column.Binding = _myNewBindDef;
                        TroopGrid.Columns.Add(_temp_column);
                    }
                    else if (temp_attribute.Get_RussianTittle == "День")
                    {
                        DataGridComboBoxColumn _temp_column = new DataGridComboBoxColumn();
                        _temp_column.Header = temp_attribute.Get_RussianTittle;
                        _temp_column.IsReadOnly = false;
                        Binding _myNewBindDef = new Binding(el.Name);
                        _temp_column.ItemsSource = days;
                        _temp_column.TextBinding = _myNewBindDef;
                        TroopGrid.Columns.Add(_temp_column);

                    }
                    else if(temp_attribute.Get_RussianTittle == "Личный состав (чел.)")
                    {
                        DataGridTextColumn temp_column = new DataGridTextColumn();
                        temp_column.Header = temp_attribute.Get_RussianTittle;
                        temp_column.IsReadOnly = true;
                        Binding myNewBindDef = new Binding(el.Name);
                        temp_column.Binding = myNewBindDef;
                        TroopGrid.Columns.Add(temp_column);
                    }
                    else
                    {
                        DataGridTextColumn temp_column = new DataGridTextColumn();
                        temp_column.Header = temp_attribute.Get_RussianTittle;
                        temp_column.IsReadOnly = false;
                        Binding myNewBindDef = new Binding(el.Name);
                        temp_column.Binding = myNewBindDef;
                        TroopGrid.Columns.Add(temp_column);
                    }    
                


                }
            }
        }

        private void button_Ok_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult res = MessageBox.Show("Закрыть окно?", "Внимание!", MessageBoxButton.YesNo);
            if (res.ToString() == "Yes")
            {
                DialogResult = true;
                Close();
            }
            else if (res.ToString() == "No")
            {

            }
        }
    }
}
