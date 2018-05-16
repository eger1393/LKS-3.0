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
    /// Логика взаимодействия для InfoSboriWindowOff.xaml
    /// </summary>
    public partial class InfoSboriWindowOff : Window
    {
        ApplicationContext DataBaseSb;
        public InfoSboriWindowOff(ref ApplicationContext temp_DataBase, BindingList<Troop> _troops, bool data)
        {
            InitializeComponent();

            Binding_columns();
                
            DataBaseSb = temp_DataBase;

            ViewModel.SummerSboriViewModel temp_VM  = new ViewModel.SummerSboriViewModel(ref temp_DataBase, _troops, data);

            DataContext = temp_VM;

			temp_VM.Troops = new BindingList<Troop>(_troops.Where(obj => obj.SboriTroop == true).ToList());//.Select(u => u.NumberTroop);
			if (temp_VM.CloseAction == null)
				temp_VM.CloseAction = new Action(() => this.Close());
		}

		//TODO Отрефакторить
        private void Binding_columns()
        {
            Type T = typeof(Model.Admin);
            Type B = typeof(bool?);
            PropertyInfo[] Property_Arr = T.GetProperties();
            AdminDataGrid.IsReadOnly = true;
            foreach (PropertyInfo el in Property_Arr)
            {
                RusNameAttribute temp_attribute = (RusNameAttribute)el.GetCustomAttribute(typeof(RusNameAttribute));

                if ((temp_attribute != null) && (el.PropertyType == B))
                    {
                    DataGridCheckBoxColumn _temp_column = new DataGridCheckBoxColumn();
                    _temp_column.Header = temp_attribute.Get_RussianTittle;

                    Binding _myNewBindDef = new Binding(el.Name);
                    _temp_column.Binding = _myNewBindDef;
                    AdminDataGrid.Columns.Add(_temp_column);
                }
                else if(temp_attribute != null)
                { 

                    DataGridTextColumn temp_column = new DataGridTextColumn();
                    temp_column.Header = temp_attribute.Get_RussianTittle;

                    Binding myNewBindDef = new Binding(el.Name);
                    temp_column.Binding = myNewBindDef;
                 
                    AdminDataGrid.Columns.Add(temp_column);
                }
               

            }
        }

       
	}
}
