using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Logo
	{
		[Key]
		public string logoID { get; set; }

		public string logo_high { get; set; }
		public string logo_low { get; set; }
		public string logo_medium { get; set; }
		public string logo_native { get; set; }

	}
}
