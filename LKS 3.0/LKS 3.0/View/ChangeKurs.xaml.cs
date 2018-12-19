using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Data.Entity;
using System.Windows;
namespace LKS_3._0.View
{
    /// <summary>
    /// Логика взаимодействия для ChangeKurs.xaml
    /// </summary>
    public partial class ChangeKurs : Window
    {
        BindingList<Student> students;
        public ChangeKurs(BindingList<Student> _students)
        {
            InitializeComponent();

            students = _students;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
			if(radioButtonNext.IsChecked != true && radioButtonPrev.IsChecked != true)
			{
				MessageBox.Show("Выберите операцию!", "Ошибка!");
				return;
			}

			foreach (var item in students)
			{
				var group = item.InstGroup.Split('-');
				var sb = new StringBuilder(group[1]);
				if (Int32.TryParse(sb[0].ToString(), out int kurs))
				{
					if (radioButtonNext.IsChecked == true)
					{
						//kurs = kurs < 4 ? kurs++ : kurs;
						kurs++;
					}
					else
					{
						kurs--;
						//kurs = kurs > 1 ? kurs-- : kurs;
					}
					item.Kurs = kurs;
					sb[0] = ((char)('0' + kurs));
					group[1] = sb.ToString();
					item.InstGroup = string.Join("-", group);
				}
			}
			Close();

			//       if(radioButtonNext.IsChecked == true)
			//       {
			//           foreach (var item in students)
			//           {
			//if (item.Kurs < 4)
			//{
			//	item.Kurs++;
			//}
			//           }
			//           Close();
			//       }
			//       else if (radioButtonPrev.IsChecked == true)
			//       {
			//           foreach (var item in students)
			//           {
			//               if (item.Kurs >1)
			//                   item.Kurs--;
			//           }
			//           Close();
			//       }
			//       else
			//       {
			//           MessageBox.Show("Выберите операцию!", "Ошибка!");
			//       }
		}
    }
}
