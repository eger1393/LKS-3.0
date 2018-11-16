using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LKS.Data.Models
{
	public partial class Cycle
	{
		[Key]
		public string Id { get; set; }

		public virtual List<Troop> Troops { get; set; }
		
		[DisplayName("Номер цикла")]
		public string Number { get; set; }
		[DisplayName("ВУС")]
		public string VUS { get; set; }
        [DisplayName("Наименование специальности")]
		public string SpecialityName { get; set; }
	}
}