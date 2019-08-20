using LKS.Data.Models;
using System.Collections.Generic;

namespace LKS.Data.Repositories
{
    public interface IAdminRepository : IRepository<Admin>
    {
        List<Admin> GetAdmins();
        bool SetAdmins(List<Admin> admins);
    }
}
