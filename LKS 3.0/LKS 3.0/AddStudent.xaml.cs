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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace LKS_3._0
{
	/// <summary>
	/// Логика взаимодействия для AddStudent.xaml
	/// </summary>
	public partial class AddStudent : Window
	{
        
		private Student addedStudent;

		private BitmapFrame ImageBitmapFrame;

		public AddStudent(Student temp)
		{
			InitializeComponent();
			addedStudent = temp;
			DataContext = addedStudent;
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
				ImageBitmapFrame = BitmapFrame.Create(streamOpenImage, BitmapCreateOptions.None, BitmapCacheOption.OnLoad); // TODO немного костыля
				// я не нашел как из ImageSource сделать BitmapFrame поэтому просто записываю эту хрень сдесь
				Photo.Source = ImageBitmapFrame;//BitmapFrame.Create(streamOpenImage,BitmapCreateOptions.None,BitmapCacheOption.OnLoad); // записали фото 
				
			}
			
        }

		private void Save_Click(object sender, RoutedEventArgs e)
		{
            //addedStudent.PathPhoto.Source = Photo.Source;
			//addedStudent.FirstName = TbFName.Text;
			//addedStudent.MiddleName = TbMName.Text;
			//addedStudent.LastName = TbLName.Text;
			//addedStudent.Troop = CbTroop.Text;
			//addedStudent.YearOfAddMAI = Convert.ToInt32(TbYearOfRecepit.Text);
			//addedStudent.YearOfEndMAI = Convert.ToInt32(TbYearOfEnd.Text);
			//addedStudent.YearOfAddVK = Convert.ToInt32(TbYearOfRecepitMD);
			//addedStudent.YearOfEndVK = Convert.ToInt32(TbYearOfEndMD);

			//addedStudent.YearOfAddMAI = TbYearOfRecepit.Text;
			//addedStudent.YearOfEndMAI = TbYearOfEnd.Text;
			//addedStudent.YearOfAddVK = TbYearOfRecepitMD.Text;
			//addedStudent.YearOfEndVK = TbYearOfEndMD.Text;

			//addedStudent.Group = CbGroup.Text;
   //         addedStudent.Faculty = CbFacility.Text;
   //         addedStudent.SpecialityName = CbSpeciality.Text;
   //         addedStudent.ConditionsOfEducation = CbConditions.Text;
   //         addedStudent.AvarageScore = TbAverageScore.Text;
   //         addedStudent.NumberOfOrder = TbNumberOrderAdmision.Text;
           // addedStudent.DateOfOrder = TbDataOrderAdmision.Text;
            addedStudent.Rectal = "Военкомат";

            //addedStudent.Birthday = TbDateOfBirth.Text;
			//addedStudent.PlaceBirthday = TbPlaceOfBirth.Text;
			//addedStudent.Nationality = TbNationality.Text;
			//addedStudent.Citizenship = TbCitizenship.Text;
			//addedStudent.HomePhone = TbHomePhone.Text;
			//addedStudent.MobilePhone = TbMobilePhone.Text;
			//addedStudent.PlaceOfResidence = TbPlaceOfResidence.Text;
			//addedStudent.PlaceOfRegestration = TbPlaceOfRegestration.Text;
			//addedStudent.School = TbSchool.Text;
            addedStudent.Rank = "Никто";

			if (ImageBitmapFrame != null)
			{
				JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
				jpegBitmapEncoder.QualityLevel = 100;
				//BitmapImage tt = Photo.Source as BitmapImage;
				jpegBitmapEncoder.Frames.Add(ImageBitmapFrame);
				string fileName = @".\Image\" + addedStudent.Id + ".jpg";
				if (File.Exists(fileName))
					File.Delete(fileName);
				FileStream fileStream = new FileStream(fileName, FileMode.CreateNew);
				jpegBitmapEncoder.Save(fileStream);
				fileStream.Close();
			}

			DialogResult = true;

            Close();
		}

		private void TbYearValidate_LostFocus(object sender, RoutedEventArgs e)
		{
			if( Convert.ToInt32(((TextBox)sender).Text) >= 2100 || Convert.ToInt32(((TextBox)sender).Text) <= 1950)
			{
				((TextBox)sender).Text = "Erros";
            }
		}

	}
}
