using LKS.Data.Models;

namespace LKS.Data.Repositories
{
    public interface ITemplateRepository : IRepository<Template>
    {
        void Create((string id, string name) selectСategory, (string id, string name) selectSubcategory, int type, string templateName, string pathToFile);
    }
}