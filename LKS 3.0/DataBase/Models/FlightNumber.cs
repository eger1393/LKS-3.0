using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{ 
	public class FlightNumber
	{
		[Key]
		public int flightNumberID { get; set; }
		[Required]
        [MaxLength(50)]
        public string airlineCode { get; set; }
        [MaxLength(50)]
        public string suffix { get; set; }
		[Required]
        [MaxLength(50)]
        public string trackNumber { get; set; }
	}
}
