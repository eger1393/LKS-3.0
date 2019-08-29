using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportImageURL
	{
		[Key]
		public int airportImageURLID { get; set; }

        [MaxLength(20)]
        public string high { get; set; }
        [MaxLength(20)]
        public string low { get; set; }
        [MaxLength(20)]
        public string medium { get; set; }
        [MaxLength(20)]
        public string native { get; set; }
	}
}
