using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ServiceText
	{
		[Key]
		public int serviceTextId { get; set; }

		[Required]
		[MaxLength(255)]
		public string title { get; set; }

		[Required]
		public int order { get; set; }

		public string text { get; set; }
	}
}
