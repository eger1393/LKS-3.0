using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Data.Entity;
using System.Windows;

namespace LKS_3._0.ViewModel
{
	class SummerSboriViewModel : INotifyPropertyChanged
	{
		private ApplicationContext temp_DataBase;

		public Model.Summer SelectedSummerSbori
		{
			get; set;
		}

        private RelayCommand saveCommand,
            create, cancel, assessments, editCommand;
        public Action CloseAction { get; set; }

		BindingList<Model.Admin> _admins;

		BindingList<Student> students;

		BindingList<Prepod> prepods;
		Model.Admin selectAdmin;
		BindingList<Troop> troops;

		//
		private Troop selectedTroop;
		private RadioOptions radioOption = RadioOptions.None;



		// путь к шаблонам (строки - вкладки, столбцы - конкретные шаблоны)
		// TODO переделать исспользуя не массив
		string[,] pathTemplate =
		{
			{ // 0 вкладка
				"Сборы_Альфа_список.docx",
				"none",//
				"Сборы_журнал.docx",
				"Именной_список_на_сборы.docx",
				"Сборы_инстр_по_ТБ.docx",
				"Сборы_вечерняя_проверка.docx",
				"none",//
				"Сборы_ВПД.docx",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
			},
			{ // 1 
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
			},
			{ // 2
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
			},
			{ // 3 вкладка
				"Сборы_лист_нарядов.docx",
				"Сборы_марш_15км.docx",
				"Сборы_ведомость_закрепления_оружия.docx",
				"Сборы_ведомость_осмотра_нач_медом.docx",
				"Сборы_заявка_мыло.docx",
				"Сборы_заявка_сахар.docx",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
			},
			{ // 4 вкладка
				"Сборы_Метание_гранат.docx",
				"Сборы_присяга_список.docx",
				"none",//
				"Сборы_бег_100.docx",
				"Сборы_бег_1000.docx",
				"Сборы_бег_3000.docx",
				"Сборы_ведомость_по_всем_нормативам.docx",
				"Сборы_челночный_бег.docx",
				"Сборы_отжимания.docx",
				"Сборы_подтягивания.docx",
				"Сборы_стрельба_АК.docx",
				"Сборы_стрельба_ПМ.docx",
				"Сборы_Список_проинструктированных_по_ТБ.docx",
				"Сборы_заявка_БТУ.docx",
				"Сборы_сдавшие_экзамен.docx",
			},
			{ // 5
				"Сборы_список_ТБ_на_БТУ.docx",
				"Сборы_характеристика.docx",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
			},
			{ // 6
				"ВПД.docx",
				"Именной список сдавших экзамен.docx",
				"Именной список.docx",
				"Отчет о результатах аттестации.docx",
				"Протокол1.docx",
				"Удостоверение о приписке.docx",
				"ХАРАКТЕРИСТИКА.docx",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
				"none",
			}
		};
		//

		public RelayCommand Creatte
		{
			get
			{
				return create ??
					(create = new RelayCommand(obj =>
				   {
					   if (SelectedTroop == null)
					   {
						   MessageBox.Show("Ошибка, выбирите взвод!");
						   return;
					   }
					   if (pathTemplate[(int)obj, (int)radioOption] != "none")
					   {
						   List<Troop> tempList = new List<Troop>(); // в шаблоны надо передавать список
						   tempList.Add(selectedTroop);
						   if (((int)obj == 5 && (int)radioOption == 1) || ((int)obj == 6 && (int)radioOption == 6))
						   {
							   foreach (Student ob in selectedTroop.Students)
							   {
								   List<Student> tempStudent = new List<Student>();
								   tempStudent.Add(ob);
								   Model.Templates temp = new Model.Templates(
								   System.IO.Path.GetFullPath(@".\Templates\" + pathTemplate[(int)obj, (int)radioOption]),
								   ref temp_DataBase, tempStudent, null, null);
							   }
						   }
						   else
						   {
							   Model.Templates temp = new Model.Templates(
								   System.IO.Path.GetFullPath(@".\Templates\" + pathTemplate[(int)obj, (int)radioOption]),
								   ref temp_DataBase, null, null, tempList);
						   }
					   }
					   else
					   {
						   MessageBox.Show("Ошибка, неверный шаблон шаблон!");
					   }
				   }));
			}
		}


		public RelayCommand SaveCommand
		{
			get
			{
				return saveCommand ??
					(saveCommand = new RelayCommand(obj =>
					{
						this.temp_DataBase.SaveChanges();
                        MessageBox.Show("Изменения сохранены!", "Успешно!");
					}));
			}
		}
		public SummerSboriViewModel(ref ApplicationContext temp_DataBase, BindingList<Student> _students, BindingList<Troop> _troops)
		{
			this.temp_DataBase = temp_DataBase;

			this.temp_DataBase.Summers.Load();

			this.temp_DataBase.Admins.Load();

			SelectedSummerSbori = this.temp_DataBase.Summers.FirstOrDefault();

			SelectedSummerSbori.listTroops = _troops;

			Students = _students;

			Prepods = this.temp_DataBase.Prepods.Local.ToBindingList();
		}
		public SummerSboriViewModel(ref ApplicationContext temp_DataBase, BindingList<Troop> _troops)
		{
			this.temp_DataBase = temp_DataBase;

			this.temp_DataBase.Summers.Load();

			this.temp_DataBase.Admins.Load();

			SelectedSummerSbori = this.temp_DataBase.Summers.FirstOrDefault();

			SelectedSummerSbori.listTroops = _troops;

			Admins = this.temp_DataBase.Admins.Local.ToBindingList();
		}

		public BindingList<Model.Admin> Admins
		{
			get
			{
				return _admins;
			}

			set
			{
				_admins = value;
				OnPropertyChanged();
			}
		}


		public Model.Admin SelectedAdmin
		{
			get
			{
				return selectAdmin;
			}

			set
			{
				selectAdmin = value;
				OnPropertyChanged();
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

		public RadioOptions RadioOption
		{
			get
			{
				return radioOption;
			}

			set
			{
				radioOption = value;
				OnPropertyChanged();
			}
		}

		public Troop SelectedTroop
		{
			get
			{
				return selectedTroop;
			}

			set
			{
				selectedTroop = value;
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

		public RelayCommand Cancel
		{
			get
			{
				return cancel ?? (cancel = new RelayCommand(obj =>
				{
					CloseAction();
				}));
			}
		}

		public RelayCommand Assessments
		{
			get
			{
				return assessments ?? (assessments = new RelayCommand(obj =>
				 {
					 if (SelectedTroop == null)
					 {
						 MessageBox.Show("Ошибка! Выберите взвод!", "Внимание!");
					 }
					 else
					 {
						 try
						 {
							 View.SummerFeesAssessmentForControl window =
						 new View.SummerFeesAssessmentForControl(SelectedTroop);

							 if (window.ShowDialog() == true)
							 {
								 temp_DataBase.SaveChanges();
							 }
						 }
						 catch (Exception ex)
						 {
							 System.Windows.MessageBox.Show(ex.Message);
						 }

					 }

				 }));
			}
		}

        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null) return;
                      // получаем выделенный объект
                      Model.Admin temp_admin = selectedItem as Model.Admin;

                      View.AddAdmin addWindow = new View.AddAdmin(temp_admin);

                      if (addWindow.ShowDialog() == true)
                      {
                          //Prepods.Add(temp_prepod);
                          temp_DataBase.Entry(temp_admin).State = EntityState.Modified;
                          temp_DataBase.SaveChanges();
                          SelectedAdmin = temp_admin;
                      }
                  }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}


	}
}
