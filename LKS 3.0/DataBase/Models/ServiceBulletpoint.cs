using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	//https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/d4818104ed5880ed306983aca1d71ebe20e14dc4/service/model/serviceBulletpoint.schema.json
	public class ServiceBulletpoint
	{
		[Key]
		public int serviceBulletpointId { get; set; }

		[Required]
		[MaxLength(255)]
		public string title { get; set; }

		[Required]
		public int order { get; set; }

		[MaxLength(255)]
		public string headerText { get; set; }

		[MaxLength(255)]
		public string footerText { get; set; }

		[Required]
		public List<ServiceBulletpointElements> elements { get; set; }

	}

	public class ServiceBulletpointElements
	{
		[Key]
		public int serviceBulletpointElementsId { get; set; }
		[Required]
		public string value { get; set; }
	}
}
