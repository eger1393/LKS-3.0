using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Data.Entity;
using System.Windows;

namespace LKS_3._0.ViewModel
{

	public class SummerFeesAssessmentForControlViewModel : INotifyPropertyChanged
	{
		Troop troop;// переданный взвод
        BindingList<Student> students;

		public SummerFeesAssessmentForControlViewModel(Troop troop)
		{
			this.troop = troop;
            Students = troop.Students;
		}
		RelayCommand close;
		public Action CloseAction { get; set; }
		public RelayCommand Close
		{
			get
			{
				return close ?? (close = new RelayCommand(obj =>
				  {
					  CloseAction();
				  }));
			}
		}
		
		public BindingList<Student> Students { get { return students; } set { students = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
