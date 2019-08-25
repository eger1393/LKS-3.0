using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class BoardingTime
	{
		[Key]
		public int boardingTimeID { get; set; }
		public string bookingClass { get; set; }
		public DateTime? time { get; set; }
	}
}
