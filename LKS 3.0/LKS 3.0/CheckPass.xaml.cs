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
    /// Логика взаимодействия для CheckPass.xaml
    /// </summary>
    public partial class CheckPass : Window
    {
        public CheckPass()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            if (password_old.Password == Pass.Value)
            {
                if(password_new.Password == password_new_2.Password)
                {
                    Pass.Value = password_new.Password;

                    using (System.IO.FileStream fstream = new System.IO.FileStream(@".\FinTl.txt", System.IO.FileMode.OpenOrCreate))
                    {
                        // преобразуем строку в байты
                        byte[] array = System.Text.Encoding.Default.GetBytes(Pass.Value);
                        // запись массива байтов в файл
                        fstream.Write(array, 0, array.Length);
                    }

                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!", "Ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Пароль неверен!", "Ошибка!");
            }


            MessageBox.Show("Пароль успешно изменен!", "Успешно!");

        }
    }
}
