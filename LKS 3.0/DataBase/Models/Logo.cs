using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Logo
	{
		[Key]
		public int logoID { get; set; }

        [MaxLength(20)]
        public string logo_high { get; set; }
        [MaxLength(20)]
        public string logo_low { get; set; }
        [MaxLength(20)]
        public string logo_medium { get; set; }
        [MaxLength(20)]
        public string logo_native { get; set; }

	}
}
