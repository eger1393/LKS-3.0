using LKS.Data.Models;
using LKS.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext _context;

        public CategoriesRepository(DataContext context)
        {
            _context = context;
        }

        public Task Create(Category item)
        {
            throw new NotImplementedException();
        }

        public Task CreateRange(ICollection<Category> item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(ICollection<Category> item)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetItem(string id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            var categories = _context.Categories.Include(x => x.Subcategories);

            if (categories == null)
            { return new List<Category>(); }
            else
            { return categories.ToList(); }
        }

        public Task Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}