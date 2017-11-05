using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0
{
    public class Student:INotifyPropertyChanged
    {
		private string middleName,
			firstName,
			lastName,
			troop,
			group,
			faculty,
			specialityName,
			conditionsOfEducation,
			numberOfOrder,
			dateOfOrder,
			avarageScore,
			rectal,
			birthday,
			placeBirthday,
			nationality,
			citizenship,
			homePhone,
			mobilePhone,
			placeOfResidence,
			placeOfRegestration,
			school,
			rank,
		//private int 
			yearOfAddMAI,
			yearOfEndMAI,
			yearOfAddVK,
			yearOfEndVK;

		public enum Student_Rank
        {
            Командир_взвода = 1,
            Заместитель_КВ,
            КО1,
            КО2,
            КО3,
            Журналист,
            Заместитель_журналиста,
            Студент
        }
        public Student() // Конструктор по умолчанию
        {
			
        }

        public Student(string M_name, string F_name, string L_name, string group, string troop, string phone) //, Student_Rank rang)
        {
            this.MiddleName = M_name;
            this.FirstName = F_name;
            this.LastName = L_name;
            this.Group = group;
            this.Troop = troop;
            this.MobilePhone = phone;
        }

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		public int Id { get; set; }

        //public Image PathPhoto;

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
				OnPropertyChanged("MiddleName");
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
				OnPropertyChanged("FirstName");
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
				OnPropertyChanged("LastName");
			}
		}
        [RusName("Взвод")]
        public string Troop // Взвод
        {
			get
			{
				return troop;
			}
			set
			{
				troop = value;
				OnPropertyChanged("Troop");
			}
		}
        [RusName("Год поступления в МАИ")]
        public string YearOfAddMAI
        {
            get
			{
				return yearOfAddMAI;
			}
			set
			{
				yearOfAddMAI = value;
				OnPropertyChanged("YearOfAddMAI");
			}

        }
        [RusName("Год окончания МАИ")]
        public string YearOfEndMAI
        {
            get
			{
				return yearOfEndMAI;
			}
			set
			{
				yearOfEndMAI = value;
				OnPropertyChanged("YearOfEndMAI");
			}
        }
        [RusName("Год поступления на ВК")]
        public string YearOfAddVK
        {
            get
			{
				return yearOfAddVK;
			}
			set
			{
				yearOfAddVK = value;
				OnPropertyChanged("YearOfAddVK");
			}
        }
        [RusName("Год окончания ВК")]
        public string YearOfEndVK
        {
            get
			{
				return yearOfEndVK;
			}
			set
			{
				yearOfEndVK = value;
				OnPropertyChanged("YearOfEndVK");
			}
        }
        [RusName("Группа")]
        public string Group
        {
			get
			{
				return group;
			}
			set
			{
				group = value;
				OnPropertyChanged("Group");
			}
		} // Группа студента
        [RusName("Факультет")]
        public string Faculty // факультет
		{
			get
			{
				return faculty;
			}
			set
			{
				faculty = value;
				OnPropertyChanged("Faculty");
			}
		} 
        [RusName("Специальность в ВУЗе")]
        public string SpecialityName // Название специальности
		{
			get
			{
				return specialityName;
			}
			set
			{
				specialityName = value;
				OnPropertyChanged("SpecialityName");
			}
		} 
        [RusName("Условия обучения в ВУЗе")]
        public string ConditionsOfEducation // условия обучения
		{
			get
			{
				return conditionsOfEducation;
			}
			set
			{
				conditionsOfEducation = value;
				OnPropertyChanged("ConditionsOfEduction"); 
			}
		} 
        [RusName("Средний балл в зач.книжке")]
        public string AvarageScore // средний балл
		{
			get
			{
				return avarageScore;
			}
			set
			{
				avarageScore = value;
				OnPropertyChanged("AvarageScore");
			}
		} 
        [RusName("№ приказа о приеме")]
        public string NumberOfOrder // номер приказа
		{
			get
			{
				return numberOfOrder;
			}
			set
			{
				numberOfOrder = value;
				OnPropertyChanged("NumberOfOrder");
			}
		} 
        [RusName("Дата приказа")]
        public string DateOfOrder
        {
			get
			{
				return dateOfOrder;
			}
			set
			{
				dateOfOrder = value;
				OnPropertyChanged("DateOfOrder");
			}
		}
        [RusName("Военкомат")]
        public string Rectal
        {
			get
			{
				return rectal;
			}
			set
			{
				rectal = value;
				OnPropertyChanged("Rectal");
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
				OnPropertyChanged("Birthday");
			}
		}
        [RusName("Место рождения")]
        public string PlaceBirthday // место рождения
        {
			get
			{
				return placeBirthday;
			}
			set
			{
				placeBirthday = value;
				OnPropertyChanged("PlaceBirthday");
			}
		}
        [RusName("Национальность")]
        public string Nationality // национальность (перечисление)
        {
			get
			{
				return nationality;
			}
			set
			{
				nationality = value;
				OnPropertyChanged("Nationality");
			}
		}
        [RusName("Гражданство")]
        public string Citizenship // Гражданство
        {
			get
			{
				return citizenship;
			}
			set
			{
				citizenship = value;
				OnPropertyChanged("Citizenship");
			}
		}
        [RusName("Дом.телефон")]
        public string HomePhone // Номер домашнего телефона
        {
			get
			{
				return homePhone;
			}
			set
			{
				homePhone = value;
				OnPropertyChanged("HomePhone");
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
				OnPropertyChanged("MobailPhone");
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
				OnPropertyChanged("PlaceOfResidence");
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
				OnPropertyChanged("PlaceOfRegestration");
			}
		}
        [RusName("Школа")]
        public string School
        {
			get
			{
				return school;
			}
			set
			{
				school = value;
				OnPropertyChanged("School");
			}
		}
        [RusName("Звание")]
        public string Rank // Звание студента (перечисление)
        {
			get
			{
				return rank;
			}
			set
			{
				rank = value;
				OnPropertyChanged("Rank");
			}
		}
        
  //      public BitmapFrame ImageBitmapFrame
		//{
		//	get;
		//	set;
		//}
        
        
    }
}
