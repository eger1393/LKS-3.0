using LKS.Data.Abstract;
using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Concrete
{
	public class StudentRepository : IStudentRepository
	{
		private DataContext context;
		public StudentRepository(DataContext context)
		{
			this.context = context;	
		}
		public async Task Create(Student item)
		{
			await context.Students.AddAsync(item);
			context.SaveChanges();
			//return;
		}

		public async Task CreateRange(ICollection<Student> item)
		{
			await context.Students.AddRangeAsync(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task Delete(Student item)
		{
			context.Students.Remove(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task DeleteRange(ICollection<Student> item)
		{
			context.Students.RemoveRange(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task<Student> GetItem(string id)
		{
			var res = await context.Students.FindAsync(id);
			return res;
		}

		public IQueryable<Student> GetItems()
		{
			return context.Students;
		}

		public async Task Update(Student item)
		{
			context.Students.Update(item);
			await context.SaveChangesAsync();
			return;
		}
	}
}
