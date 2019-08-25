using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportCoordinate
	{
		[Key]
		public int airportCoordinateID { get; set; }
		public int?	elevation { get; set; }
		
		[Required]
		public double latitude { get; set; }
		[Required]
		public double lonqitude { get; set; }
	}
}
