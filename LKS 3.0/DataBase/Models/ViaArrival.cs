using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ViaArrival
	{
		[Key]
		public string viaArrivalID { get; set; }
		public DateTime actual { get; set; }
		public ViaBaggageClaim baggaageClaim { get; set; }
		public DateTime estimated { get; set; }
		public string gate { get; set; }
		public DateTime scheduled { get; set; }
		public string termnal { get; set; }
		public string transferInformation { get; set; }
	}
}
