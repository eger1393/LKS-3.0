using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;

namespace LKS_3._0
{
	class AddStudentViewModel : INotifyPropertyChanged
	{
        public ApplicationContext DataBaseR;

        public AddStudentViewModel(ref ApplicationContext temp_database)
        {
            DataBaseR = temp_database;

            DataBaseR.Relatives.Load();

            Relatives = DataBaseR.Relatives.Local.ToBindingList();
        }

     

        private Student addedStudent; // Добавляемый студент
		private Relative selectedRelative, // Выбранный родственник
			addedRelative; // Добавляемы родственник
		public IEnumerable<Relative> relatives; // Коллекция родственников

		RelayCommand addRelative;

        

		public RelayCommand AddRelative
		{
			get
			{
				return addRelative ??
				  (addRelative = new RelayCommand(obj =>
				  {

					  relatives.Add(addedRelative);
					  selectedRelative = relatives.Last();
					  addedRelative = new Relative();
				  }));
			}
			
		}
		public IEnumerable<Relative> Relatives
		{
			get { return relatives; }
			set
			{
				relatives = value;
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
