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
		private Relative selectedRelative, // Выбранный родственник
			addedRelative; // Добавляемы родственник
		public List<Relative> relativs; // Коллекция родственников

		RelayCommand addRelative;


		public RelayCommand AddRelative
		{
			get
			{
				return addRelative ??
				  (addRelative = new RelayCommand(obj =>
				  {

					  relativs.Add(addedRelative);
					  selectedRelative = relativs.Last();
					  addedRelative = new Relative();
				  }));
			}
			
		}
		public List<Relative> Relativs
		{
			get { return relativs; }
			set
			{
				relativs = value;
				OnPropertyChanged();
			}
		}
		public Student AddedStudent
		{
			get
			{
				return addedStudent;
			}
			set
			{
				addedStudent = value;
				OnPropertyChanged();
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
				OnPropertyChanged();
			}
		}
		public Relative AddedRelative
		{
			get
			{
				return addedRelative;
			}
			set
			{
				addedRelative = value;
				OnPropertyChanged();
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
