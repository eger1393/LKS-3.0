using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0
{
  

    public partial class Troop:INotifyPropertyChanged
    {
        public static int _count;

        private string numberTroop, day, vus;

        

        public Student PlatoonCommander;

        private BindingList<Student> students;

       

        private bool sboriTroop;

        private int ID, staffCount;
        private int? IDPrepod, ID_PC;

        public static List<string> Ranks = new List<string>() { "КВ",
        "КО1",
        "КО2",
        "КО3",
        "Старший_секретчик",
        "Секретчик",
        "Журналист",
        " " };
        public Troop()
        {
            Students = new BindingList<Student>();
            StaffCount = Students.Count;
            IDPrepod = null;
            ID_PC = null;
        }
        public Troop(string temp_TroopNumber)
        {
            NumberTroop = temp_TroopNumber;
            Students = new BindingList<Student>();
            StaffCount = Students.Count;
            IDPrepod = null;
            ID_PC = null;
        }
        public int Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
       

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
                return staffCount;
            }
            set
            {
                staffCount = value;
                OnPropertyChanged();
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


        public int? PrepodId
        {
            get
            {
                return IDPrepod;
            }
            set
            {
                //if(value == 0)
                //{
                //    Prepod = null;
                //}
                IDPrepod = value;
            }
        }

        public  Prepod Prepod { get; set; }
        public int? Id_PC
        {
            get
            {
                return ID_PC;
            }
            set
            {
                if (value == 0)
                {
                    PlatoonCommander = null;
                }
                ID_PC = value;
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
