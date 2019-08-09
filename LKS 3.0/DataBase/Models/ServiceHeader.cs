using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class ServiceHeader
	{
		[Key]
		public string serviceHeaderID { get; set; }

		public string bookingID { get; set; }
		public string description { get; set; } 
		public string extBookingID { get; set; }

		// TODO не очень понятно на что это ссылатеся
		// https://github.com/ACIWorld/ACRIS_Seamless_Travel/blob/d4818104ed5880ed306983aca1d71ebe20e14dc4/bookService/model/serviceHeader.schema.json
		// "type": "object",
		//	"javaType": "java.lang.Long",
		//	"description": "Sequential number of the service",
		//	"required": true
		public string serviceID { get; set; }
	}
}
