using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ViaBoardingTime
	{
		[Key]
		public int viaBoardingTimeID { get; set; }
		public string bookingClass { get; set; }
		public DateTime? time { get; set; }
	}
}