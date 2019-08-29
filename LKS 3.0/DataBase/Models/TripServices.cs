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
		public int tripServicesID { get; set; }
		public string bookingID { get; set; }
		[Required]
		public string serviceID { get; set; }
		[Required]
        [MaxLength(255)]
        public string source { get; set; }
	}
}
