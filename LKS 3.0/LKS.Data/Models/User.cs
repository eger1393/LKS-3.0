using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LKS.Data.Models
{
	public class User
	{
		[Key]
		public string Id { get; set; }
		[Required]
		public string Login { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Role { get; set; }

		/// <summary>
		/// id взвода, нужен чтобы выдавать пользователю только его взвод
		/// </summary>
		public string TroopId { get; set; }
	}
}
