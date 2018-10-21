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
    public partial class NewSboriViewModel : INotifyPropertyChanged
    {
        private ApplicationContext temp_DataBase;

        BindingList<Prepod> prepods;
        BindingList<Troop> troops;

        Troop select_TroopCurrent;
        Troop select_TroopSbori;
        Prepod selectPrepod;

        BindingList<Student> listStudentsTroopCurrent;
        BindingList<Student> listStudentsTroopSbori;


        RelayCommand updateCurrentGridCommand, setSboriCommand, updateSboriGridCommand, returnSboriCommand, exelentCommand, updateRPCommand;

        public NewSboriViewModel(ref ApplicationContext temp_DataBase)
        {
            this.temp_DataBase = temp_DataBase;

            Load();

        }


        private void Load()
        {
            Troops = temp_DataBase.Troops.Local.ToBindingList();

            Prepods = temp_DataBase.Prepods.Local.ToBindingList();

            Select_TroopCurrent = new Troop();

            Troop troop_tmp = Troops.FirstOrDefault(u => u.SboriTroop == true);

            Select_TroopSbori = troop_tmp == null ? new Troop("1") : troop_tmp;

            SelectPrepod = Select_TroopSbori.Prepod;

            Update();

        }

        private void Update()
        {

            //foreach (Troop item in Troops)
            //{
            //    if (item.SboriTroop)
            //    {
            //        item.Students = new BindingList<Student>(this.temp_DataBase.Students.Local.Where(u => u.NumSboriTroop == item.NumberTroop).ToList());
            //    }
            //    else
            //    {
            //        item.Students = new BindingList<Student>(this.temp_DataBase.Students.Local.Where(u => u.Troop.NumberTroop == item.NumberTroop).ToList());
            //    }
            //}

            ListStudentsTroopSbori = Select_TroopSbori.Students;
            //Select_TroopSbori.StaffCount = ListStudentsTroopSbori.Count;


            ListStudentsTroopCurrent = Select_TroopCurrent.Students;
            //Select_TroopCurrent.StaffCount = ListStudentsTroopCurrent.Count;

            SelectPrepod = Select_TroopSbori.Prepod;
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

        public BindingList<Student> ListStudentsTroopCurrent
        {
            get
            {
                return listStudentsTroopCurrent;
            }

            set
            {
                listStudentsTroopCurrent = new BindingList<Student>(value.Where(u => u.Status == "Обучается").ToList());
                OnPropertyChanged();
            }
        }

        public BindingList<Student> ListStudentsTroopSbori
        {
            get
            {
                return listStudentsTroopSbori;
            }

            set
            {
                listStudentsTroopSbori = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand UpdateRPCommand
        {
            get
            {
                return updateRPCommand ??
                  (updateRPCommand = new RelayCommand((selectedItem) =>
                  {
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem == null) return;

                      Prepod temp = selectedItem as Prepod;

                      //Select_TroopSbori.PrepodId = temp.Id;
                      Select_TroopSbori.Prepod = temp;

                  }));
            }
        }

        public RelayCommand UpdateCurrentGridCommand
        {
            get
            {
                return updateCurrentGridCommand ??
                 (updateCurrentGridCommand = new RelayCommand(obj =>
                 {
                     if (obj == null) return;


                     select_TroopCurrent = obj as Troop;

                     ListStudentsTroopCurrent = Select_TroopCurrent.Students;

                 }));
            }

        }

        public RelayCommand SetSboriCommand
        {
            get
            {
                return setSboriCommand ??
                (setSboriCommand = new RelayCommand(obj =>
                {

                    

                    System.Collections.IList items = (System.Collections.IList)obj;

                    if (items.Count == 0)
                    {
                        MessageBox.Show("Выберите студента для перемещения!", "Ошибка!");
                        return;
                    }

                    var collection = items.Cast<Student>();
                    collection = collection.ToList();

                    foreach (var item in collection)
                    {
                        item.Status = "На сборах";
                        item.Troop.Add(Select_TroopSbori);
                        Select_TroopSbori.Students.Add(item);
                    }

                    //Select_TroopSbori.Students = new BindingList<Student>(Select_TroopSbori.Students.Distinct().ToList());
                    Update();

                }));
            }
        }

        public RelayCommand UpdateSboriGridCommand
        {
            get
            {
                return updateSboriGridCommand ??
                (updateSboriGridCommand = new RelayCommand(obj =>
                {
                    if(obj == null)
                    {
                        MessageBox.Show("Выберите взвод для сборов!", "Ошибка!");
                        return;
                    }

                    Select_TroopSbori = obj as Troop;

                    Update();
                    
                }));
            }

        }

        public Troop Select_TroopCurrent
        {
            get
            {
                return select_TroopCurrent;
            }

            set
            {
                select_TroopCurrent = value;
                OnPropertyChanged();
            }
        }

        public Troop Select_TroopSbori
        {
            get
            {
                return select_TroopSbori;
            }

            set
            {
                select_TroopSbori = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ReturnSboriCommand
        {
            get
            {
                return returnSboriCommand ??
                (returnSboriCommand = new RelayCommand(obj =>
                {
                    if (obj == null)
                    {
                        MessageBox.Show("Выберите студента для перемещения!", "Ошибка!");
                        return;
                    }

                    System.Collections.IList items = (System.Collections.IList)obj;
                    var collection = items.Cast<Student>();
                    collection = collection.ToList();

                    foreach (var item in collection)
                    {
                        item.Status = "Обучается";
                        item.Troop.Remove(Select_TroopSbori);
                        Select_TroopSbori.Students.Remove(item);
                    }

                    Update();
                   

                }));
            }
        }

        public RelayCommand ExelentCommand
        {
            get
            {
                return exelentCommand ??
                (exelentCommand = new RelayCommand(obj =>
                {
                    if (obj == null) return;
                    Prepod temp_prepod = obj as Prepod;
                    Select_TroopSbori.Prepod = temp_prepod;

                }));
            }
        }

        public Prepod SelectPrepod
        {
            get
            {
                return selectPrepod;
            }

            set
            {
                selectPrepod = value;
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
