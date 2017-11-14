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

		BindingList<Student> students;
		BindingList<Student> selectedStudents;

		//BindingList<Troop> troops;
		//BindingList<Prepod> prepods;

		public RelayCommand moveStudent,
			returnStudent;

		public CreateReportViewModel(BindingList<Student> students)
			//BindingList<Troop> troops,
			//BindingList<Prepod> prepods )
		{
			this.students = students;
			//this.troops = troops;
			//this.prepods = prepods;
			this.SelectedStudents = new BindingList<Student>();
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

		//public BindingList<Troop> Troops
		//{
		//	get
		//	{
		//		return troops;
		//	}

		//	set
		//	{
		//		troops = value;
		//		OnPropertyChanged();
		//	}
		//}

		//public BindingList<Prepod> Prepods
		//{
		//	get
		//	{
		//		return prepods;
		//	}

		//	set
		//	{
		//		prepods = value;
		//		OnPropertyChanged();
		//	}
		//}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
