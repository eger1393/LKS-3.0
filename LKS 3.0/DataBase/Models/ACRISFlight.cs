using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	//https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/master/acrisFlight/model/ACRISFlight.schema.json
	public class ACRISFlight
	{
		[Key]
		public int ACRISFlightID { get; set; }

		public AircraftType aircrafType { get; set; }
		public Arrival arrival { get; set; }
        [MaxLength(255)]
        public string arrivalAirport { get; set; }
		public List<FlightNumber> codeShares { get; set; }
		public Departure departure { get; set; }
        [MaxLength(255)]
        public string departureAirport { get; set; }
		[Required]
		public FlightNumber flightNumber { get; set; }
		// TODO сделать строковое перечисление FlightStatus
		[Required]
        [MaxLength(100)]
        public string flightStatus { get; set; }
		[Required]
		public OperatingAirline operatingAirline { get; set; }
		public DateTime? originDate { get; set; }
		public List<Via> via { get; set; }

	}

	// https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/master/acrisFlight/model/ACRISFlight.schema.json
	public enum FlightStatus
	{
		Canceled,
		Diverted,
		Scheduled,
		GateOpened,
		Boarding,
		GateClosed,
		Departed,
		InApproach,
		Landed,
		BagClaimStarted,
		FlightFinished
	}
}
