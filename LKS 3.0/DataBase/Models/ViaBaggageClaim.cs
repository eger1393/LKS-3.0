using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ViaBaggageClaim
	{
		[Key]
		public int viaBaggageClaimID { get; set; }
        [MaxLength(255)]
        public string carousel { get; set; }
		public DateTime? expectedTimeOnCarousel { get; set; }
	}
}