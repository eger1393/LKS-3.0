using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportCurrentQueueTimes
	{
		[Key]
		public int? airportCurrentQueueTimesID { get; set; }
		public int? currentProjectedMaxWaitTime { get; set; }
		public int? currentProjectedMinWaitTime { get; set; }
		public int? currentProjectedWaitTime { get; set; }
		public string currentQueueName { get; set; }
		public string currentTime { get; set; }
	}
}
