using System.ComponentModel.DataAnnotations;

namespace LKS.Web.Models
{
    public class GetSubcategoriesModel
    {
        [Required]
        public string id { get; set; }
    }
}
