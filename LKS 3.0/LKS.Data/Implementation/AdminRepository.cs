using LKS.Data.Models;
using LKS.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LKS.Data.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Admin> GetItems()
        {
            return _context.Admins.ToList();
        }

        public bool UpdateItems(IEnumerable<Admin> items)
        {
            try
            {
                _context.UpdateRange(items);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool UpdateItem(Admin item)
        {
            try
            {
                _context.Update(item);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
