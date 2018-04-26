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
		//ApplicationContext db;
		public InfoAdministrationMilKaf(ref ApplicationContext DB)
		{
			//db = DB; // получил ссылку на базу данных
   //         db.Departments.Load();

			//this.DataContext = db.Departments.Local.First();

			InitializeComponent();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			//db.Entry(this.DataContext).State = EntityState.Modified;
			//db.SaveChanges();
   //         DialogResult = true;
		}
	}
}
