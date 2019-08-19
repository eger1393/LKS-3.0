using LKS.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LKS.Data.Models
{
    public class Prepod
    {
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Взвода
        /// </summary>
		public virtual List<Troop> Troops { get; set; }
        public string Initials => FirstName[0] + ". " + MiddleName;

        /// <summary>
        /// Фамилия
        /// </summary>
		public string MiddleName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Звание
        /// </summary>
        public Coolness Coolness { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string PrepodRank { get; set; }
        /// <summary>
        /// Дополнитепльно
        /// </summary>
        public string AdditionalInfo { get; set; }

        public string GetCoolnessValue
        {
            get
            {
                switch (Coolness)
                {
                    case Coolness.Col:
                        return "ПК";
                    case Coolness.LtCol:
                        return "ППК";
                    case Coolness.Maj:
                        return "Мр";
                    case Coolness.Capt:
                        return "Кп";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}