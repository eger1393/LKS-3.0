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
        [MaxLength(255)]
        public string currentQueueName { get; set; }
        [MaxLength(50)]
        public string currentTime { get; set; }
	}
}
