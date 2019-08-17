using LKS.Data.Models;
using LKS.Data.Models.Enums;
using LKS.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly DataContext _context;
        public TemplateRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Create(Template item)
        {
            _context.Templates.Add(item);
            _context.SaveChanges();
        }

        public void Create(string categoryName, string subcategoryName, int type, string templateName, string pathToFile)
        {
            TemplateTypes enumType = (TemplateTypes)type;

            var category = _context.Categories.Include(x => x.Subcategories).FirstOrDefault(value => value.Name.ToLower() == categoryName.ToLower());
            if (category == null)
            {
                category = new Category() { Name = categoryName };
            }

            var subcategory = category.Subcategories
                .FirstOrDefault(value => value.Name.ToLower() == subcategoryName.ToLower());
            if (subcategory == null)
            {
                category.Subcategories.Add(new Category() { Name = subcategoryName });
            }

            var newTemplate = new Template() { Category = category, Name = templateName, Type = enumType, URL = pathToFile };

            _context.Templates.Add(newTemplate);
            _context.SaveChanges();
        }

        public Task CreateRange(ICollection<Template> item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Template item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(ICollection<Template> item)
        {
            throw new NotImplementedException();
        }

        public Task<Template> GetItem(string id)
        {
			return _context.Templates.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task Update(Template item)
        {
            throw new NotImplementedException();
        }

		public List<Template> GetTemplates(string subCategoryId)
		{
			return _context.Templates.Where(x => x.CategoryId == subCategoryId).ToList();
		}
    }
}