using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Models;
using LKS.Data.Repositories;

namespace LKS.Data.Implementation
{
	public class RelativeRepository : IRelativeRepository
	{
        private readonly DataContext _context;
		public RelativeRepository(DataContext context)
		{
			_context = context;
		}
		public async Task Create(Relative item)
		{
			await _context.Relatives.AddAsync(item);
			await _context.SaveChangesAsync();
        }

		public async Task CreateRange(ICollection<Relative> item)
		{
			await _context.Relatives.AddRangeAsync(item);
			await _context.SaveChangesAsync();
        }

		public async Task Delete(Relative item)
		{
			_context.Relatives.Remove(item);
			await _context.SaveChangesAsync();
        }

		public async Task DeleteRange(ICollection<Relative> item)
		{
			_context.Relatives.RemoveRange(item);
			await _context.SaveChangesAsync();
        }

        public async Task<Relative> GetItem(string id)
        {
            var res = await _context.Relatives.FindAsync(id);
            return res;
        }
        public async Task Update(Relative item)
        {
            _context.Relatives.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
