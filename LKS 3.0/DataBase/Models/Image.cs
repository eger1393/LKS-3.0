using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Image
	{
		[Key]
		public int imageID { get; set; }

        [MaxLength(20)]
        public string high { get; set; }
        [MaxLength(20)]
        public string low { get; set; }
        [MaxLength(20)]
        public string medium { get; set; }
        [MaxLength(20)]
        public string native { get; set; }
    }
}
