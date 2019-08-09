using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class Trip
	{
		[Key]
		public string tripID { get; set; }
		public DateTime endDate { get; set; }
		public string flights { get; set; }
		public string name { get; set; }

		// TODO подумать над тем как сделать ограничение: "self", "pickup", "serviceProvider"
		public string role { get; set; }
		public TripServices services { get; set; }
		public DateTime startDate { get; set; }
	}
}
