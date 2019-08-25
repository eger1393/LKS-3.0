using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Provider
	{
		[Key]
		public int providerID { get; set; }

		public ProviderContact contact { get; set; }

		public string email { get; set; }
		public string fax { get; set; }

		public Logo logo { get; set; }

		[Required]
		public string name { get; set; }
		public string phone { get; set; }
		public string website { get; set; }
	}
}
