using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace LKS_3._0
{


    public partial class Troop : INotifyPropertyChanged
    {
        private string numberTroop, day, vus;

        private BindingList<Student> students;

        public Student PlatoonCommander
        {
            get
            {
                return this.Students.FirstOrDefault(u => u.Rank == Troop.Ranks[1]);
            }
        }
        public Prepod Prepod { get; set; }

        private bool sboriTroop;

        public static List<string> Ranks = new List<string>() { " ","КВ", "ЗКВ",
        "КО1",
        "КО2",
        "КО3",
        "СтС",
        "С",
        "Ж",
        };
        public Troop()
        {
            Students = new BindingList<Student>();
        }
        public Troop(string temp_TroopNumber)
        {
            NumberTroop = temp_TroopNumber;
            Students = new BindingList<Student>();
        }
        public int Id { get; set; }


        [RusName("Номер взвода")]
        public string NumberTroop
        {
            get
            {
                return numberTroop;
            }
            set
            {
                numberTroop = value;
                OnPropertyChanged();
            }
        }

        [RusName("Личный состав (чел.)")]
        public int StaffCount
        {
            get
            {
                return Students.Count(u => (u.Status == "Обучается" && u.Status == "На сборах"));
            }

        }

        [RusName("ВУС")]
        public string Vus
        {
            get
            {
                return vus;
            }

            set
            {
                vus = value;
                OnPropertyChanged();
            }
        }

        [RusName("Взвод для сборов?")]
        public bool SboriTroop
        {
            get
            {
                return sboriTroop;
            }

            set
            {
                sboriTroop = value;
                OnPropertyChanged();
            }
        }

        [RusName("День")]
        public string Day
        {
            get
            {
                return day;
            }

            set
            {
                day = value;
                OnPropertyChanged();
            }
        }

        public virtual BindingList<Student> Students
        {
            get
            {
                return students;
            }

            set
            {
                students = value;
            }
        }

        override public string ToString()
        {
            return numberTroop;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
