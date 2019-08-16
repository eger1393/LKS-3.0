using LKS.Data.Models;

namespace LKS.Data.Repositories
{
    public interface ITemplateRepository : IRepository<Template>
    {
        void Create(string categoryName, string subcategoryName, int type, string templateName, string pathToFile);
    }
}