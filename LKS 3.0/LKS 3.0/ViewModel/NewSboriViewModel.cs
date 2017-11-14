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

       RelayCommand updateCurrentGridCommand, updateSboriGridCommand, setSboriCommand;

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

        public RelayCommand UpdateCurrentGridCommand
        {
            get
            {
                return updateCurrentGridCommand ??
                 (updateCurrentGridCommand = new RelayCommand(obj =>
                 {
                     if (obj == null) return;

                     string selected_value = obj as string;

                     Select_TroopCurrent = Troops.Where(u => u.NumberTroop == selected_value).First();

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
                    if (obj == null) return;

                    Student temp = obj as Student;
                    Select_TroopSbori.ListStudents.Add(temp);
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
                    if (obj == null) return;

                    string selected_value = obj as string;

                    Select_TroopSbori = Troops.Where(u => u.NumberTroop == selected_value).First();

                }));
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

        public BindingList<Student> ListStudentTroopSbori
        {
            get
            {
                return Select_TroopSbori.ListStudents;
            }

            set
            {
                Select_TroopSbori.ListStudents = value;
                OnPropertyChanged();
            }
        }

        public BindingList<Student> ListStudentTroopCurrent
        {
            get
            {
                return Select_TroopCurrent.ListStudents;
            }

            set
            {
                Select_TroopCurrent.ListStudents = value;
                OnPropertyChanged();
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
