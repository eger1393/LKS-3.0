using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportCoordinate
	{
		[Key]
		public string airportCoordinateID { get; set; }
		public int	elevation { get; set; }
		
		public double latitude { get; set; }
		public double lonqitude { get; set; }
	}
}
