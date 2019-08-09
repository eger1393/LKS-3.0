using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ViaDeparture
	{
		[Key]
		public string viaDepartureID { get; set; }
		public DateTime actual { get; set; }
		public ViaBoardingTime boardingTime { get; set; }
		public ViaCheckInInfo checkInInfo { get; set; }
		public DateTime estimated { get; set; }
		public string gate { get; set; }
		public DateTime scheduled { get; set; }
		public string terminal { get; set; }

	}
}