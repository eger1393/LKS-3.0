using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportCountry
	{
		[Key]
		public string airportCountryID { get; set; }
		public string countryName { get; set; }

	}
}
