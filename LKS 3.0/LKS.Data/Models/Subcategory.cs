using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LKS.Data.Models
{
    public class Subcategory
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
