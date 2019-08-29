using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Departure
	{
		[Key]
		public int departureID { get; set; }
		public DateTime? actual { get; set; }
		public List<BoardingTime> boardingTime { get; set; }
		public CheckInInfo checkInInfo { get; set; }
		public DateTime? estimated { get; set; }
        [MaxLength(10)]
        public string gate { get; set; }
		[Required]
		public DateTime scheduled { get; set; }
        [MaxLength(10)]
        public string terminal { get; set; }
	}
}
