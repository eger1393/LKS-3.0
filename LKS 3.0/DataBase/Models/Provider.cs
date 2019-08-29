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

        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(100)]
        public string fax { get; set; }

		public Logo logo { get; set; }

		[Required]
        [MaxLength(255)]
        public string name { get; set; }
        [MaxLength(50)]
        public string phone { get; set; }
        [MaxLength(100)]
        public string website { get; set; }
	}
}
