using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AircraftType
	{
		[Key]
		public string aircraftTypeID { get; set; }

		public string icaoCode{ get; set; }
		public string modelName{ get; set; }
		public string registration{ get; set; }
	}
}
