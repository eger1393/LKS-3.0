using LKS.Data.Models;
using System.Collections.Generic;

namespace LKS.Data.Repositories
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> GetItems();
        bool UpdateItems(IEnumerable<Admin> items);
        bool UpdateItem(Admin item);
    }
}
