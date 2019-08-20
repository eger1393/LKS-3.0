using LKS.Data.Models;
using LKS.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public Task Create(Admin item)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateRange(ICollection<Admin> item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Admin item)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRange(ICollection<Admin> item)
        {
            throw new System.NotImplementedException();
        }

        public List<Admin> GetAdmins()
        {
            return _context.Admins.ToList();
        }

        public Task<Admin> GetItem(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool SetAdmins(List<Admin> admins)
        {
            try
            {
                _context.UpdateRange(admins);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }


        }

        public Task Update(Admin item)
        {
            throw new System.NotImplementedException();
        }
    }
}
