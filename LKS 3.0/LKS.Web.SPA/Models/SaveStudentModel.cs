using LKS.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Web.Models
{
	public class SaveStudentModel
	{
		[Required]
		public Student Student { get; set; }

		[Required]
		public IFormFile Photo { get; set; }
	}
}
