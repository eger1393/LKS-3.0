using LKS.Data.Models;
using LKS.Data.Models.Enums;
using LKS.Data.Repositories;
using System;
using System.Collections.Generic;
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

        public void Create((string id, string name) selectCategory, (string id, string name) selectSubcategory, int type, string templateName, string pathToFile)
        {
            Types enumType = (Types)type;

            if (selectCategory.id == null)
            {
                Category temp = new Category()
                {
                    Name = selectCategory.name
                };
                _context.Categories.Add(temp);

                selectCategory.id = temp.Id;
            }

            if (selectSubcategory.id == null)
            {
                Category temp = new Category()
                {
                    Name = selectSubcategory.name,
                    ParentCategoryId = selectCategory.id
                };
                _context.Categories.Add(temp);

                selectSubcategory.id = temp.Id;
            }

            Template newTemplate = new Template() { CategoryId = selectSubcategory.id, Name = templateName, Type = enumType, URI = pathToFile };

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
            throw new NotImplementedException();
        }

        public Task Update(Template item)
        {
            throw new NotImplementedException();
        }
    }
}