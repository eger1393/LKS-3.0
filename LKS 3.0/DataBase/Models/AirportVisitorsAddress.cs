using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportVisitorsAddress
	{
		[Key]
		public string airportVisitorsAddressID { get; set; }
		public string country_name { get; set; }
		public string country_tag { get; set; }
		public string extended_address { get; set; }
		public string locality { get; set; }
		public string post_office_box { get; set; }
		public string postal_code { get; set; }
		public string region { get; set; }
		public string street_address { get; set; }
	}
}
