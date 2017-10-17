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
		// блок фильтрация ввода
		//

		private void TbOnlyLetter_PreviewTextInput(object sender, TextCompositionEventArgs e) //
		{
			if (!char.IsLetter(e.Text.ToString()[0]))
			{
				e.Handled = true;
			}
		}

		private void TbDigitOrLetter_PreviewTextInput(object sender, TextCompositionEventArgs e) //
		{
			if (!(char.IsDigit(e.Text.ToString()[0]) || char.IsLetter(e.Text.ToString()[0])))
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

		// Обработка ввода даты
		private void TbDate_PreviewTextInput(object sender, TextCompositionEventArgs e) //
		{
			if (!(char.IsDigit(e.Text.ToString()[0]) || e.Text.ToString()[0] =='.'))
			{
				e.Handled = true;
			}
		}

		// обработка ввода моббильного телефона( всякие красивости)
		private void TbMobailPhone_PreviewKeyDown(object sender, KeyEventArgs e) // обработка нажатияя клавишь при вводе номера мобильника
		{
			TextBox obj = (TextBox)sender;
			int [] arr = { 8, 12, 15};
			if (e.Key == Key.Delete || e.Key == Key.Back)
			{
				if (obj.Text.Length == 3)
				{
					e.Handled = true;
				}
				foreach(int i in arr)
				{
					if (obj.Text.Length == i)
					{
						obj.Text = obj.Text.Remove(i - 2);
						e.Handled = true;
						obj.SelectionStart = obj.Text.Length;
					}
				}
			}
		}

		private void TbMobailPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!char.IsDigit(e.Text.ToString()[0]))
			{
				e.Handled = true;
			}

			TextBox obj = (TextBox)sender;
			if (obj.Text.Length == 5)
			{
				obj.Text += e.Text + ")";
				obj.SelectionStart = obj.Text.Length;
				e.Handled = true;
			}

			if (obj.Text.Length == 9 || obj.Text.Length == 12)
			{
				obj.Text += e.Text + "-";
				obj.SelectionStart = obj.Text.Length;
				e.Handled = true;
			}

			if(obj.Text.Length < 3)
			{
				obj.Text = "+7(";
				obj.SelectionStart = obj.Text.Length;
				e.Handled = true;
			}
		}

		private void TbMobailPhone_LostFocus(object sender, RoutedEventArgs e)
		{
			if (((TextBox)sender).Text.Length == 3)
			{
				((TextBox)sender).Text = "";
            }
		}

		private void TbMobailPhone_GotFocus(object sender, RoutedEventArgs e)
		{
			if (((TextBox)sender).Text.Length == 0)
			{
				((TextBox)sender).Text = "+7(";
				((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            }
        }
		// Конец блока обработки ввода мобильника

		// Обработка ввода домашнего телефона, разрешены символы ( ) - + и все цифры
		private void TbHomePhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!(char.IsDigit(e.Text.ToString()[0]) || e.Text.ToString()[0] == '(' || e.Text.ToString()[0] == ')'
				|| e.Text.ToString()[0] == '+' || e.Text.ToString()[0] == '-' || e.Text.ToString()[0] == ' '))
			{
				e.Handled = true;
			}
		}

		private void UploadPhoto_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog(); // создали новое диалоговое окно
			dlg.Filter = "Image files (*.jpg,*.png)|*.jpg; *.png"; // добавили фильтер
			if (dlg.ShowDialog() == true) // запустили окно
			{
				System.IO.FileStream streamOpenImage = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Open); // создали новый вайловый поток
				Photo.Source = BitmapFrame.Create(streamOpenImage,BitmapCreateOptions.None,BitmapCacheOption.OnLoad); // записали фото
			}

		}
	}
}
