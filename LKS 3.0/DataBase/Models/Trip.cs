using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class Trip
	{
		[Key]
		public int tripID { get; set; }
		[Required]
		public DateTime endDate { get; set; }
        [MaxLength(255)]
        public string flights { get; set; }
		[Required]
        [MaxLength(255)]
        public string name { get; set; }

		// TODO подумать над тем как сделать ограничение: "self", "pickup", "serviceProvider"
		[Required]
        [MaxLength(255)]
        public string role { get; set; }
		public TripServices services { get; set; }
		[Required]
		public DateTime startDate { get; set; }
	}
}
