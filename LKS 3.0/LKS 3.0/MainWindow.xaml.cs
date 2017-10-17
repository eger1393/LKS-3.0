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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LKS_3._0
{
   
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        const string pass = "111";
        public MainWindow()
		{
			InitializeComponent();
			AddStudent test = new AddStudent();
			test.Visibility = Visibility.Visible;
			test.Activate();
			Close();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{

		}

        private void RB_Admin_Checked(object sender, RoutedEventArgs e)
        {
            L_Pass.Visibility = Visibility.Visible;
            PB_Password.Visibility = Visibility.Visible;
        }

        private void RB_User_Checked(object sender, RoutedEventArgs e)
        {
            L_Pass.Visibility = Visibility.Hidden;
            PB_Password.Visibility = Visibility.Hidden;
            PB_Password.Password = "";
        }

        private void B_Input_Click(object sender, RoutedEventArgs e)
        {
            if(RB_User.IsChecked == true)
            {
                MessageBox.Show("Вход как студент!");
                WindowDatabase Window_Data = new WindowDatabase(false);
                Window_Data.Show();

                Close();
            }
            else if(RB_Admin.IsChecked == true)
            {
                if (PB_Password.Password == pass)
                {
                    MessageBox.Show("Успешно!");
                    WindowDatabase Window_Data = new WindowDatabase(true);
                    Window_Data.Show();

                    Close();
                }
                else 
                {
                    MessageBox.Show("В доступе отказано!");
                    PB_Password.Password = "";
                }
            }
            else
            {
                MessageBox.Show("Выберите вариант входа");
            }
        }
    }
}
