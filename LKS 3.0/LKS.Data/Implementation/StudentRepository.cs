using LKS.Data.Abstract;
using LKS.Data.Models;
using Microsoft.EntityFrameworkCore;
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

		public List<Student> GetStudents(Dictionary<string,string> filters)
		{
			var res = context.Students.Include(ob => ob.Troop).AsQueryable();
			if (filters != null)
				filterStudents(filters, ref res);

			return res.ToList();
		}

		public async Task Update(Student item)
		{
			context.Students.Update(item);
			await context.SaveChangesAsync();
			return;
		}

		private void filterStudents(Dictionary<string,string> filters, ref IQueryable<Student> res)
		{
			foreach (var item in filters)
			{
				switch (item.Key)
				{
					case "firstName":
						res = res.Where(ob => ob.FirstName.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase));
						break;
					case "lastName":
						res = res.Where(ob => ob.LastName.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase));
						break;
					case "middleName":
						res = res.Where(ob => ob.MiddleName.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase));
						break;
					case "rank":
						res = res.Where(ob => ob.Rank.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase));
						break;
					case "collness":
						res = res.Where(ob => ob.Collness.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase));
						break;
					case "numTroop":
						res = res.Where(ob => ob.Troop.NumberTroop.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase));
						break;
					case "studentType":
						{
							if ( item.Value != "all"
								 && Enum.TryParse(item.Value, true, out StudentStatus status) 
								 && Enum.IsDefined(typeof(StudentStatus), status)
								)
							{
								res = res.Where(ob => ob.Status == status);
							}
								break;
						}
					default:
						break;
				}
			}
		}
	}
}
