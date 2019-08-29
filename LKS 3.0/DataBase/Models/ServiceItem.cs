using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ServiceItem
	{
		[Key]
		public int serviceItemID { get; set; }
		public string description { get; set; }
		public bool isBookable { get; set; }
        [MaxLength(255)]
        public string shortDescription { get; set; }
        [MaxLength(255)]
        public string subTitle { get; set; }
		[Required]
        [MaxLength(255)]
        public string title { get; set; }
	}
}
