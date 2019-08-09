using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Departure
	{
		[Key]
		public string departureID { get; set; }
		public DateTime actual { get; set; }
		public BoardingTime boardingTime { get; set; }
		public CheckInInfo checkInInfo { get; set; }
		public DateTime estimated { get; set; }
		public string gate { get; set; }
		public DateTime scheduled { get; set; }
		public string terminal { get; set; }
	}
}
