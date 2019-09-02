using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	//https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/master/acrisFlight/model/flightArrivalInformation.schema.json
	public class Arrival
	{
		[Key]
		public int arrivalID { get; set; }
		public DateTime? actual { get; set; }
		public BaggageClaim baggaageClaim { get; set; }
		public DateTime? estimated { get; set; }
        [MaxLength(10)]
        public string gate { get; set; }
		[Required]
		public DateTime scheduled { get; set; }
        [MaxLength(10)]
        public string termnal { get; set; }
		public string transferInformation { get; set; }

	}
}
