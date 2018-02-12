using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.Windows;

namespace LKS_3._0
{
	class AddStudentViewModel : INotifyPropertyChanged
	{
        public ApplicationContext DataBaseR;

        public AddStudentViewModel(ref ApplicationContext temp_database)
        {
            DataBaseR = temp_database;

            DataBaseR.Relatives.Load();

            Relative._count = DataBaseR.Relatives.Count();

            Relatives = DataBaseR.Relatives.Local.Where(u => u.IdStudent == AddedStudent.Id);

            AddedRelative = new Relative();
        }

        RelayCommand addRelativeCommand, editRelativeCommand, deleteRelativeCommand, saveChangeCommand;
        private IEnumerable<Relative> relatives;
        private Student addedStudent;
        private Relative selectedRelative;
        private Relative addedRelative;

        public RelayCommand AddRelative
		{
			get
			{
				return addRelativeCommand ??
				  (addRelativeCommand = new RelayCommand((add_relative) =>
				  {
                      if (add_relative == null) return;
                      // получаем выделенный объект
                      Relative temp_relative = add_relative as Relative;

                      Relative._count++;

                      temp_relative.IdStudent = AddedStudent.Id;

                      temp_relative.Id = Relative._count;

                      DataBaseR.Relatives.Add(temp_relative);

                      DataBaseR.SaveChanges();

                      SelectedRelative = Relatives.Last();

					  AddedRelative = new Relative();

                      Relatives = DataBaseR.Relatives.Local.Where(u => u.IdStudent == AddedStudent.Id);
                  }));
			}
			
		}

        public RelayCommand EditRelative
        {
            get
            {
                return editRelativeCommand ??
                  (editRelativeCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Relative temp_relative = selectedItem as Relative;
                      AddedRelative = temp_relative;

                      DataBaseR.Relatives.Remove(temp_relative);
                      DataBaseR.SaveChanges();
                      Relatives = DataBaseR.Relatives.Local.Where(u => u.IdStudent == AddedStudent.Id);
                  }));
            }
        }

        public RelayCommand DeleteRelative
        {
            get
            {
                return deleteRelativeCommand ??
                    (deleteRelativeCommand = new RelayCommand(selectedItem =>
                    {
                        // если ни одного объекта не выделено, выходим
                        if (selectedItem == null) return;

                        MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить родственника?", "Внимание!", MessageBoxButton.YesNo);
                        if (res.ToString() == "Yes")
                        {
                            Relative temp_relative = selectedItem as Relative;
                            DataBaseR.Relatives.Remove(temp_relative);
                            DataBaseR.SaveChanges();
                            Relative._count--;
                            Relatives = DataBaseR.Relatives.Local.Where(u => u.IdStudent == AddedStudent.Id);
                        }
                        else if (res.ToString() == "No")
                        {
                            deleteRelativeCommand = null;
                            return;
                        }

                    }, (obj) => Relatives.Count() > 0));
            }

        }

        public RelayCommand SaveChange
        {
            get
            {
                return saveChangeCommand ??
                    (saveChangeCommand = new RelayCommand(selectedItem =>
                    {
                        if (AddedStudent.Id == 0)
                        {
                            Student._count++;
                            AddedStudent.Id = Student._count;
                        }

                        AddedStudent.ListRelatives = new BindingList<Relative>(Relatives.Where(u => u.IdStudent == AddedStudent.Id).ToList());

                        AddedStudent.Collness = "Студент";
                    }));
            }

        }

        public IEnumerable<Relative> Relatives
        {
            get
            {
                return relatives;
            }
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
