using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class OperatingAirline
	{
		[Key]
		public int operatingAirlineID { get; set; }
		[MaxLength(3)]
		[MinLength(2)]
		public string iataCode { get; set; }
		[MaxLength(3)]
		[MinLength(2)]
		public string icaoCode { get; set; }
		public string name { get; set; }
	}
}
