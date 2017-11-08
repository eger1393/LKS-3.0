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
        public EditPrepodsViewModel()
        {
           
        }

        private Prepod selectedPrepod; // Выбранный препод
        public IEnumerable<Prepod> prepods; // Коллекция преподов

        RelayCommand editCommand;
        RelayCommand addCommand;

        public IEnumerable<Prepod> Prepods
        {
            get { return prepods; }
            set
            {

                prepods = value;
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
                      //list_Troop = DataBase.Students.Local.Select(u => u.Troop).Distinct();
                      //list_Rectal = DataBase.Students.Local.Select(u => u.Rectal).Distinct();
                      AddPrepod addPrepodWindow = new AddPrepod(temp_prepod);

                      if (addPrepodWindow.ShowDialog() == true)
                      {
                        
                      }
                  }));
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
