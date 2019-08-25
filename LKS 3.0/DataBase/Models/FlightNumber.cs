using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class FlightNumber
	{
		[Key]
		public int flightNumberID { get; set; }
		[Required]
		public string airlineCode { get; set; }
		public string suffix { get; set; }
		[Required]
		public string trackNumber { get; set; }
	}
}
