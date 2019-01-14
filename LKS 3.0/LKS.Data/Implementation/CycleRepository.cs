using LKS.Data.Abstract;
using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Concrete
{
	public class CycleRepository : ICycleRepository

	{
		private DataContext context;
		public CycleRepository(DataContext context)
		{
			this.context = context;
		}
		public async Task Create(Cycle item)
		{
			await context.Cycles.AddAsync(item);
			context.SaveChanges();
			//return;
		}

		public async Task CreateRange(ICollection<Cycle> item)
		{
			await context.Cycles.AddRangeAsync(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task Delete(Cycle item)
		{
			context.Cycles.Remove(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task DeleteRange(ICollection<Cycle> item)
		{
			context.Cycles.RemoveRange(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task<Cycle> GetItem(string id)
		{
			var res = await context.Cycles.FindAsync(id);
			return res;
		}

		public List<Cycle> GetItems()
		{
			return context.Cycles.ToList();
		}

        public async Task Update(Cycle item)
		{
			context.Cycles.Update(item);
			await context.SaveChangesAsync();
			return;
		}
	}
}
