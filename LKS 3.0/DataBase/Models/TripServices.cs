using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	// TODO здесь есть вопросы насколько все правильно
	public class TripServices
	{
		[Key]
		public string tripServicesID { get; set; }
		public string bookingID { get; set; }
		public string serviceID { get; set; }
		public string source { get; set; }
	}
}
