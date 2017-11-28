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

        public Model.Summer selectedSummerSbori;

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                    (saveCommand = new RelayCommand(obj =>
                    {
                        this.temp_DataBase.SaveChanges();
                    }));
            }
        }

        public SummerSboriViewModel(ref ApplicationContext temp_DataBase, BindingList<Troop> _troops)
        {
            this.temp_DataBase = temp_DataBase;

            this.temp_DataBase.Summers.Load();

            selectedSummerSbori = this.temp_DataBase.Summers.FirstOrDefault();

            selectedSummerSbori.listTroops = _troops;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
