using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Models;
using LKS.Data.Repositories;

namespace LKS.Data.Implementation
{
	public class CycleRepository : ICycleRepository

	{
		private readonly DataContext _context;
		public CycleRepository(DataContext context)
		{
			_context = context;
		}
		public async Task Create(Cycle item)
		{
			await _context.Cycles.AddAsync(item);
			_context.SaveChanges();
        }

		public async Task CreateRange(ICollection<Cycle> item)
		{
			await _context.Cycles.AddRangeAsync(item);
			await _context.SaveChangesAsync();
        }

		public async Task Delete(Cycle item)
		{
			_context.Cycles.Remove(item);
			await _context.SaveChangesAsync();
        }

		public async Task DeleteRange(ICollection<Cycle> item)
		{
			_context.Cycles.RemoveRange(item);
			await _context.SaveChangesAsync();
        }

		public async Task<Cycle> GetItem(string id)
		{
			var res = await _context.Cycles.FindAsync(id);
			return res;
		}

		public List<Cycle> GetItems()
		{
			return _context.Cycles.ToList();
		}

        public async Task Update(Cycle item)
		{
			_context.Cycles.Update(item);
			await _context.SaveChangesAsync();
        }
	}
}
