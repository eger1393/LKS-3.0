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
        private int ID;
        public Admin()
        {
            order = false;
            prepod = false;
            officer = false;
        }
        [RusName("ID")]
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
            coolness, // Звание
            rank; // Дата рождения
        private bool? order, prepod, officer;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public string initials()
        {
			try
			{
				return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
			}
			catch(System.IndexOutOfRangeException ex)
			{
				System.Windows.MessageBox.Show("Данные об администрации заполнены не полностью! В созданном файле могут отсутствовать данные!\n" /*+ ex.Message*/);
				return "";
			}

		}

        [RusName("Должность")]
        public string Rank 
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
        public string MiddleName 
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
        public string FirstName
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
        public string LastName
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
        public bool? Orders
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
        public bool? Prepod
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
        public bool? Officer
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
