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
			Troop troop = context.Troops.Include(x => x.Students).FirstOrDefault(x => x.Id == item.Id);
			context.RemoveRange(troop.Students);
			context.Troops.Remove(troop);
			context.SaveChanges();
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
			return await context.Troops
				.Include(ob => ob.Students)
				.Include(ob => ob.Prepod)
				.Include(ob => ob.PlatoonCommander)
				.FirstOrDefaultAsync(ob => ob.Id == id);
		}

		public List<Troop> GetTroops()
		{
			return context.Troops
				.Include(ob => ob.Cycle)
				.Include(ob => ob.Prepod)
				.Include(ob => ob.Students)
				.Include(ob => ob.PlatoonCommander)
				.ToList();
		}

		public Troop GetBuNum(string num)
		{
			return context.Troops
				.Include(ob => ob.Students)
				.Include(ob => ob.Prepod)
				//.Include(ob=>ob.PlatoonCommander)
				.FirstOrDefault(ob => ob.NumberTroop == num);
		}

		public async Task Update(Troop item)
		{
			var troop = context.Troops.FirstOrDefault(x => x.Id == item.Id);
			troop.NumberTroop = item.NumberTroop;
			troop.PrepodId = item.PrepodId;
			troop.CycleId = item.CycleId;
			troop.ArrivalDay = item.ArrivalDay;
			context.SaveChanges();
			return;
		}
    }
}
