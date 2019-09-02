using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Website
	{
		[Key]
		public int websiteId { get; set; }

		[Required]
		[MaxLength(255)]
		public string url { get; set; }
	}
}
