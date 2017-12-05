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
        private string numberofOrder, dateOfOrder, dateBeginSbori, dateEndSbori, datePrisyaga, dateExamen, numberVK, locationVK;

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
