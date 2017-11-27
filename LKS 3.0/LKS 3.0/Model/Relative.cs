using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0
{
	public partial class Relative:INotifyPropertyChanged
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
			maidenName, // Девичья фамилия
			birthday, // Дата рождения
			placeOfResidence, // ардес проживания
			placeOfRegestration, // адрес регистрации
			mobilePhone, // мобильный телефон 
			relationDegree, // степень родства
			healthStatus; // состояние здоровья

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

        public int IdStudent
        { get; set; }

		public string initials()
		{
			return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
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
		public string Birthday // Номер мобильного телефона
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
    }
}
