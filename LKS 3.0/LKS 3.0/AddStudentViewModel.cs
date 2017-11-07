using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace LKS_3._0
{
	class AddStudentViewModel:INotifyPropertyChanged
	{
		private Student addedStudent; // Добавляемый студент
		private Relative selectedRelative; // Выбранный родственник
		public IEnumerable<Relative> relativs; // Коллекция родственников

		public Student AddedStudent
		{
			get
			{
				return addedStudent;
			}
			set
			{
				addedStudent = value;
			}
		}

		public Relative SelectedRelative
		{
			get
			{
				return selectedRelative;
			}
			set
			{
				selectedRelative = value;
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

	}
}
