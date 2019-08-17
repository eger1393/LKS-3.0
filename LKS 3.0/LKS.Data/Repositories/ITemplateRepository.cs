using LKS.Data.Models;
using System.Collections.Generic;

namespace LKS.Data.Repositories
{
    public interface ITemplateRepository : IRepository<Template>
    {
        void Create(string categoryName, string subcategoryName, int type, string templateName, string pathToFile);
		List<Template> GetTemplates(string subCategoryId);

	}
}