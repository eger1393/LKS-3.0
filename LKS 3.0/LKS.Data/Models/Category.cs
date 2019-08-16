using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LKS.Data.Models
{
	public class Category
	{
		[Key]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }

		public string ParentCategoryId { get; set; }
		
		public virtual List<Category> Subcategories { get; set; }
	}
}
