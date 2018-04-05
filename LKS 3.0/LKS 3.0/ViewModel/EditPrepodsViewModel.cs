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
        public IEnumerable<Troop> Troops;
        public EditPrepodsViewModel(ref ApplicationContext temp_database)
        {
            DataBasePr = temp_database;   

            Prepods = DataBasePr.Prepods.Local.ToBindingList();

            //Prepod._count = Prepods.Count();

            Troops = DataBasePr.Troops.Local.ToBindingList();

            //foreach (var item in Prepods)
            //{
            //    IEnumerable<Troop> TroopsTemp;

            //    TroopsTemp = Troops.Where(u => u.PrepodId == item.Id);

            //    foreach (var item2 in TroopsTemp)
            //    {
            //        if (item.AdditionalInfo == "")
            //        {
            //            item.AdditionalInfo += item2.NumberTroop.ToString() + " взвод ";
            //        }

            //    }

            //}
        }

        private Prepod selectedPrepod; // Выбранный препод
        public BindingList<Prepod> prepods; // Коллекция преподов

        RelayCommand editCommand;
        RelayCommand addCommand;
        RelayCommand deleteCommand;
        //RelayCommand setRPCommand;

        public BindingList<Prepod> Prepods
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
                          //Prepods.Add(temp_prepod);
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
                          Prepods.Add(temp_prepod);
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
                            Prepods.Remove(prepod);

                            //var Select_Troop = Troops.Where(u => u.PrepodId == prepod.Id);
                            //foreach (var item in Select_Troop)
                            //{
                            //    item.PrepodId = 0;
                            //    item.Prepod = new Prepod();
                            //}
                               
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
