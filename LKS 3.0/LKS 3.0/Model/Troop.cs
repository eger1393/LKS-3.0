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

        private string numberTroop;

        public Prepod ResponsiblePrepod;

        public Student PlatoonCommander;

        public BindingList<Student> ListStudents;

        private bool sboriTroop;

        private int ID, ID_RP, ID_PC, staffCount;

        public Troop()
        {
            StaffCount = 0;
            ListStudents = new BindingList<Student>();
            StaffCount = ListStudents.Count;
            ID_RP = 0;
            ID_PC = 0;
        }
        public Troop(string temp_TroopNumber)
        {
            NumberTroop = temp_TroopNumber;
            StaffCount = 0;
            ListStudents = new BindingList<Student>();
            StaffCount = ListStudents.Count;
            ID_RP = 0;
            ID_PC = 0;
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

        public int Id_RP
        {
            get
            {
                return ID_RP;
            }
            set
            {
                ID_RP = value;
            }
        }

        public int Id_PC
        {
            get
            {
                return ID_PC;
            }
            set
            {
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
