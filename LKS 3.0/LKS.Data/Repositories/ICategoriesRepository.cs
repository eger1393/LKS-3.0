using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.Data.Repositories
{
    public interface ICategoriesRepository : IRepository<Category>
    {
        List<Category> GetCategories(string parentId);
    }
}
