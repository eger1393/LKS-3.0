using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ServiceLocations
	{
		[Key]
		public int serviceLocationsID { get; set; }

		[Required]
		public string area { get; set; }
		public string description { get; set; }
		[Required]
		public string humanReadable { get; set; }
		public Image mapImage { get; set; }
		public List<OpeningHour> openingHours { get; set; }
		[Required]
		public int x { get; set; }
		[Required]
		public int y { get; set; }
		[Required]
		public int z { get; set; }
	}

	public class OpeningHour
	{
		[Key]
		public int openingHourID { get; set; }

		//The left item (first columng) of the table. Its allowed to put everything here like a date or a header. The text will not be formated and has to be in the correct format."
		//https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/d4818104ed5880ed306983aca1d71ebe20e14dc4/service/model/location.full.schema.json
		[Required]
		public string column1 { get; set; }
		[Required]
		public string column2 { get; set; }
	}
}
