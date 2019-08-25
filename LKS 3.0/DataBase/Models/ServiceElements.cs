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
		public string value { get; set; }
	}
}
