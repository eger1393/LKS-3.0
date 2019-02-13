using LKS.Data.Repositories;
using LKS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
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
			Prepod prepod = context.Prepods.Include(x => x.Troops).FirstOrDefault(x => x.Id == item.Id);
			foreach(var troop in prepod?.Troops)
			{
				troop.Prepod = null;
				troop.PrepodId = null;
			}
			context.Prepods.Remove(prepod);
			context.SaveChanges();
			return;
		}

		public async Task DeleteRange(ICollection<Prepod> item)
		{
			context.Prepods.RemoveRange(item);
			context.SaveChanges();
			return;
		}

		public async Task<Prepod> GetItem(string id)
		{
			var res = await context.Prepods.FindAsync(id);
			return res;
		}

		public List<Prepod> GetItems()
		{
			return context.Prepods.ToList();
		}
        public async Task Update(Prepod item)
		{
			context.Prepods.Update(item);
			context.SaveChanges();
			return;
		}
	}
}
