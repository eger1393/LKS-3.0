using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class FlightNumber
	{
		[Key]
		public string flightNumberID { get; set; }
		public string airlineCode { get; set; }
		public string suffix { get; set; }
		public string trackNumber { get; set; }
	}
}
