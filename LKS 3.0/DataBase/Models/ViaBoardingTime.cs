using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ViaBoardingTime
	{
		[Key]
		public int viaBoardingTimeID { get; set; }
        [MaxLength(255)]
        public string bookingClass { get; set; }
		public DateTime? time { get; set; }
	}
}