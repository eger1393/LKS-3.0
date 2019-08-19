using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LKS.Data.Models
{
    public class Relative
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public Student Student { get; set; }


        public string Initials =>
        MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";

        /// <summary>
        /// Фамилия
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Девичья фамилия
        /// </summary>
        public string MaidenName { get; set; }

        /// <summary>
        /// Степень родства
        /// </summary>
        public string RelationDegree { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Адрес проживания
        /// </summary>
        public string PlaceOfResidence { get; set; }

        /// <summary>
        /// Адрес прописки
        /// </summary>
        public string PlaceOfRegestration { get; set; }

        /// <summary>
        /// Состояние здоровья
        /// </summary>
        public string HealthStatus { get; set; }
    }

}
