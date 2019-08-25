using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Specials
	{
		[Key]
		public int specialsID { get; set; }

		[Required]
		public string name { get; set; }
		public string description { get; set; }
		public int numberOfAvailable { get; set; }
		public Image image { get; set; }
		public DateTime? begin { get; set; }
		public DateTime? end { get; set; }
		public string coupon { get; set; }

	}
}
