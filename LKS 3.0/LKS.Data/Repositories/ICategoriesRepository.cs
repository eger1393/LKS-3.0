using LKS.Data.Models;
using System.Collections.Generic;

namespace LKS.Data.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetCategories(string parentId);
    }
}
