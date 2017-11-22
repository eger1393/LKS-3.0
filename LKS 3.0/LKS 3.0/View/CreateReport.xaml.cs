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
		//string fileName;

		public CreateReport(ViewModel.CreateReportViewModel VM)
        {
            InitializeComponent();

			createReportViewModel = VM;
            DataContext = createReportViewModel;

			
				//Troop_CR_comboBox.ItemsSource = VM.DataBase.Students.Local.Select(u => u.Troop).Distinct();
			LBList.ItemsSource = VM.Students;
			LBSelectedList.ItemsSource = VM.SelectedStudents;
			LBTroopList.ItemsSource = VM.Troops;
			LBTroopSelectedList.ItemsSource = VM.SelectedTroops;



		}







		private void bSelectTemplate_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog(); // создали новое диалоговое окно
			dlg.Filter = "Word files (*.doc, *.docx)|*.doc; *.docx"; // добавили фильтер
			if (dlg.ShowDialog() == true) // запустили окно
			{
				lSelectedTemplate.Content = "Загруженный шаблон: " + dlg.FileName;
			    createReportViewModel.FileName = dlg.FileName;
			}
		}

	}
}
