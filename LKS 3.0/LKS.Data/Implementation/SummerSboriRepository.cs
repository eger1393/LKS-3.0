using LKS.Data.Models;
using LKS.Data.Repositories;
using System.Linq;

namespace LKS.Data.Implementation
{
    internal class SummerSboriRepository : ISummerSboriRepository
    {
        private readonly DataContext _context;

        public SummerSboriRepository(DataContext context)
        {
            _context = context;
        }

        public SummerSbori GetItem()
        {
            return _context.Summers.FirstOrDefault();
        }


        public bool UpdateItem(SummerSbori item)
        {
            try
            {
                _context.Summers.Update(item);
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
