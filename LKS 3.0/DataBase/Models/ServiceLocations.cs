using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ServiceLocations
	{
		[Key]
		public string serviceLocationsID { get; set; }

		public string area { get; set; }
		public string description { get; set; }
		public string humanReadable { get; set; }
		public Image mapImage { get; set; }
		public List<OpeningHour> openingHource { get; set; }
		public int x { get; set; }
		public int y { get; set; }
		public int z { get; set; }
	}

	public class OpeningHour
	{
		[Key]
		public string openingHourID { get; set; }

		//The left item (first columng) of the table. Its allowed to put everything here like a date or a header. The text will not be formated and has to be in the correct format."
		//https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/d4818104ed5880ed306983aca1d71ebe20e14dc4/service/model/location.full.schema.json
		public string column1 { get; set; }
		public string column2 { get; set; }
	}
}
