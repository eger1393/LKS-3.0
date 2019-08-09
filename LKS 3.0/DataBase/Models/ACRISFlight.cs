using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ACRISFlight
	{
		[Key]
		public string ACRISFlightID { get; set; }

		public AircraftType aircrafType { get; set; }
		public Arrival arrival { get; set; }
		public string arrivalAirport { get; set; }
		public CodeShares codeShares { get; set; }
		public Departure departure { get; set; }
		public string departureAirport { get; set; }
		public FlightNumber flightNumber { get; set; }
		// TODO сделать строковое перечисление FlightStatus
		public string flightStatus { get; set; }
		public OperatingAirline operatingAirline { get; set; }
		public DateTime originDate { get; set; }
		public Via via { get; set; }

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
