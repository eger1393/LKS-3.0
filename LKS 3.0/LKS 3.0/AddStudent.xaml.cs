﻿using System;
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

		private void FirstNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (e.Text == "1")
			{
				e.Handled = true;
			}
		}
	}
}
