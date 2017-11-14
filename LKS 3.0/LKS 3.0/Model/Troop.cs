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

        public Prepod responsiblePrepod;

        public Student platoonCommander;

        public List<Student> ListStudents;

        private bool SboriTroop;

        private int ID, ID_RP, ID_PC, staffCount;

        public Troop()
        {
            StaffCount = 0;
            ListStudents = new List<Student>();
        }
        public Troop(string temp_TroopNumber)
        {
            NumberTroop = temp_TroopNumber;
            StaffCount = 0;
            ListStudents = new List<Student>();
            //ID_RP = responsiblePrepod.Id;
            //ID_PC = platoonCommander.Id;
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

       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
