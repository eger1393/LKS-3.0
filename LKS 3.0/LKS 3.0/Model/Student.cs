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
            yearOfEndVK,
            blood_type,
            growth,
            clothing_size,
            shoe_size,
            cap_size,
            mask_size,
            foreignLanguage,
            languageRank,
			familiStatys, // семейное полжоение
			military, // Служба в ВС
			specInst,
			status;


        private bool
            skill_1 = false,
            skill_2 = false,
            skill_3 = false,
            skill_4 = false,
            skill_5 = false,
            skill_6 = false;

        public BindingList<Relative> ListRelatives;

        private string numSboriTroop;

        private string imagePath;

        public static int _count;

        private int ID, kurs;

		public string initials()
		{
			return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
		}

        public override string ToString()
        {
            return String.Format("{0} {1}. {2}.",
               MiddleName, FirstName[0], LastName[0]);
        }

         public string str_FIO
        {
            get
            {
                return ToString();
            }
        }
       
        public Student() // Конструктор по умолчанию
        {
			
        }
        public Student(string TroopName) // Конструктор по умолчанию
        {
            Troop = TroopName;
            Rank = "Отсутствует";
            Status = "Обучается";
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
        [RusName("Должность")]
        public string Rank // Звание студента (перечисление)
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
            }
        }
        [RusName("ВУС")]
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
		}
        [RusName("Курс")]
        public int Kurs // факультет
        {
            get
            {
                return kurs;
            }
            set
            {
                kurs = value;
                OnPropertyChanged("Kurs");
            }
        }
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
        public string SpecInst
        {
            get
            {
                return specInst;
            }
            set
            {
                specInst = value;
                OnPropertyChanged();
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

		[RusName("Служба в ВС")]
		public string Military
		{
			get
			{
				return military;
			}
			set
			{
				military = value;
				OnPropertyChanged();
			}
		}

		[RusName("Семейное положение")]
		public string FamiliStatys
		{
			get
			{
				return familiStatys;
			}
			set
			{
				familiStatys = value;
				OnPropertyChanged();
			}
		}

	



		public string ImagePath
		{
			get
			{
				return imagePath;
			}
			set
			{
				imagePath = value;
			}
		}


        public bool Skill1
        {
            get
            {
                return skill_1;
            }
            set
            {
                skill_1 = value;
            }
        }

        public bool Skill2
        {
            get
            {
                return skill_2;
            }
            set
            {
                skill_2 = value;
            }
        }

        public bool Skill3
        {
            get
            {
                return skill_3;
            }
            set
            {
                skill_3 = value;
            }
        }
        public bool Skill4
        {
            get
            {
                return skill_4;
            }
            set
            {
                skill_4 = value;
            }
        }

        public bool Skill5
        {
            get
            {
                return skill_5;
            }
            set
            {
                skill_5 = value;
            }
        }

        public bool Skill6
        {
            get
            {
                return skill_6;
            }
            set
            {
                skill_6 = value;
            }
        }

        public string BloodType
        {
            get
            {
                return blood_type;
            }
            set
            {
                blood_type = value;
            }
        }

        public string Growth
        {
            get
            {
                return growth;
            }
            set
            {
                growth = value;
            }
        }

        public string ClothihgSize
        {
            get
            {
                return clothing_size;
            }
            set
            {
                clothing_size = value;
            }
        }

        public string ShoeSize
        {
            get
            {
                return shoe_size;
            }
            set
            {
                shoe_size = value;
            }
        }

        public string CapSize
        {
            get
            {
                return cap_size;
            }
            set
            {
                cap_size = value;
            }
        }

        public string MaskSize
        {
            get
            {
                return mask_size;
            }
            set
            {
                mask_size = value;
            }
        }

        public string ForeignLanguage
        {
            get
            {
                return foreignLanguage;
            }
            set
            {
                foreignLanguage = value;
            }
        }

        public string LanguageRank
        {
            get
            {
                return languageRank;
            }
            set
            {
               languageRank = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public string NumSboriTroop
        {
            get
            {
                return numSboriTroop;
            }

            set
            {
                numSboriTroop = value;
                OnPropertyChanged();
            }
        }
    }
}
