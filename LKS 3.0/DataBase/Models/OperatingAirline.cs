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
		[MaxLength(10)]
		public string iataCode { get; set; }
		[MaxLength(10)]
		public string icaoCode { get; set; }
        [MaxLength(255)]
        public string name { get; set; }
	}
}
