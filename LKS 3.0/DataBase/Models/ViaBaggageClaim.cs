using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ViaBaggageClaim
	{
		[Key]
		public string viaBaggageClaimID { get; set; }
		public string carousel { get; set; }
		public DateTime expectedTimeOnCarousel { get; set; }
	}
}