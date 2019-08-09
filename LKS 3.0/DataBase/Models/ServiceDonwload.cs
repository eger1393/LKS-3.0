using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ServiceDonwload
	{
		[Key]
		public string serviceDonwloadID { get; set; }
		public string value { get; set; }
	}
}
