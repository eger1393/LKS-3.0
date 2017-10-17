using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            MiddleName = "111";
            FirstName = "111";
            LastName = "111";
            Group = "111";
            Troop = "111";
            MobilePhone = "111";

        }

        public Student(string M_name, string F_name, string L_name, string group, string troop, string phone) //, Student_Rank rang)
        {
            this.MiddleName = M_name;
            this.FirstName = F_name;
            this.LastName = L_name;
            this.Group = group;
            this.Troop = troop;
            this.MobilePhone = phone;
            //this.Rank = rang;
        }

        public int Id { get; set; }

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
        [RusName("Группа")]
        public string Group
        { get; set; } // Группа студента
        [RusName("Телефон")]
        public string MobilePhone // Номер моильного телефона
        { get; set; }

        //[RusName("Звание")]
        //public Student_Rank Rank // Звание студента (перечисление)
        //{ get; set; }

        //string HomePhone // Номер домашнего телефона
        //{ get; set; }


        //// TODO добавить перечесление специальностей после уточнения(?), перечисление званий, национальностей

        //// возможно извенить поле на целочисленное и исспользовать перечисление
        //string SpecialityName
        //{ get; set; } // Название специальности



        //ushort Nationality // Национальность (перечисление)
        //{ get; set; }

        //string Citizenship // Гражданство
        //{ get; set; }

        //public string Добавить_поле { get; set; }
    }
}
