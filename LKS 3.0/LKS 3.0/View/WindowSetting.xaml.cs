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

namespace LKS_3._0.View
{
    /// <summary>
    /// Логика взаимодействия для WindowSetting.xaml
    /// </summary>
    public partial class WindowSetting : Window
    {
        public WindowSetting()
        {
            InitializeComponent();
            textBox_server.Text = Properties.Settings.Default.Server;
            textBox_user.Text = Properties.Settings.Default.User;
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Server = textBox_server.Text; 
            Properties.Settings.Default.User = textBox_user.Text;
            Properties.Settings.Default.Save(); 
            MessageBox.Show("Настройки сохранены! Для дальнейшей работы перезапустите программу.", "Информация"); 
        }
    }
}
