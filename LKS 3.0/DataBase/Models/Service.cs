using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class Service
	{
		[Key]
		public int serviceID { get; set; }

		public List<ServiceDonwload> serviceDonwloads { get; set; }

		public Provider serviceProvider { get; set; }

		public List<Specials> specials { get; set; }
	}
}
