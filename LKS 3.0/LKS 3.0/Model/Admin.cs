using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0.Model
{
    public partial class Admin : INotifyPropertyChanged
    {
        public static int _count;

        private int ID;

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
        private string middleName, // Фамилия
            firstName, // Имя
            lastName, // Отчество
            coolness, // Девичья фамилия
            rank; // Дата рождения
        private bool order, prepod, officer;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public string initials()
        {
            return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
        }

        [RusName("Должность")]
        public string Rank // Номер мобильного телефона
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
                OnPropertyChanged("");
            }
        }
        [RusName("Фамилия")]
        public string MiddleName // Фамилия
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
                OnPropertyChanged();
            }
        }
        [RusName("Имя")]
        public string FirstName // Имя
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        [RusName("Отчество")]
        public string LastName // Отчество
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        [RusName("Звание")]
        public string Collness
        {
            get
            {
                return coolness;
            }
            set
            {
                coolness = value;
                OnPropertyChanged();
            }
        }
        [RusName("Доведение приказа")]
        public bool Order
        {
            get
            {
                return order;
            }

            set
            {
                order = value;
                OnPropertyChanged();
            }
        }

        [RusName("Преподаватель")]
        public bool Prepod
        {
            get
            {
                return prepod;
            }

            set
            {
                prepod = value;
                OnPropertyChanged();
            }
        }

        [RusName("Офицер ФВО")]
        public bool Officer
        {
            get
            {
                return officer;
            }

            set
            {
                officer = value;
                OnPropertyChanged();
            }
        }
    }
}
