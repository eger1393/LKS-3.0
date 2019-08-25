using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Via
	{
		[Key]
		public int viaID { get; set; }
		public ViaArrival arrival { get; set; }
		public ViaDeparture departure { get; set; }
		public string viaAirport { get; set; }

	}
}
