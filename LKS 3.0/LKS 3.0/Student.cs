using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace LKS_3._0
{
    public class Student
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

        public int Id { get; set; }

        //public Image PathPhoto;

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
        [RusName("Год поступления в МАИ")]
        public int YearOfAddMAI
        {
            get; set;
        }
        [RusName("Год окончания МАИ")]
        public int YearOfEndMAI
        {
            get; set;
        }
        [RusName("Год поступления на ВК")]
        public int YearOfAddVK
        {
            get; set;
        }
        [RusName("Год окончания ВК")]
        public int YearOfEndVK
        {
            get; set;
        }



        [RusName("Группа")]
        public string Group
        { get; set; } // Группа студента
        [RusName("Факультет")]
        public string Faculty
        { get; set; } // факультет
        [RusName("Специальность в ВУЗе")]
        public string SpecialityName
        { get; set; } // Название специальности
        [RusName("Условия обучения в ВУЗе")]
        public string ConditionsOfEducation
        { get; set; } // условия обучения
        [RusName("Средний балл в зач.книжке")]
        public string AvarageScore
        { get; set; } // средний балл
        [RusName("№ приказа о приеме")]
        public string NumberOfOrder
        { get; set; } // номер приказа
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
        public string PlaceBirthday // Номер мобильного телефона
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
        [RusName("Звание")]
        public string Rank // Звание студента (перечисление)
        { get; set; }
        
        
        
        
    }
}
