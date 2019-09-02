using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	//https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/d4818104ed5880ed306983aca1d71ebe20e14dc4/airline/model/airline.full.schema.json	
	public class Airline
	{
		[Key]
		public int airlineID { get; set; }
		[Required]
        [MaxLength(255)]
        public string airlineName { get; set; }
        [MaxLength(255)]
        public string checkIn { get; set; }
        [MaxLength(50)]
        public string checkInTime { get; set; }
		public AirlineContact airlineContact { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(50)]
        public string faxNumber { get; set; }
        [MaxLength(50)]
        public string flightNumberCode { get; set; }
        [MaxLength(100)]
        public string handlingAgent { get; set; }
        [MaxLength(10)]
        public string iataCode { get; set; }
		[Required]
        [MaxLength(10)]
        public string icaoCode { get; set; }
        [MaxLength(255)]
        public string info { get; set; }
        [MaxLength(255)]
        public string lateNightArea { get; set; }
        [MaxLength(255)]
        public string lateNightTimes { get; set; }
        [MaxLength(255)]
        public string onlineCheckInURL { get; set; }
        [MaxLength(50)]
        public string serviceTime { get; set; }
        [MaxLength(50)]
        public string telephoneNumber { get; set; }
        [MaxLength(255)]
        public string terminal { get; set; }
		public List<AirlineWebsite> websites { get; set; }
	}

	public class AirlineWebsite
	{
		[Key]
		public int airlineWebsiteId { get; set; }

		[Required]
		[MaxLength(255)]
		public string url { get; set; }
	}
}
