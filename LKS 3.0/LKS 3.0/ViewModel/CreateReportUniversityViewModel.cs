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
	// TODO ВЫнести в отдельный класс
	public enum RadioOptions
	// TODO есть красивая идея с массивом имен файлов (реализовать ее и переделать нумерацию с нуля (Option1 = 0))
	{
		Option1 = 0, Option2, Option3, Option4, Option5, Option6, Option7, Option8, Option9, Option10,
		Option11, Option12, Option13, Option14, Option15, None
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
	//TODO Доделать эту хрень(сейчас проблемы с конвертером он не хочет получать обьект)
	public class CheckBoxToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Dictionary<string, bool> dict = value as Dictionary<string, bool>;
			int Num = System.Convert.ToInt32(parameter);
			return dict.ElementAt(Num).Value;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			//throw new NotImplementedException();
			return null;
		}
	}
	// вкладка ВУЗ
	public class CreateReportUniversityViewModel : INotifyPropertyChanged
	{
		private BindingList<Student> troopStudents;

		private BindingList<Student> students;

		private BindingList<Troop> troops;

		private Student selectedStudent;

		private Dictionary<string, bool> printOnDemand; // Массив значений чекбоксов(для вкладки печать по требованию)

		private RadioOptions radioOptionsDocOnTroop = RadioOptions.None,
			radioOptionsJernal = RadioOptions.None,
			radioOptionsLKS = RadioOptions.None;
		Troop selectedTroopDocOnTroop,
			selectedTroopJernal;
		private int count; // кол-во документов для печати

		//TODO
		ApplicationContext temp_DataBase;

		private RelayCommand create, close;
		//TODO
		public CreateReportUniversityViewModel(ref ApplicationContext temp_DataBase, BindingList<Student> students, BindingList<Troop> troops)
		{
			count = 0;
			//TODO
			this.temp_DataBase = temp_DataBase;
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
			// TODO Может стоит перенести это в статический конструктор?
			printOnDemand = new Dictionary<string, bool>(); // инициализировалли массив команд
			printOnDemand.Add("инициалы", false);
			printOnDemand.Add("День рождения", false);
			printOnDemand.Add("Адрес регистрации", false);
			printOnDemand.Add("Домашний номер", false);
			printOnDemand.Add("Мобильный номер", false);
			printOnDemand.Add("Военкома", false);
			printOnDemand.Add("Год поступления в МАИ", false);
			printOnDemand.Add("Год окончания МАИ", false);
			printOnDemand.Add("Группа", false);
			printOnDemand.Add("Факультет", false);
			printOnDemand.Add("Специальность в институте", false);
			printOnDemand.Add("Условия обучения", false);
			printOnDemand.Add("Средний балл", false);



		}

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
		public Action CloseAction { get; set; }
		//TODO Сделать все через массив(как в сборах)
		public RelayCommand Create
		{
			get
			{
				return create ??
					(create = new RelayCommand(obj =>
					{
						try
						{
							switch ((int)obj)
							{
								case 0: // Выбранна 1 вкладка (Документы на взвод)
									{
										if (selectedTroopDocOnTroop != null) // проверка на выделение взвода
										{
											List<Troop> tempList = new List<Troop>();
											tempList.Add(selectedTroopDocOnTroop);

											switch (radioOptionsDocOnTroop)
											{

												case RadioOptions.Option1:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Список_взвода.docx"),
															ref temp_DataBase, null, null, tempList);
													}
													break;
												case RadioOptions.Option2:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Список_должностных_лиц_взводов.docx"),
															ref temp_DataBase, null, null, tempList);
													}
													break;
												case RadioOptions.Option3:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Условия_обучения_в_вузе.docx"),
															ref temp_DataBase, null, null, tempList);
													}
													break;
												case RadioOptions.Option4:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Тематический_контроль.docx"),
															ref temp_DataBase, null, null, tempList);
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
								case 1: // Журналы
									{
										if (SelectedTroop != null)
										{
											List<Troop> tempList = new List<Troop>();
											tempList.Add(SelectedTroop);

											switch (radioOptionsJernal)
											{
												case RadioOptions.Option1:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Журнал_обложка.docx"),
															ref temp_DataBase, null, null, tempList);
													}
													break;
												case RadioOptions.Option2:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Журнал_целиком.docx"),
															ref temp_DataBase, null, null, tempList);
													}
													break;
												case RadioOptions.Option3: // TODO узать где эти шаблоны
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Наряды_взыскания_инструктажи.docx"),
															ref temp_DataBase, null, null, tempList);
													}
													break;
												case RadioOptions.Option4:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Посещаемость.docx"),
															ref temp_DataBase, null, null, tempList);
													}
													break;
												case RadioOptions.Option5:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Список_взвода_для_журнала.docx"),
															ref temp_DataBase, null, null, tempList);
													}
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
								// ПЕЧАТЬ по требованию(узнать что это??)
								case 3: //  АНКЕТЫ
									{
										switch (radioOptionsJernal)
										{
											case RadioOptions.Option1:
												{
													Model.Templates.PrintDocument(
														System.IO.Path.GetFullPath(@".\Templates\Анкета.docx"), count);
													break;
												}
											case RadioOptions.Option2:
												{
													Model.Templates.PrintDocument(
														System.IO.Path.GetFullPath(@".\Templates\Анкета_шабон.docx"), count);
													break;
												}
											case RadioOptions.None:
												{
													System.Windows.MessageBox.Show("Выберите шаблон!");
													break;
												}
											default:
												{
													System.Windows.MessageBox.Show("Ошибка! Шаблон отсутствует!");
													break;
												}
										}
										break;
									}
								case 4: // ЛКС
									{
										if (SelectedTroop != null)
										{
											List<Student> tempList = new List<Student>();
											tempList.Add(SelectedStudent);

											switch (RadioOptionsLKS)
											{
												case RadioOptions.Option1:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\ЛКС_Форма_допуска.docx"),
															ref temp_DataBase, tempList, null, null);
													}
													break;
												case RadioOptions.Option2:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Лист_изучения_кандидата_на_призыв.docx"),
															ref temp_DataBase, tempList, null, null);
													}
													break;
												case RadioOptions.Option3:
													{
														Model.Templates temp = new Model.Templates(
															System.IO.Path.GetFullPath(@".\Templates\Личная_карточка_студента.docx"),
															ref temp_DataBase, tempList, null, null);
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
						catch (Exception ex)
						{
							MessageBox.Show("Неизвестная ошибка!\n" + ex.Message, "Внимание!");
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

		public Troop SelectedTroop
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

		public Student SelectedStudent
		{
			get
			{
				return selectedStudent;
			}

			set
			{
				selectedStudent = value;
				OnPropertyChanged();
			}
		}

		public RadioOptions RadioOptionsLKS
		{
			get
			{
				return radioOptionsLKS;
			}

			set
			{
				radioOptionsLKS = value;
				OnPropertyChanged();
			}
		}

		public int Count
		{
			get
			{
				return count;
			}

			set
			{
				count = value;
				OnPropertyChanged();
			}
		}

		public Dictionary<string, bool> PrintOnDemand
		{
			get
			{
				return printOnDemand;
			}

			set
			{
				printOnDemand = value;
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
