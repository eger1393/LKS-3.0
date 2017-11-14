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
        BindingList<Student> listStudentsTroopCurrent;
        BindingList<Student> listStudentsTroopSbori;


        RelayCommand updateCurrentGridCommand;

        public NewSboriViewModel(ref ApplicationContext temp_DataBase)
        {
            this.temp_DataBase = temp_DataBase;

            Troops = this.temp_DataBase.Troops.Local.ToBindingList();

            Prepods = this.temp_DataBase.Prepods.Local.ToBindingList();

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
                listStudentsTroopCurrent = value;
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
            }
        }

        public RelayCommand UpdateCurrentGridCommand
        {
            get
            {
                return updateCurrentGridCommand ??
                 (updateCurrentGridCommand = new RelayCommand(obj =>
                 {
                     string selected_value = obj as string;

                     ListStudentsTroopCurrent = new BindingList<Student>(Troops.Where(u => u.NumberTroop == selected_value).First().ListStudents);

                 }));
            }

        }

        public NewSboriViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
