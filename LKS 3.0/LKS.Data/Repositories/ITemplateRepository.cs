using LKS.Data.Models;
using System.Collections.Generic;

namespace LKS.Data.Repositories
{
    public interface ITemplateRepository : IRepository<Template>
    {
        void Create((string id, string name) selectСategory, (string id, string name) selectSubcategory, int type, string templateName, string pathToFile);
		List<Template> GetTemplates(string subCategoryId);
		void DeleteTemplate(string id);
	}
}