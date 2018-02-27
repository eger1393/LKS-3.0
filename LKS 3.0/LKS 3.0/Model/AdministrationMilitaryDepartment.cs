using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0.Model
{
	public partial class AdministrationMilitaryDepartment : INotifyPropertyChanged
	{

		public AdministrationMilitaryDepartment()
		{

		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
		public int Id
		{ get; set; }

		[RusName("Инициалы")]
		public string HeadMilitaryDepartmentInitials // Начальник ВК Инициалы
		{ get; set; }

		[RusName("Звание")]
		public string HeadMilitaryDepartmentRank // Начальник ВК 
		{ get; set; }

		[RusName("Должность")]
		public string HeadMilitaryDepartmentPost // Начальник ВК должность
		{ get; set; }

		[RusName("Инициалы")]
		public string WarriorInitials // ВоенКом Инициалы
		{ get; set; }

		[RusName("Звание")]
		public string WarriorRank // ВоенКом Звание
		{ get; set; }

		[RusName("Должность")]
		public string WarrioirPost // ВоенКом Должность
		{ get; set; }
	}
}
