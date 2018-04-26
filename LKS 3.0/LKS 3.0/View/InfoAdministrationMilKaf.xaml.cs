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
		ApplicationContext db;
        
		public InfoAdministrationMilKaf(ref ApplicationContext DB)
		{
			InitializeComponent();
            var temp1 = DB.Admins.FirstOrDefault(u => u.Collness == "Ректор МАИ НИУ");
            var temp2 = DB.Admins.FirstOrDefault(u => u.Collness == "Военный коммисар");
            var temp3 = DB.Admins.FirstOrDefault(u => u.Collness == "Начальник факультета военного обучения");

            VK_First.Text = temp2.FirstName;
            VK_Middle.Text = temp2.MiddleName;
            VK_Last.Text = temp2.LastName;
            VK_Rank.Text = temp2.Rank;

            War_First.Text = temp3.FirstName;
            War_Middle.Text = temp3.MiddleName;
            War_Last.Text = temp3.LastName;
            

        }

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			//db.Entry(this.DataContext).State = EntityState.Modified;
			//db.SaveChanges();
   //         DialogResult = true;
		}
	}
}
