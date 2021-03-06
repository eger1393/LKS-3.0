﻿using LKS.Data.Models;
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

		public void DeleteTemplate(string id)
		{
			var template = _context.Templates.FirstOrDefault(x => x.Id == id);
			_context.Templates.Remove(template);
			// Сравниваем с 1, т.к. в этот моемент SaveChanges еще не применен и в подкатегории должен остаться только удаляемый шаблон
			if (_context.Templates.Where(x => x.CategoryId == template.CategoryId).Count() == 1)
			{
				var subCategory = _context.Categories.FirstOrDefault(x => x.Id == template.CategoryId);
				_context.Categories.Remove(subCategory);
				if(_context.Categories.Where(x => x.ParentCategoryId == subCategory.ParentCategoryId).Count() == 1)
				{
					var category = _context.Categories.FirstOrDefault(x => x.Id == subCategory.ParentCategoryId);
					_context.Categories.Remove(category);
				}
			}
			_context.SaveChanges();
		}

        public void Create((string id, string name) selectCategory, (string id, string name) selectSubcategory, int type, string templateName, string pathToFile)
        {
            TemplateTypes enumType = (TemplateTypes)type;

            if (string.IsNullOrEmpty(selectCategory.id))
            {
                Category temp = new Category()
                {
                    Name = selectCategory.name
                };
                _context.Categories.Add(temp);

                selectCategory.id = temp.Id;
            }

            if (string.IsNullOrEmpty(selectSubcategory.id))
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