using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LKS.Models
{
	public partial class Cycle
	{
        public Cycle()
        {
            VUS = "042600";
			VuzName = "МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ (национальный исследовательский университет)(МАИ)";
			VkName = "Военная кафедра \"МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ (национальный исследовательский университет)\"(МАИ)";
			SpecialityName = "Боевое применение частей и подразделений войсковой ПВО";
        }
        
		[Key]
		public string Id { get; set; }
		public virtual List<Troop> Troops { get; set; }
		
		[DisplayName("Номер цикла")]
		public string Number { get; set; }
		[DisplayName("ВУС")]
		public string VUS { get; set; }
		[DisplayName("Наименование ВУЗа")]
		public string VuzName { get; set; }
        [DisplayName("Наименование военной кафедры")]
		public string VkName { get; set; }
        [DisplayName("Наименование специальности")]
		public string SpecialityName { get; set; }
	}
}