using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ViaDeparture
	{
		[Key]
		public int viaDepartureID { get; set; }
		public DateTime? actual { get; set; }
		public ViaBoardingTime boardingTime { get; set; }
		public ViaCheckInInfo checkInInfo { get; set; }
		public DateTime? estimated { get; set; }
        [MaxLength(10)]
        public string gate { get; set; }
		[Required]
		public DateTime scheduled { get; set; }
        [MaxLength(10)]
        public string terminal { get; set; }

	}
}