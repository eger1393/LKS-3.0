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
    /// Логика взаимодействия для SummerOrders.xaml
    /// </summary>
    public partial class SummerOrders : Window
    {
        ApplicationContext DataBaseSb;
        public SummerOrders(ref ApplicationContext temp_DataBase, BindingList<Student> students, BindingList<Troop> _troops)
        {
            InitializeComponent();

            Binding_columns();

            DataBaseSb = temp_DataBase;

            ViewModel.SummerSboriViewModel temp_VM = new ViewModel.SummerSboriViewModel(ref temp_DataBase, students, _troops,true);

            DataContext = temp_VM;

            TroopComboBox.ItemsSource = _troops.Select(u => u.NumberTroop);
            TroopComboBox2.ItemsSource = TroopComboBox.ItemsSource;
            TroopComboBox3.ItemsSource = TroopComboBox.ItemsSource;
        }

        private void Binding_columns()
        {
            string info = "ЗваниеДолжностьФамилияИмяОтчествоГруппаВзвод";
            Type T = typeof(Student);
            PropertyInfo[] Property_Arr = T.GetProperties();
            foreach (PropertyInfo el in Property_Arr)
            {
                RusNameAttribute temp_attribute = (RusNameAttribute)el.GetCustomAttribute(typeof(RusNameAttribute));

                if ((temp_attribute != null) && (info.IndexOf(temp_attribute.Get_RussianTittle) > -1))
                {
                    DataGridTextColumn temp_column = new DataGridTextColumn();
                    temp_column.Header = temp_attribute.Get_RussianTittle;

                    Binding myNewBindDef = new Binding(el.Name);
                    temp_column.Binding = myNewBindDef;

                    StudentDataGrid.Columns.Add(temp_column);
                }
            }
        }

        private void ОКbutton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
