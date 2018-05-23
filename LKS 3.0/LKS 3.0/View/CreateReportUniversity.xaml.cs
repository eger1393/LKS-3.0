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

namespace LKS_3._0.View
{
	/// <summary>
	/// Логика взаимодействия для CreateReportUniversity.xaml
	/// </summary>
	public partial class CreateReportUniversity : Window
	{
		ViewModel.CreateReportUniversityViewModel ViewModel;
		public CreateReportUniversity(ViewModel.CreateReportUniversityViewModel VM)
		{
			InitializeComponent();

			ViewModel = VM;
			DataContext = ViewModel;
			if (ViewModel.CloseAction == null)
				ViewModel.CloseAction = new Action(() => this.Close());

		}

		private void TbOnlyDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!char.IsDigit(e.Text.ToString()[0]))
			{
				e.Handled = true;
			}
		}

		private void SelectAll_Click(object sender, RoutedEventArgs e)
		{
			listBoxStudents.SelectAll();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			listBoxStudents.SelectedIndex = -1;
		}
	}
}
