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

		[MaxLength(10)]
		public string icaoCode{ get; set; }
        [MaxLength(255)]
        public string modelName{ get; set; }
        [MaxLength(50)]
        public string registration{ get; set; }
	}
}
