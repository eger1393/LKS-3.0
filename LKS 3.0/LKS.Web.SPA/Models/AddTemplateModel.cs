using Microsoft.AspNetCore.Http;

namespace LKS.Web.Models
{
    public class AddTemplateModel
    {
        public string categoryId { get; set; }
        public string categoryName { get; set; }
        public string subcategoryId { get; set; }
        public string subcategoryName { get; set; }
        public int enumType { get; set; }
        public string templateName { get; set; }
        public IFormFile templateFile { get; set; }
    }
}
