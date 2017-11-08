using System;
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
using System.Reflection;

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для EditPrepods.xaml
    /// </summary>
    public partial class EditPrepods : Window
    {
        EditPrepodsViewModel ViewModel = new EditPrepodsViewModel();

        public EditPrepods(IEnumerable<Prepod> main_prepods)
        {
            InitializeComponent();

            Binding_columns();

            DataContext = ViewModel;

            ViewModel.Prepods = main_prepods;
        }

        private void Binding_columns()
        {
            Type T = typeof(Prepod);
            PropertyInfo[] Property_Arr = T.GetProperties();
            foreach (PropertyInfo el in Property_Arr)
            {
                RusNameAttribute temp_attribute = (RusNameAttribute)el.GetCustomAttribute(typeof(RusNameAttribute));
                if (temp_attribute != null)
                {
                    DataGridTextColumn temp_column = new DataGridTextColumn();
                    temp_column.Header = temp_attribute.Get_RussianTittle;

                    Binding myNewBindDef = new Binding(el.Name);
                    temp_column.Binding = myNewBindDef;

                    PrepodGrid.Columns.Add(temp_column);
                }

            }
        }
    }
}
