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
			
		}
	}
}
