using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	// TODO Уточнить, модель на картинке больше чем моель на схеме в гите
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
	}
}
