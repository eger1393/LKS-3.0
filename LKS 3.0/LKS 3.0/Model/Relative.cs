using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0
{
	public partial class Relative : INotifyPropertyChanged
	{
        public int Id { get; set; }
        private string middleName, // Фамилия
			firstName, // Имя
			lastName, // Отчество
			maidenName, // Девичья фамилия
			birthday, // Дата рождения
			placeOfResidence, // ардес проживания
			placeOfRegestration, // адрес регистрации
			mobilePhone, // мобильный телефон 
			relationDegree, // степень родства
			healthStatus; // состояние здоровья
        public Student Student { get; set; }


        public string Initials
		{
            get
            {
                if (String.IsNullOrEmpty(MiddleName) || String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName))
                {
                    throw new Exception("Данные родсвенниках! В созданном файле могут отсутствовать данные!\n");
                }
                return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
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
		[RusName("Девичья фамилия")]
		public string MaidenName
		{
			get
			{
				return maidenName;
			}
			set
			{
				maidenName = value;
				OnPropertyChanged();
			}
		}
		[RusName("Степень родства")]
		public string RelationDegree
		{
			get
			{
				return relationDegree;
			}
			set
			{
				relationDegree = value;
				OnPropertyChanged();
			}
		}
		[RusName("Дата рождения")]
		public string Birthday 
		{
			get
			{
				return birthday;
			}
			set
			{
				birthday = value;
				OnPropertyChanged("");
			}
		}
		[RusName("Мобильный телефон")]
		public string MobilePhone
		{
			get
			{
				return mobilePhone;
			}
			set
			{
				mobilePhone = value;
				OnPropertyChanged("");
			}
		}
		[RusName("Адрес проживания")]
		public string PlaceOfResidence
		{
			get
			{
				return placeOfResidence;
			}
			set
			{
				placeOfResidence = value;
				OnPropertyChanged("");
			}
		}
		[RusName("Адрес прописки")]
		public string PlaceOfRegestration
		{
			get
			{
				return placeOfRegestration;
			}
			set
			{
				placeOfRegestration = value;
				OnPropertyChanged("");
			}
		}
		[RusName("Состояние здоровья")]
		public string HealthStatus
		{
			get
			{
				return healthStatus;
			}
			set
			{
				healthStatus = value;
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
