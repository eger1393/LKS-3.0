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
        [MaxLength(255)]
        public string currentQueueName { get; set; }
        [MaxLength(50)]
        public string currentTime { get; set; }
	}
}
