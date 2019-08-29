using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	// TODO где это исспользуется?
	public class ServiceElements
	{
		[Key]
		public int serviceElementsID { get; set; }
        [MaxLength(255)]
        public string value { get; set; }
	}
}
