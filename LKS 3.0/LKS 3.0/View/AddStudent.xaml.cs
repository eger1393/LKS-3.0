using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Data.Entity;

namespace LKS_3._0
{
	/// <summary>
	/// Логика взаимодействия для AddStudent.xaml
	/// </summary>
	public partial class AddStudent : Window
	{

        private AddStudentViewModel viewModel;

		private BitmapFrame ImageBitmapFrame;

        public AddStudent(Student temp,ref ApplicationContext temp_DataBase)
		{
			InitializeComponent();

            CbTroop.ItemsSource = temp_DataBase.Troops.Local.Where(c => c.SboriTroop == false && c.NumberTroop != null).ToList();

            CbGroup.ItemsSource = temp_DataBase.Students.Select(u => u.InstGroup).Distinct().ToList();

            CbRectal.ItemsSource = temp_DataBase.Students.Select(u => u.Rectal).Distinct().ToList();

            CbSpeciality.ItemsSource = temp_DataBase.Students.Select(u => u.VUS).Distinct().ToList();

            CbSpecInst.ItemsSource = temp_DataBase.Students.Select(u => u.SpecInst).Distinct().ToList();

            comboBox_foreign_language.ItemsSource = temp_DataBase.Students.Select(u => u.ForeignLanguage).Distinct().ToList();

            CbRank.ItemsSource = Troop.Ranks;

            viewModel = new AddStudentViewModel(ref temp_DataBase, ref temp);

            DataContext = viewModel;

			Binding_columns();

            
		}

		//TODO точно такаяже функция используется в WindowDatabase
		private void Binding_columns()
		{
			Type T = typeof(Relative);
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

					RelativeDataGrid.Columns.Add(temp_column);
				}

			}
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
			dlg.Filter = "Image files (*.jpg, *png)|*.jpg; *png"; // добавили фильтер
			if (dlg.ShowDialog() == true) // запустили окно
			{
				//File.Copy(dlg.FileName, "temp.jpg", true);
				FileStream streamOpenImage = new FileStream(dlg.FileName, FileMode.Open); // создали новый файловый поток
				ImageBitmapFrame = BitmapFrame.Create(streamOpenImage, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);																									 // я не нашел как из ImageSource сделать BitmapFrame поэтому просто записываю эту хрень сдесь
				Photo.Source = ImageBitmapFrame.CloneCurrentValue(); // записали фото 
				
			
			}
        }

		private void Save_Click(object sender, RoutedEventArgs e)
		{

            if (ImageBitmapFrame != null)
			{
				try
				{
					string ImagePath = @"\Image\" + viewModel.AddedStudent.Id + ".jpg"; // TODO добавить обработку исключениия
					if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + ImagePath))
					{
						File.Delete(AppDomain.CurrentDomain.BaseDirectory + ImagePath);
					}
					JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
					jpegBitmapEncoder.QualityLevel = 100;
					jpegBitmapEncoder.Frames.Add(ImageBitmapFrame);
					FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + ImagePath, FileMode.CreateNew);
					jpegBitmapEncoder.Save(fileStream);
					fileStream.Close();
					viewModel.AddedStudent.ImagePath = "Image\\" + viewModel.AddedStudent.Id + ".jpg";
				}
				catch(System.IO.IOException)//TODO
				{
					System.Windows.MessageBox.Show("Переместите или переименуйте фотографию!");
				}
			}



            var tmp = viewModel.AddedStudent.Troop.FirstOrDefault(u => u.PlatoonCommander == viewModel.AddedStudent);

            if (CbRank.Text == "КВ")
            {
                viewModel.AddedStudent.Troop.FirstOrDefault(u => u.SboriTroop == false).PlatoonCommander = viewModel.AddedStudent;
            }
            else if(tmp != null)
            {
                tmp.PlatoonCommander = null;
                tmp.Id_PC = null;
            }

            if (string.IsNullOrEmpty(viewModel.AddedStudent.MiddleName)) // почему именно фамилия??
            {
                MessageBox.Show("Заполните поле фамилии!","Ошибка!");
            }
            else
            {
                DialogResult = true;
                Close();
            }
			
		}

		private void TbYearValidate_LostFocus(object sender, RoutedEventArgs e)
		{
			if( Convert.ToInt32(((TextBox)sender).Text) >= 2100 || Convert.ToInt32(((TextBox)sender).Text) <= 1950)
			{
				((TextBox)sender).Text = "Error";
            }
		}

        private void Cnacel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            Close();
        }

        private void CbTroop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			if (viewModel != null)
			{  
                viewModel.AddedStudent.Troop.Remove(viewModel.AddedStudent.Troop.First(u => u.SboriTroop == false));
                viewModel.AddedStudent.Troop.Add((Troop)CbTroop.SelectedItem);
            }
			
        }

        private void CbTroop_Loaded(object sender, RoutedEventArgs e)
        {
                CbTroop.Text = viewModel?.AddedStudent?.Troop?.FirstOrDefault(u => u.SboriTroop == false)?.NumberTroop;
        }
    }
}
