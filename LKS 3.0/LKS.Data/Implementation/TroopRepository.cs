using LKS.Data.Abstract;
using LKS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Data.Concrete
{
	public class TroopRepository : ITroopRepository
	{
		private DataContext context;
		public TroopRepository(DataContext context)
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

		public List<Troop> GetTroops()
		{
			return context.Troops.ToList();
		}

		public Troop GetBuNum(string num)
		{
			return context.Troops
				.Include(ob => ob.Students)
				.Include(ob=>ob.Prepod)
				//.Include(ob=>ob.PlatoonCommander)
				.FirstOrDefault(ob => ob.NumberTroop == num);
		}

		public async Task Update(Troop item)
		{
			context.Troops.Update(item);
			await context.SaveChangesAsync();
			return;
		}
	}
}
