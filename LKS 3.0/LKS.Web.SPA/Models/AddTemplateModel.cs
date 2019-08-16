using Microsoft.AspNetCore.Http;

namespace LKS.Web.Models
{
    public class AddTemplateModel
    {
        public string category { get; set; }
        public string subcategory { get; set; }
        public int enumType { get; set; }
        public string templateName { get; set; }
        public IFormFile templateFile { get; set; }
    }
}
