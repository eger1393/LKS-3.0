using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportForecastQueueTimes
	{
		[Key]
		public int airportForecastQueueTimesID { get; set; }

		public int? forecastConfidence { get; set; }
		public int? forecastProjectedWaitTime { get; set; }
		public string currentQueueName { get; set; }
		public string currentTime { get; set; }
	}
}
