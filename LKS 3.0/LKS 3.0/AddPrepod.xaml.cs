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

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для AddPrepod.xaml
    /// </summary>
    public partial class AddPrepod : Window
    {
        public AddPrepod(Prepod temp)
        {
            InitializeComponent();

            DataContext = temp;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
