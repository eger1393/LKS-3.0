using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	// TODO сделать через дефис
	public class ProviderContact
	{
		[Key]
		public int providerContactID { get; set; }

		[Required]
		public string country_name {get; set;}
		public string country_tag { get; set; }
		public string extended_address { get; set; }
		[Required]
		public string locality { get; set; }
		public string post_office_box { get; set; }
		public string postal_code { get; set; }
		[Required]
		public string region { get; set; }
		public string street_address { get; set; }
	}
}
