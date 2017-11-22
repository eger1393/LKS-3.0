using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Runtime.CompilerServices;




namespace LKS_3._0.ViewModel
{
	public class CreateReportViewModel: INotifyPropertyChanged
	{
		string fileName;
		BindingList<Student> students;
		BindingList<Student> selectedStudents;

		BindingList<Troop> troops;
		BindingList<Troop> selectedTroops;
		BindingList<Prepod> prepods;

		public RelayCommand moveStudent,
			returnStudent,
			moveTroop,
			returnTroop,
			startTheTemplate,
			selectTemplate;

		public CreateReportViewModel(BindingList<Student> students,
			BindingList<Troop> troops,
			BindingList<Prepod> prepods )
		{
			this.students = new BindingList<Student>();
			this.troops = new BindingList<Troop>();
			this.prepods = new BindingList<Prepod>();

			if (students != null) //костыль
			{
				foreach (var item in students)
				{
					this.students.Add(item);
				}
			}
			if (troops != null)
			{
				foreach (var item in troops)
				{
					this.troops.Add(item);
				}
			}

			if (prepods != null)
			{
				foreach (var item in prepods)
				{
					this.prepods.Add(item);
				}
			}
			this.SelectedStudents = new BindingList<Student>();
		}

		public RelayCommand SelectTemplate
		{
			get
			{
				return selectTemplate ??
					(selectTemplate = new RelayCommand(obj =>
					{

					}));
			}
		}

		public RelayCommand StartTheTemplate
		{
			get
			{
				return startTheTemplate ??
					(startTheTemplate = new RelayCommand(obj =>
					{
					if (selectedStudents.Count != 0 && FileName != "")
						{
							
							Templates temp = new Templates(FileName, selectedStudents.ToList());
						}
						else
						{
							System.Windows.MessageBox.Show("Выберите студентов");
						}
					}));
			}
		}

		public RelayCommand MoveStudent
		{
			get
			{
				return moveStudent ??
					(moveStudent = new RelayCommand(obj =>
					{
						Student temp = obj as Student;
						SelectedStudents.Add(temp);
						Students.Remove(temp);
					}));
			}
		}

		public RelayCommand ReturnStudent
		{
			get
			{
				return returnStudent ??
					(returnStudent = new RelayCommand(obj =>
					{
						Student temp = obj as Student;
						Students.Add(temp);
						SelectedStudents.Remove(temp);
					}));
			}
		}

		public RelayCommand MoveTroop
		{
			get
			{
				return moveTroop ??
					(moveTroop = new RelayCommand(obj =>
					{
						Troop temp = obj as Troop;
						SelectedTroops.Add(temp);
						Troops.Remove(temp);
					}));
			}
		}

		public RelayCommand ReturnTroop
		{
			get
			{
				return returnTroop ??
					(returnTroop = new RelayCommand(obj =>
					{
						Troop temp = obj as Troop;
						Troops.Add(temp);
						SelectedTroops.Remove(temp);
					}));
			}
		}

		public BindingList<Student> Students
		{
			get
			{
				return students;
			}

			set
			{
				students = value;
				OnPropertyChanged();
			}
		}

		public BindingList<Student> SelectedStudents
		{
			get
			{
				return selectedStudents;
			}

			set
			{
				selectedStudents = value;
				OnPropertyChanged();
			}
		}

		public BindingList<Troop> Troops
		{
			get
			{
				return troops;
			}

			set
			{
				troops = value;
				OnPropertyChanged();
			}
		}

		public BindingList<Prepod> Prepods
		{
			get
			{
				return prepods;
			}

			set
			{
				prepods = value;
				OnPropertyChanged();
			}
		}

		public string FileName
		{
			get
			{
				return fileName;
			}

			set
			{
				fileName = value;
				OnPropertyChanged();
			}
		}

		public BindingList<Troop> SelectedTroops
		{
			get
			{
				return selectedTroops;
			}

			set
			{
				selectedTroops = value;
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
