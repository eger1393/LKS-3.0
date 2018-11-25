using LKS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Web.SPA.Models
{
	public class SetStudentPositionModel
	{
		[Required]
		public string id { get; set; }

		[Required]
		public StudentPosition position { get; set; }
	}
}
