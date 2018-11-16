using LKS.DAL.Abstract;
using LKS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.DAL.Concrete
{
	public class TroopRepository : ITroopRepository
	{
		private LKSDbContext context;
		public TroopRepository(LKSDbContext context)
		{
			this.context = context;
		}
		public async Task Create(Troop item)
		{
			await context.Troops.AddAsync(item);
			context.SaveChanges();
			//return;
		}

		public async Task CreateRange(ICollection<Troop> item)
		{
			await context.Troops.AddRangeAsync(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task Delete(Troop item)
		{
			context.Troops.Remove(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task DeleteRange(ICollection<Troop> item)
		{
			context.Troops.RemoveRange(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task<Troop> GetItem(string id)
		{
			var res = await context.Troops.FindAsync(id);
			return res;
		}

		public IQueryable<Troop> GetItems()
		{
			return context.Troops;
		}

		public async Task Update(Troop item)
		{
			context.Troops.Update(item);
			await context.SaveChangesAsync();
			return;
		}
	}
}
