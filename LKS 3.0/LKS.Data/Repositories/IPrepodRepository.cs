using LKS.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LKS.Data.Repositories
{
    public interface IPrepodRepository : IRepository<Prepod>
    {
        Task<string> Create(Prepod item, string login);
        IEnumerable<Prepod> GetItems();
    }
}
