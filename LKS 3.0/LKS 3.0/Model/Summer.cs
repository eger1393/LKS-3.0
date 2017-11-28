using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0.Model
{
    public partial class Summer : INotifyPropertyChanged
    {
        private string numberofOrder, dateOfOrder, dateBeginSbori, dateEndSbori, datePrisyaga, dateExamen, numberVK, locationVK, chiefOfStaffFIO, chiefOfStaffDuty, commanderBatteryFIO, commanderBatteryDuty,
            commanderVKFIO, commanderVKDuty, foremanBatteryFIO, foremanBatteryDuty;

        private int Id;

        public BindingList<Troop> listTroops;


        public int ID
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }

        public string NumberofOrder
        {
            get
            {
                return numberofOrder;
            }

            set
            {
                numberofOrder = value;
                OnPropertyChanged();
            }
        }

        public string DateOfOrder
        {
            get
            {
                return dateOfOrder;
            }

            set
            {
                dateOfOrder = value;
                OnPropertyChanged();
            }
        }

        public string DateBeginSbori
        {
            get
            {
                return dateBeginSbori;
            }

            set
            {
                dateBeginSbori = value;
                OnPropertyChanged();
            }
        }

        public string DateEndSbori
        {
            get
            {
                return dateEndSbori;
            }

            set
            {
                dateEndSbori = value;
                OnPropertyChanged();
            }
        }

        public string DatePrisyaga
        {
            get
            {
                return datePrisyaga;
            }

            set
            {
                datePrisyaga = value;
                OnPropertyChanged();
            }
        }

        public string DateExamen
        {
            get
            {
                return dateExamen;
            }

            set
            {
                dateExamen = value;
                OnPropertyChanged();
            }
        }

        public string NumberVK
        {
            get
            {
                return numberVK;
            }

            set
            {
                numberVK = value;
                OnPropertyChanged();
            }
        }

        public string LocationVK
        {
            get
            {
                return locationVK;
            }

            set
            {
                locationVK = value;
                OnPropertyChanged();
            }
        }

        public string ChiefOfStaffFIO
        {
            get
            {
                return chiefOfStaffFIO;
            }

            set
            {
                chiefOfStaffFIO = value;
                OnPropertyChanged();
            }
        }

        public string ChiefOfStaffDuty
        {
            get
            {
                return chiefOfStaffDuty;
            }

            set
            {
                chiefOfStaffDuty = value;
                OnPropertyChanged();
            }
        }

        public string CommanderBatteryFIO
        {
            get
            {
                return commanderBatteryFIO;
            }

            set
            {
                commanderBatteryFIO = value;
                OnPropertyChanged();
            }
        }

        public string CommanderBatteryDuty
        {
            get
            {
                return commanderBatteryDuty;
            }

            set
            {
                commanderBatteryDuty = value;
                OnPropertyChanged();
            }
        }

        public string CommanderVKFIO
        {
            get
            {
                return commanderVKFIO;
            }

            set
            {
                commanderVKFIO = value;
                OnPropertyChanged();
            }
        }

        public string CommanderVKDuty
        {
            get
            {
                return commanderVKDuty;
            }

            set
            {
                commanderVKDuty = value;
                OnPropertyChanged();
            }
        }

        public string ForemanBatteryFIO
        {
            get
            {
                return foremanBatteryFIO;
            }

            set
            {
                foremanBatteryFIO = value;
                OnPropertyChanged();
            }
        }

        public string ForemanBatteryDuty
        {
            get
            {
                return foremanBatteryDuty;
            }

            set
            {
                foremanBatteryDuty = value;
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
