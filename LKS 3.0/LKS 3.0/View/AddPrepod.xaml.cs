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
using System.IO;

namespace LKS_3._0
{
    /// <summary>
    /// Логика взаимодействия для AddPrepod.xaml
    /// </summary>
    public partial class AddPrepod : Window
    {
        public AddPrepod(Prepod temp)
        {
            InitializeComponent();

            DataContext = temp;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните обязательные поля!");
                return;
            }

            DialogResult = true;
            Close();
        }

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			string imagePath = @"TeacherSignature\"
						+ (DataContext as Prepod).MiddleName + (DataContext as Prepod).FirstName + (DataContext as Prepod).LastName + ".jpg";
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.Filter = "Image files (*.jpg, *png)|*.jpg; *png"; // добавили фильтер
			if (dlg.ShowDialog() == true)
			{
				if (dlg.FileName != AppDomain.CurrentDomain.BaseDirectory + imagePath)
				{
					if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + imagePath))
					{
						File.Delete(AppDomain.CurrentDomain.BaseDirectory + imagePath);
					}
					File.Copy(dlg.FileName, AppDomain.CurrentDomain.BaseDirectory + imagePath);
				}
					(DataContext as Prepod).SignaturePath = imagePath;
			}

        }
	}
}
