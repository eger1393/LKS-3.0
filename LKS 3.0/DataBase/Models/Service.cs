using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Service
	{
		[Key]
		public string serviceID { get; set; }

		public List<ServiceDonwload> serviceDonwloads { get; set; }

		public Provider serviceProvider { get; set; }

		public Specials specials { get; set; }
	}
}
