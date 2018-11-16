using LKS.Data.Abstract;
using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Concrete
{
	public class PrepodRepository : IPrepodRepository

	{
		private DataContext context;
		public PrepodRepository(DataContext context)
		{
			this.context = context;
		}
		public async Task Create(Prepod item)
		{
			await context.Prepods.AddAsync(item);
			context.SaveChanges();
			//return;
		}

		public async Task CreateRange(ICollection<Prepod> item)
		{
			await context.Prepods.AddRangeAsync(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task Delete(Prepod item)
		{
			context.Prepods.Remove(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task DeleteRange(ICollection<Prepod> item)
		{
			context.Prepods.RemoveRange(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task<Prepod> GetItem(string id)
		{
			var res = await context.Prepods.FindAsync(id);
			return res;
		}

		public IQueryable<Prepod> GetItems()
		{
			return context.Prepods;
		}

		public async Task Update(Prepod item)
		{
			context.Prepods.Update(item);
			await context.SaveChangesAsync();
			return;
		}
	}
}
