using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirlineContact
	{
		[Key]
		public int airlineContactId { get; set; }
		[Required]
        [MaxLength(255)]
        public string country_name { get; set; }
        [MaxLength(100)]
        public string country_tag { get; set; }
        public string extended_address { get; set; }
		[Required]
        [MaxLength(255)]
        public string locality { get; set; }
        [MaxLength(50)]
        public string post_office_box { get; set; }
        [MaxLength(50)]
        public string postal_code { get; set; }
		[Required]
        [MaxLength(255)]
        public string region { get; set; }
        [MaxLength(255)]
        public string street_address { get; set; }
	}
}
