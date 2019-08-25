using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class BaggageClaim
	{
		[Key]
		public int baggageClaimID { get; set; }
		public string carousel { get; set; }
		public DateTime? expectedTimeOnCarousel { get; set; }
	}
}
