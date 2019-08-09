using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class OperatingAirline
	{
		[Key]
		public string operatingAirlineID { get; set; }
		public string iataCode { get; set; }
		public string icaoCode { get; set; }
		public string name { get; set; }
	}
}
