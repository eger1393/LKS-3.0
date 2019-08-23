using LKS.Data.Models;
using LKS.Data.Repositories;
using System.Linq;

namespace LKS.Data.Implementation
{
    public class SummerSboryRepository : ISummerSboryRepository
    {
        private readonly DataContext _context;

        public SummerSboryRepository(DataContext context)
        {
            _context = context;
        }

        public SummerSbory GetItem()
        {
            return _context.Summers.FirstOrDefault();
        }


        public bool UpdateItem(SummerSbory item)
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
