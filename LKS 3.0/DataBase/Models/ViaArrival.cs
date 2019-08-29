using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ViaArrival
	{
		[Key]
		public int viaArrivalID { get; set; }
		public DateTime? actual { get; set; }
		public ViaBaggageClaim baggaageClaim { get; set; }
		public DateTime? estimated { get; set; }
        [MaxLength(10)]
        public string gate { get; set; }
		[Required]
		public DateTime scheduled { get; set; }
        [MaxLength(10)]
        public string termnal { get; set; }
        [MaxLength(255)]
        public string transferInformation { get; set; }
	}
}
