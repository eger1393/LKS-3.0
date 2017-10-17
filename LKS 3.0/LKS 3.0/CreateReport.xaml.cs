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
using System.Data.Entity;

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для CreateReport.xaml
    /// </summary>
    public partial class CreateReport : Window
    {
        ApplicationViewModel VM_CreateReport;
        public CreateReport(ApplicationViewModel VM)
        {
            InitializeComponent();

            DataContext = VM;

            VM_CreateReport = VM;

            Troop_CR_comboBox.ItemsSource = VM.DataBase.Students.Local.Select(u => u.Troop).Distinct();

        }

        private void Troop_CR_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CR_listBox.ItemsSource = VM_CreateReport.DataBase.Students.Local.Where(u => u.Troop == Troop_CR_comboBox.SelectedValue.ToString()).Select(u => u.MiddleName);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string[] keys = { "Мещеряков", "Антон", "Сергеевич", "28.02.1998", "г.Москва" };
            new GeneratedClass().CreatePackage(".\\LKS.docx",keys);
        }
    }
}
