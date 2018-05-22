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

        public AddStudentViewModel(ref ApplicationContext temp_database, ref Student temp)
        {
            DataBaseR = temp_database;
            AddedStudent = temp;
            Relatives = AddedStudent.Relatives;
            AddedRelative = new Relative();

            //Relatives = new BindingList<Relative>(DataBaseR.Relatives.Local.Where(u => u.StudentId == AddedStudent.Id).ToList());
            //Relatives = AddedStudent.Relatives;
            //Relative._count = DataBaseR.Relatives.Count();

        }

        RelayCommand addRelativeCommand, editRelativeCommand, deleteRelativeCommand, saveChangeCommand;
        private BindingList<Relative> relatives;
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
                      
                      Relative temp_relative = add_relative as Relative;
                      if (temp_relative.FirstName == null || temp_relative.MiddleName == null || temp_relative.RelationDegree == null || temp_relative.HealthStatus == null)
                      {
                          MessageBox.Show("Заполните обязательные поля!");
                          return;
                      }

                  
                      if(DataBaseR.Entry(temp_relative).State == EntityState.Modified)
                      {
                          DataBaseR.SaveChanges();
                      }
                      else
                      {
                          //temp_relative.StudentId = AddedStudent.Id;
                          DataBaseR.Relatives.Add(temp_relative);
                          Relatives.Add(temp_relative);
                          DataBaseR.SaveChanges();
                          //Relatives = new BindingList<Relative>(DataBaseR.Relatives.Local.Where(u => u.StudentId == AddedStudent.Id).ToList());
                          Relatives = AddedStudent.Relatives;
                      }


                      AddedRelative = new Relative();
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
                      
                      Relative temp_relative = selectedItem as Relative;

                      if (temp_relative.FirstName == null || temp_relative.MiddleName == null || temp_relative.RelationDegree == null || temp_relative.HealthStatus == null)
                      {
                          MessageBox.Show("Заполните обязательные поля!");
                          return;
                      }

                      AddedRelative = temp_relative;

                      DataBaseR.Entry(AddedRelative).State = EntityState.Modified;
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
                            Relatives.Remove(temp_relative);
                            DataBaseR.SaveChanges();
                            //Relative._count--;
                            //Relatives = DataBaseR.Relatives.Local.Where(u => u.StudentId == AddedStudent.Id);
                            //Relatives = new BindingList<Relative>(DataBaseR.Relatives.Local.Where(u => u.StudentId == AddedStudent.Id).ToList());
                            Relatives = AddedStudent.Relatives;
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
                        AddedStudent.Collness = "Студент";

                        DataBaseR.SaveChanges();
                    }));
            }

        }

        public BindingList<Relative> Relatives
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
