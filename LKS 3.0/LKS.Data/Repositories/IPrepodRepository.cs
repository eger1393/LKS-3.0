using LKS.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LKS.Data.Repositories
{
    public interface IPrepodRepository : IRepository<Prepod>
    {
        IEnumerable<Prepod> GetItems();
    }
}
