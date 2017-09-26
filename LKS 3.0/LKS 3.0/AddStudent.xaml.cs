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
	/// Логика взаимодействия для AddStudent.xaml
	/// </summary>
	public partial class AddStudent : Window
	{
		public AddStudent()
		{
			InitializeComponent();
		}

		//
		// фильтрация ввода
		//

		private void TbOnlyLetter_PreviewTextInput(object sender, TextCompositionEventArgs e) //
		{
			if (!char.IsLetter(e.Text.ToString()[0]))
			{
				e.Handled = true;
			}
		}
		
		private void TbOnlyDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!char.IsDigit(e.Text.ToString()[0]))
			{
				e.Handled = true;
			}
		}

		private void TbAverageScore_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{

			if (!char.IsDigit(e.Text.ToString()[0]))
			{
				//если какойто из символов разделителе встречается в строке и если строка пуста gecnf, то не добавляем новый разделитель
				if ((e.Text == "," || e.Text == ".") && (((TextBox)sender).Text.IndexOf(',') != -1 || ((TextBox)sender).Text.IndexOf('.') != -1)
					|| ((TextBox)sender).Text.Length == 0)
				{
					e.Handled = true;
				}
			}
		}
	}
}
