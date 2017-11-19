﻿using System;
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

        ApplicationContext _tempDB;
        public AddStudent(Student temp, IEnumerable<string> list_Troop, IEnumerable<string> list_Rectal, IEnumerable<string> list_Group, ref ApplicationContext temp_DataBase)
		{
			InitializeComponent();

            CbTroop.ItemsSource = list_Troop;
            
            CbGroup.ItemsSource = list_Group;

            CbRectal.ItemsSource = list_Rectal;

            _tempDB = temp_DataBase;

            viewModel = new AddStudentViewModel(ref _tempDB);

			viewModel.AddedStudent = temp;

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
				FileStream streamOpenImage = new FileStream(dlg.FileName, FileMode.Open); // создали новый файловый поток
				ImageBitmapFrame = BitmapFrame.Create(streamOpenImage, BitmapCreateOptions.None, BitmapCacheOption.OnLoad); // TODO немного костыля																														 // я не нашел как из ImageSource сделать BitmapFrame поэтому просто записываю эту хрень сдесь
				Photo.Source = ImageBitmapFrame;//BitmapFrame.Create(streamOpenImage,BitmapCreateOptions.None,BitmapCacheOption.OnLoad); // записали фото 
				
			
			}
        }

		private void Save_Click(object sender, RoutedEventArgs e)
		{
            if(viewModel.AddedStudent.Id == 0)
            {
                Student._count++;
                viewModel.AddedStudent.Id = Student._count;
            }

            viewModel.AddedStudent.ListRelatives = new BindingList<Relative>(_tempDB.Relatives.Local.Where(u => u.IdStudent == viewModel.AddedStudent.Id).ToList());

            //viewModel.AddedStudent.Skill_1 = (bool)checkBox_1.IsChecked;
            //viewModel.AddedStudent.Skill_2 = (bool)checkBox_2.IsChecked;
            //viewModel.AddedStudent.Skill_3 = (bool)checkBox_3.IsChecked;
            //viewModel.AddedStudent.Skill_4 = (bool)checkBox_4.IsChecked;
            //viewModel.AddedStudent.Skill_5 = (bool)checkBox_5.IsChecked;
            //viewModel.AddedStudent.Skill_6 = (bool)checkBox_6.IsChecked;

            if (ImageBitmapFrame != null)
			{
				JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
				jpegBitmapEncoder.QualityLevel = 100;
				//BitmapImage tt = Photo.Source as BitmapImage;
				jpegBitmapEncoder.Frames.Add(ImageBitmapFrame);
				string ImagePath = AppDomain.CurrentDomain.BaseDirectory + @".\Image\" + viewModel.AddedStudent.Id + ".jpg";
				if (File.Exists(ImagePath))
					File.Delete(ImagePath);
				FileStream fileStream = new FileStream(ImagePath, FileMode.CreateNew);
				jpegBitmapEncoder.Save(fileStream);
				fileStream.Close();
				viewModel.AddedStudent.ImagePath = AppDomain.CurrentDomain.BaseDirectory + "Image\\" + viewModel.AddedStudent.Id + ".jpg";
			}

			DialogResult = true;

            Close();
		}

        //private Image ResizePicture(Image img)
        //{
        //    int iDestWidth = 198;
        //    int iDestHeight = 255;

        //    Bitmap bmp = new Bitmap(iDestWidth, iDestHeight);
        //    Graphics gr = Graphics.FromImage((Image)bmp);

        //    gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //    gr.DrawImage(img, 0, 0, iDestWidth, iDestHeight);
        //    gr.Dispose();
        //    return (Image)bmp;
        //}

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
    }
}
