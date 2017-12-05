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

        private RelayCommand saveCommand;

        BindingList<Model.Admin> _admins;

        BindingList<Student> students;

        BindingList<Prepod> prepods;
        Model.Admin selectAdmin;

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
