using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	//https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/d4818104ed5880ed306983aca1d71ebe20e14dc4/service/model/service.full.schema.json
	public class Service
	{
		[Key]
		public int serviceID { get; set; }

		[MaxLength(255)]
		[Required]
		public string title { get; set; }

		[MaxLength(255)]
		public string subTitle { get; set; }

		[MaxLength(255)]
		public string shortDescription { get; set; }
		
		public string description { get; set; }

		public bool isBookable { get; set; }

		public List<ServiceBulletpoint> serviceBulletpoints { get; set; }
		public List<ServiceTable> serviceTables { get; set; }
		public List<ServiceText> serviceTexts { get; set; }

		public Image icon { get; set; }

		public Image titleImage { get; set; }

		public Image titleImage_small { get; set; }

		public Image desciptionImage_vertical { get; set; }

		public Image descriptionImage_horizontal { get; set; }

		public List<ServiceDonwloads> downloads { get; set; }
		//public List<ServiceDonwload> serviceDonwloads { get; set; }

		public Provider provider { get; set; }

		public List<Specials> specials { get; set; }
	}

	public class ServiceDonwloads
	{
		[Key]
		public int serviceDonwloadsId { get; set; }

		[Required]
		[MaxLength(255)]
		public string url { get; set; }
	}
}
