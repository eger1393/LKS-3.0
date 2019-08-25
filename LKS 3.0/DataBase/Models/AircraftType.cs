using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AircraftType
	{
		[Key]
		public int aircraftTypeID { get; set; }

		[MinLength(4)]
		[MaxLength(4)]
		public string icaoCode{ get; set; }
		public string modelName{ get; set; }
		public string registration{ get; set; }
	}
}
