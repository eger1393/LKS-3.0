using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ServiceItem
	{
		[Key]
		public string serviceItemID { get; set; }
		public string description { get; set; }
		public bool isBookable { get; set; }
		public string shortDescription { get; set; }
		public string subTitle { get; set; }
		public string title { get; set; }
	}
}
