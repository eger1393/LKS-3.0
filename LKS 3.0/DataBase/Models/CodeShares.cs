using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class CodeShares
	{
		[Key]
		public int codeSharesID { get; set; }
		[Required]
		public string airlineCode { get; set; }
		public string suffix { get; set; }
		[Required]
		public string trackNumber { get; set; }
	}
}
