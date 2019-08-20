using LKS.Data.Models;
using LKS.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LKS.Data.Implementation
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext _context;

        public CategoriesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories(string parentId)
        {
            return _context.Categories.Where(x => x.ParentCategoryId == parentId).ToList();
        }
    }
}