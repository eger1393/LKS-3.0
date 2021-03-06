﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Models;

namespace LKS.Web.Models
{
	public class SaveStudentModel
	{
		[Required]
		public Student Student { get; set; }

		public List<Relative> Relatives { get; set; }

		//[Required]
		public IFormFile Photo { get; set; }
	}
}
