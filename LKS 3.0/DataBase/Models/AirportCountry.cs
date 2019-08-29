using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportCountry
	{
		[Key]
		public int airportCountryID { get; set; }
        [MaxLength(255)]
        public string countryName { get; set; }

	}
}
