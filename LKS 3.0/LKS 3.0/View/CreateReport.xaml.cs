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
		ViewModel.CreateReportViewModel createReportViewModel;

		public CreateReport(ViewModel.CreateReportViewModel VM)
        {
            InitializeComponent();

			createReportViewModel = VM;
            DataContext = createReportViewModel;

			
				//Troop_CR_comboBox.ItemsSource = VM.DataBase.Students.Local.Select(u => u.Troop).Distinct();
			LBList.ItemsSource = VM.Students;
			LBSelectedList.ItemsSource = VM.SelectedStudents;
			//LBList.SelectedItem

        }

        

        

		

		private void bSelectTemplate_Click(object sender, RoutedEventArgs e)
		{

		}

		private void bStatr_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
