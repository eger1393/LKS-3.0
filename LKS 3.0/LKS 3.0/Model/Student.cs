﻿using System;
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
        public BindingList<Relative> ListRelatives;
        public static int _count;
		private string imagePath;

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
            Skill1 = false;
            Skill2 = false;
            Skill3 = false;
            Skill4 = false;
            Skill5 = false;
            Skill6 = false;
        }
        public Student(string TroopName) // Конструктор с выбранным взводом
        {
            Troop = TroopName;
            Rank = "Отсутствует";
            Status = "Обучается";
            BloodType = "Не знаю";
            Kurs = 2;
            Skill1 = false;
            Skill2 = false;
            Skill3 = false;
            Skill4 = false;
            Skill5 = false;
            Skill6 = false;
        }
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		public int Id
        { get; set; }
        [RusName("Звание")]
        public string Collness
        { get; set; }
        [RusName("Фамилия")]
        public string MiddleName // Фамилия
        { get; set; }
        [RusName("Имя")]
        public string FirstName // Имя
        { get; set; }
        [RusName("Отчество")]
        public string LastName // Отчество
        { get; set; }
        [RusName("Взвод")]
        public string Troop // Взвод
        { get; set; }
        [RusName("Должность")]
        public string Rank // Звание студента (перечисление)
        { get; set; }
        [RusName("ВУС")]
        public string SpecialityName // Название специальности
        { get; set; }
        [RusName("Группа")]
        public string Group
        { get; set; }
        [RusName("Курс")]
        public int Kurs // факультет
        { get; set; }
        [RusName("Факультет")]
        public string Faculty // факультет
        { get; set; }

        [RusName("Специальность в ВУЗе")]
        public string SpecInst
        { get; set; }
        [RusName("Условия обучения в ВУЗе")]
        public string ConditionsOfEducation // условия обучения
        { get; set; }
        [RusName("Средний балл в зач.книжке")]
        public string AvarageScore // средний балл
        { get; set; }
        [RusName("Год поступления в МАИ")]
        public string YearOfAddMAI
        { get; set; }
        [RusName("Год окончания МАИ")]
        public string YearOfEndMAI
        { get; set; }
        [RusName("Год поступления на ВК")]
        public string YearOfAddVK
        { get; set; }
        [RusName("Год окончания ВК")]
        public string YearOfEndVK
        { get; set; }
        [RusName("№ приказа о приеме")]
        public string NumberOfOrder // номер приказа
        { get; set; }
        [RusName("Дата приказа")]
        public string DateOfOrder
        { get; set; }
        [RusName("Военкомат")]
        public string Rectal
        { get; set; }
        [RusName("Дата рождения")]
        public string Birthday // Номер мобильного телефона
        { get; set; }
        [RusName("Место рождения")]
        public string PlaceBirthday // место рождения
        { get; set; }
        [RusName("Национальность")]
        public string Nationality // национальность (перечисление)
        { get; set; }
        [RusName("Гражданство")]
        public string Citizenship // Гражданство
        { get; set; }
        [RusName("Дом.телефон")]
        public string HomePhone // Номер домашнего телефона
        { get; set; }
        [RusName("Мобильный телефон")]
        public string MobilePhone
        { get; set; }
        [RusName("Адрес проживания")]
        public string PlaceOfResidence
        { get; set; }
        [RusName("Адрес прописки")]
        public string PlaceOfRegestration
        { get; set; }
        [RusName("Школа")]
        public string School
        { get; set; }
        [RusName("Служба в ВС")]
		public string Military
        { get; set; }

        [RusName("Семейное положение")]
		public string FamiliStatys
        { get; set; }



        public string Two_MobilePhone
        { get; set; }
        public string Note
        { get; set; }
        public string ImagePath
        {
			get
			{
				//return imagePath;
				return AppDomain.CurrentDomain.BaseDirectory + imagePath;
			}
			set
			{
				imagePath = value;
			}
		}
        public bool Skill1
        { get; set; }

        public bool Skill2
        { get; set; }

        public bool Skill3
        { get; set; }
        public bool Skill4
        { get; set; }

        public bool Skill5
        { get; set; }

        public bool Skill6
        { get; set; }

        public string BloodType
        { get; set; }

        public string Growth
        { get; set; }

        public string ClothihgSize
        { get; set; }

        public string ShoeSize
        { get; set; }
        public string CapSize
        { get; set; }

        public string MaskSize
        { get; set; }

        public string ForeignLanguage
        { get; set; }

        public string LanguageRank
        { get; set; }

        public string Status
        { get; set; }

        public string NumSboriTroop
        { get; set; }


    }
}
