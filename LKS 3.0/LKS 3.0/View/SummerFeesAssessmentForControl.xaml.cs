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
using System.Reflection;

namespace LKS_3._0.View
{
	/// <summary>
	/// Логика взаимодействия для SummerFeesAssessmentForControl.xaml
	/// </summary>
	public partial class SummerFeesAssessmentForControl : Window
	{
		ViewModel.SummerFeesAssessmentForControlViewModel viewModel;
		public SummerFeesAssessmentForControl(Troop temp_troop)
		{
			InitializeComponent();

			viewModel = new ViewModel.SummerFeesAssessmentForControlViewModel(temp_troop);

			DataContext = viewModel;

			if (viewModel.CloseAction == null)
				viewModel.CloseAction = new Action(() => this.Close());
			//Binding_columns();
		}

		private void Binding_columns()
		{
			string[] columns = { "Фамилия", "Имя", "Отчество", "1", "2", "3", "4", "5", "6", "7" };
			Type T = typeof(Student);
			PropertyInfo[] Property_Arr = T.GetProperties();
			foreach (PropertyInfo el in Property_Arr)
			{

				dataGridStudents.IsReadOnly = false;
				RusNameAttribute temp_attribute = (RusNameAttribute)el.GetCustomAttribute(typeof(RusNameAttribute));
				if ((temp_attribute != null) && (columns.FirstOrDefault(u => u == temp_attribute.Get_RussianTittle) != null))
				{
					DataGridTextColumn temp_column = new DataGridTextColumn();
					temp_column.Header = temp_attribute.Get_RussianTittle;
					Binding myNewBindDef = new Binding(el.Name);
					temp_column.Binding = myNewBindDef;
					dataGridStudents.Columns.Add(temp_column);
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
			Close();
		}
	}
}
