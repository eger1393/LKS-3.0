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

namespace LKS_3._0.View
{
	/// <summary>
	/// Логика взаимодействия для InfoAdministrationMilKaf.xaml
	/// </summary>
	public partial class InfoAdministrationMilKaf : Window
    {
        Model.Admin Rect, War, Nach;
        ApplicationContext db;
        public InfoAdministrationMilKaf(ref ApplicationContext DB)
		{
			InitializeComponent();


            db = DB;

            Rect = DB.Admins.FirstOrDefault(u => u.Id == 24);
            War = DB.Admins.FirstOrDefault(u => u.Id == 2);
            Nach = DB.Admins.FirstOrDefault(u => u.Id == 1);

            if(Rect == null)
            {
                MessageBox.Show("Ошибка! В списке администрации не найден Ректор МАИ НИУ (ID=24)");
               
            }
            if (War == null)
            {
                MessageBox.Show("Ошибка! В списке администрации не найден Военный комиссар (ID=2)");
                
            }
            if (Nach == null)
            {
                MessageBox.Show("Ошибка! В списке администрации не найден Начальник факультета военного обучения (ID=1)");
                
            }
            VK_First.Text = Nach.FirstName;
            VK_Middle.Text = Nach.MiddleName;
            VK_Last.Text = Nach.LastName;
            VK_Rank.Text = Nach.Collness;

            War_First.Text = War.FirstName;
            War_Middle.Text = War.MiddleName;
            War_Last.Text = War.LastName;
            War_Rank.Text = War.Collness;

            Rect_First.Text = Rect.FirstName;
            Rect_Middle.Text = Rect.MiddleName;
            Rect_Last.Text = Rect.LastName;


        }

		private void Save_Click(object sender, RoutedEventArgs e)
		{
            Nach.FirstName = VK_First.Text;
            Nach.MiddleName = VK_Middle.Text;
            Nach.LastName = VK_Last.Text;
            Nach.Collness = VK_Rank.Text;

            War.FirstName = War_First.Text;
            War.MiddleName = War_Middle.Text;
            War.LastName = War_Last.Text;
            War.Collness = War_Rank.Text;

            Rect.FirstName = Rect_First.Text;
            Rect.MiddleName = Rect_Middle.Text;
            Rect.LastName = Rect_Last.Text;

            DialogResult = true;
            db.SaveChanges();
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
