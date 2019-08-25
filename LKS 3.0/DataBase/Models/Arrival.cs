using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Arrival
	{
		[Key]
		public int arrivalID { get; set; }
		public DateTime? actual { get; set; }
		public BaggageClaim baggaageClaim { get; set; }
		public DateTime? estimated { get; set; }
		public string gate { get; set; }
		[Required]
		public DateTime scheduled { get; set; }
		public string termnal { get; set; }
		public string transferInformation { get; set; }

	}
}
