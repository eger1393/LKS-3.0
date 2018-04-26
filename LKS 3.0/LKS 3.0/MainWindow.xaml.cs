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
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace LKS_3._0
{
   
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        public bool connect = false;
        public MainWindow()
		{
			InitializeComponent();
            using (FileStream fstream = File.Open(@".\FinTl.txt", FileMode.OpenOrCreate,FileAccess.Read))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                Pass.Value = System.Text.Encoding.Default.GetString(array);
               }

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
                WindowDatabase Window_Data = new WindowDatabase(false, connect);
                Window_Data.Show();

                Close();
            }
            else if(RB_Admin.IsChecked == true)
            {
                if (PB_Password.Password == Pass.Value)
                {
                    MessageBox.Show("Вход с полным доступом!", "Успешно!");
                    WindowDatabase Window_Data = new WindowDatabase(true, connect);
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

        private void RB_Global_Checked(object sender, RoutedEventArgs e)
        {
            connect = true;
        }

        private void RB_Local_Checked(object sender, RoutedEventArgs e)
        {
            connect = false;
        }
    }
}
