using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Airline
	{
		[Key]
		public string airlineID { get; set; }
		public string airlineName { get; set; }
		public string checkIn { get; set; }
		public string checkInTime { get; set; }
		public AirlineContact airlineContact { get; set; }
		public string email { get; set; }
		public string faxNumber { get; set; }
		public string flightNumberCode { get; set; }
		public string handlingAgent { get; set; }
		public string iataCode { get; set; }
		public string icaoCode { get; set; }
		public string info { get; set; }
		public string lateNightArea { get; set; }
		public string lateNightTimes { get; set; }
		public string onlineCheckInURL { get; set; }
		public string serviceTime { get; set; }
		public string telephoneNumber { get; set; }
		public string terminal { get; set; }
	}
}
