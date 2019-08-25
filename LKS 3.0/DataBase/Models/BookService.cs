using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class BookService
	{
		[Key]
		public int bookServiceID { get; set; }
		public ServiceHeader serviceHeader { get; set; }
	}
}
