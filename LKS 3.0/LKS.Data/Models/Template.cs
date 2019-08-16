using LKS.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LKS.Data.Models
{
    public class Template
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public Types Type { get; set; }
        [Required]
        public string URL { get; set; }
    }
}
