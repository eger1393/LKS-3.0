using LKS.Data.Repositories;
using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
{
	public class RelativeRepository : IRelativeRepository
	{
		private DataContext context;
		public RelativeRepository(DataContext context)
		{
			this.context = context;
		}
		public async Task Create(Relative item)
		{
			await context.Relatives.AddAsync(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task CreateRange(ICollection<Relative> item)
		{
			await context.Relatives.AddRangeAsync(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task Delete(Relative item)
		{
			context.Relatives.Remove(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task DeleteRange(ICollection<Relative> item)
		{
			context.Relatives.RemoveRange(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task<Relative> GetItem(string id)
		{
			var res = await context.Relatives.FindAsync(id);
			return res;
		}

		public IQueryable<Relative> GetItems()
		{
			return context.Relatives;
		}

        public async Task Update(Relative item)
        {
            context.Relatives.Update(item);
            await context.SaveChangesAsync();
            return;
        }
    }
}
