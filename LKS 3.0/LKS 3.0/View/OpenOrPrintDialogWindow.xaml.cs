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
	/// Логика взаимодействия для OpenOrPrintDialogWindow.xaml
	/// </summary>
	public partial class OpenOrPrintDialogWindow : Window
	{
		ViewModel.OpenOrPrintDialogViewModel ViewModel;
		public OpenOrPrintDialogWindow(ViewModel.OpenOrPrintDialogViewModel VM)
		{
			InitializeComponent();
			ViewModel = VM;
			DataContext = ViewModel;
			if (ViewModel.CloseAction == null)
				ViewModel.CloseAction = new Action(() => this.Close());
		}
	}
}
