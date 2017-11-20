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

namespace LKS_3._0
{
    class EditPrepodsViewModel : INotifyPropertyChanged
    {
        public ApplicationContext DataBasePr;
        public Troop Select_Troop;
        public EditPrepodsViewModel(ref ApplicationContext temp_database, ref Troop selected_troop)
        {
            DataBasePr = temp_database;   

            Prepods = DataBasePr.Prepods.Local.ToBindingList();

            Prepod._count = Prepods.Count();

            Select_Troop = selected_troop;
        }

        private Prepod selectedPrepod; // Выбранный препод
        public IEnumerable<Prepod> prepods; // Коллекция преподов

        RelayCommand editCommand;
        RelayCommand addCommand;
        RelayCommand deleteCommand;
        RelayCommand setRPCommand;

        public IEnumerable<Prepod> Prepods
        {
            get { return prepods; }
            set
            {

                prepods = value;
                OnPropertyChanged("Prepods");
            }
        }

        public Prepod SelectedPrepod
        {
            get
            {
                return selectedPrepod;
            }
            set
            {
               selectedPrepod = value;
               OnPropertyChanged();
            }
        }

        public RelayCommand SetRPCommand
        {
            get
            {
                return setRPCommand ??
                  (setRPCommand = new RelayCommand((selectedItem) =>
                  {
                      if (selectedItem == null)
                      {
                          MessageBox.Show("Взвод не выбран!", "Ошибка!");
                          return;
                      }
                      // получаем выделенный объект

                      if(Select_Troop.NumberTroop != null)
                      {

                          Prepod temp_prepod = selectedItem as Prepod;


                          if (Select_Troop.Id_RP != 0)
                                {
                                      MessageBoxResult res = MessageBox.Show("Вы уверены что хотите переназначить преподавателя?", "Внимание!", MessageBoxButton.YesNo);

                                      if (res.ToString() == "No")
                                      {
                                          return;
                                      }

                                    Select_Troop.responsiblePrepod.AdditionalInfo = "";

                              //TO DO
                              if(DataBasePr.Troops.Local.Where(u => u.Id_RP == temp_prepod.Id).Count()!=0)
                              {
                                  DataBasePr.Troops.Local.Where(u => u.Id_RP == temp_prepod.Id).First().Id_RP = 0;
                              }

                          }

                         
                         

                          Select_Troop.Id_RP = temp_prepod.Id;

                          Select_Troop.responsiblePrepod = temp_prepod;

                          temp_prepod.AdditionalInfo = "Ответственный за " + Select_Troop.NumberTroop.ToString() + " взвод";

                          DataBasePr.Entry(temp_prepod).State = EntityState.Modified;

                          DataBasePr.SaveChanges();

                          MessageBox.Show("Преподаватель назначен!", "Успешно!");

                          


                      }
                      else
                      {
                          MessageBox.Show("Взвод не выбран!", "Ошибка!");
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
                      Prepod temp_prepod = selectedItem as Prepod;

                      AddPrepod addPrepodWindow = new AddPrepod(temp_prepod);

                      if (addPrepodWindow.ShowDialog() == true)
                      { 
                          DataBasePr.Prepods.Add(temp_prepod);
                          DataBasePr.Entry(temp_prepod).State = EntityState.Modified;
                          DataBasePr.SaveChanges();
                          SelectedPrepod = temp_prepod;
                      }
                  }));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Prepod temp_prepod = new Prepod();
                      AddPrepod addPrepodWindow = new AddPrepod(temp_prepod);

                      if (addPrepodWindow.ShowDialog() == true)
                      {
                          DataBasePr.Prepods.Add(temp_prepod);
                          DataBasePr.SaveChanges();
                          SelectedPrepod = temp_prepod;
                      }
                  }));
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(selectedItem =>
                    {
                        // если ни одного объекта не выделено, выходим
                        if (selectedItem == null) return;

                        MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить преподавателя?", "Внимание!", MessageBoxButton.YesNo);
                        if (res.ToString() == "Yes")
                        {
                            Prepod prepod = selectedPrepod as Prepod;
                            DataBasePr.Prepods.Remove(prepod);

                            if (Select_Troop.Id_RP != 0)
                            {
                                Select_Troop.Id_RP = 0;
                                Select_Troop.responsiblePrepod = new Prepod();
                            }
                            

                            DataBasePr.SaveChanges();
                        }
                        else if (res.ToString() == "No")
                        {
                            deleteCommand = null;
                            return;
                      }

                    }, (obj) => Prepods.Count() > 0));
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
