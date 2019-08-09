using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportImageURL
	{
		[Key]
		public string airportImageURLID { get; set; }

		public string high { get; set; }
		public string low { get; set; }
		public string medium { get; set; }
		public string native { get; set; }
	}
}
