using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LKS.Data.Models
{
    public class Cycle
    {
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Взвода
        /// </summary>
        public virtual List<Troop> Troops { get; set; }

        /// <summary>
        /// Номер цикла
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// ВУС
        /// </summary>
        public string VUS { get; set; }
        /// <summary>
        /// Название специальности
        /// </summary>
		public string SpecialityName { get; set; }
    }
}