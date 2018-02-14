using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Globalization;
using System.Windows;


namespace LKS_3._0.ViewModel
{
	public enum RadioOptions
	{
		Option1, Option2, Option3, Option4, Option5, Option6, Option7, Option8, Option9, Option10, Option11, Option12, Option13, None
	}

	public class EnumToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value.Equals(parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value.Equals(true) ? parameter : Binding.DoNothing;
		}
	}

    
    public class CreateReportUniversityViewModel:INotifyPropertyChanged
	{
        private BindingList<Student> troopStudents;

        BindingList<Student> students;

		BindingList<Troop> troops;

		private RadioOptions radioOptionsDocOnTroop = RadioOptions.None,
			radioOptionsJernal = RadioOptions.None;
		Troop selectedTroopDocOnTroop,
			selectedTroopJernal;

		private RelayCommand create,
			cancel;

		public CreateReportUniversityViewModel(BindingList<Student> students, BindingList<Troop> troops)
		{
			this.students = new BindingList<Student>();
			this.troops = new BindingList<Troop>();

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
			
           
		}

		public RelayCommand Create
		{
			get
			{
				return create ??
					(create = new RelayCommand(obj =>
					{
                    try
                    {
                        //if((int)obj == 0) // Если выбранна 1 вкладка
                        switch ((int)obj)
                            {
                                case 0: // Выбранна 1 вкладка
                                    {
                                        if (selectedTroopDocOnTroop != null)
                                        {
                                            List<Troop> tempList = new List<Troop>();
                                            tempList.Add(selectedTroopDocOnTroop);

                                            switch (radioOptionsDocOnTroop)
                                            {

                                                case RadioOptions.Option1:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Список_взвода.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option2:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Список_должностных_лиц_взводов.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option3:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Условия_обучения_в_вузе.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option4:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Тематический_контроль.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option5:
                                                    System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
                                                    break;
                                                case RadioOptions.None:
                                                    {
                                                        System.Windows.MessageBox.Show("Выберите шаблон!");
                                                    }
                                                    break;
                                                default:
                                                    System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
                                                    break;
                                            }

                                        }
                                        else
                                        {
                                            System.Windows.MessageBox.Show("Выберите взвод!");
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        if (SelectedTroopDocOnTroop != null)
                                        {
                                            List<Troop> tempList = new List<Troop>();
                                            tempList.Add(SelectedTroopDocOnTroop);

                                            switch (radioOptionsJernal)
                                            {
                                                case RadioOptions.Option1:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Журнал_обложка.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option2:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Журнал_целиком.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option3:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Условия_обучения_в_вузе.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option4:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Тематический_контроль.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option5:
                                                    System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
                                                    break;
                                                case RadioOptions.None:
                                                    {
                                                        System.Windows.MessageBox.Show("Выберите шаблон!");
                                                    }
                                                    break;
                                                default:
                                                    System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
                                                    break;
                                            }

                                        }
                                        else
                                        {
                                            System.Windows.MessageBox.Show("Выберите взвод!");
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        if (SelectedTroopDocOnTroop != null)
                                        {
                                            List<Troop> tempList = new List<Troop>();
                                            tempList.Add(SelectedTroopDocOnTroop);

                                            switch (radioOptionsJernal)
                                            {
                                                case RadioOptions.Option1:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Анкета.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option2:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Анкета_шабон.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                           

                                                case RadioOptions.Option5:
                                                    System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
                                                    break;
                                                case RadioOptions.None:
                                                    {
                                                        System.Windows.MessageBox.Show("Выберите шаблон!");
                                                    }
                                                    break;
                                                default:
                                                    System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
                                                    break;
                                            }

                                        }
                                        else
                                        {
                                            System.Windows.MessageBox.Show("Выберите взвод!");
                                        }
                                        break;
                                    }
                                case 5:
                                    {
                                        if (SelectedTroopDocOnTroop != null)
                                        {
                                            List<Troop> tempList = new List<Troop>();
                                            tempList.Add(SelectedTroopDocOnTroop);

                                            switch (radioOptionsJernal)
                                            {
                                                case RadioOptions.Option1:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Шаблон.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option2:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\Шаблон.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;
                                                case RadioOptions.Option3:
                                                    {
                                                        Model.Templates temp = new Model.Templates(
                                                            System.IO.Path.GetFullPath(@".\Templates\ЛКС.docx"),
                                                            null, null, tempList);
                                                    }
                                                    break;

                                                case RadioOptions.Option5:
                                                    System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
                                                    break;
                                                case RadioOptions.None:
                                                    {
                                                        System.Windows.MessageBox.Show("Выберите шаблон!");
                                                    }
                                                    break;
                                                default:
                                                    System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
                                                    break;
                                            }

                                        }
                                        else
                                        {
                                            System.Windows.MessageBox.Show("Выберите взвод!");
                                        }
                                        break;
                                    }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неизвестная ошибка!", "Внимание!");
                        }
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

		public RadioOptions RadioOptionsDocOnTroop
		{
			get
			{
				return radioOptionsDocOnTroop;
			}

			set
			{
				radioOptionsDocOnTroop = value;
				OnPropertyChanged();
			}
		}

		public Troop SelectedTroopDocOnTroop
		{
			get
			{
				return selectedTroopDocOnTroop;
			}

			set
			{
				selectedTroopDocOnTroop = value;
                TroopStudents = value.ListStudents;
                OnPropertyChanged();
			}
		}

		

		public RadioOptions RadioOptionsJernal
		{
			get
			{
				return radioOptionsJernal;
			}

			set
			{
				radioOptionsJernal = value;
				OnPropertyChanged();
			}
		}

		public Troop SelectedTroopJernal
		{
			get
			{
				return selectedTroopJernal;
			}

			set
			{
				selectedTroopJernal = value;
				OnPropertyChanged();
			}
		}

        public BindingList<Student> TroopStudents
        {
            get
            {
                return troopStudents;
            }

            set
            {
                troopStudents = value;
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
