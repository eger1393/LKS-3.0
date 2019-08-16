using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LKS.Data.Models
{
    public class Category
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<Category> Subcategories { get; set; }
    }
}
