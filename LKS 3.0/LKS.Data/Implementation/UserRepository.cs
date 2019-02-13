using LKS.Data.Models;
using LKS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext context;

		public UserRepository(DataContext context)
		{
			this.context = context;
		}

		public IQueryable<User> GetAllUsers(string role)
		{
			return context.Users.Where(x => x.Role == role);
		}

		public async Task Create(User item)
		{
			if (!String.IsNullOrEmpty(item.Login))
			{
				User user = context.Users.FirstOrDefault(x => x.Login == item.Login);
				if (user != null)
				{
					await Update(item);
					return;
				}
			}
			context.Users.Add(item);
			context.SaveChanges();
			return;
		}

		public async Task CreateRange(ICollection<User> item)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(User item)
		{
			context.Users.Remove(item);
			context.SaveChanges();
			return;
		}

		public async Task DeleteRange(ICollection<User> item)
		{
			throw new NotImplementedException();
		}

		public async Task<User> GetItem(string id)
		{
			return context.Users.FirstOrDefault(x => x.Id == id);
		}

		public async Task<User> GetByLogin(string login)
		{
			return context.Users.FirstOrDefault(x => x.Login == login);
		}

		public async Task Update(User item)
		{
			context.Users.Update(item);
			context.SaveChanges();
			return;
		}
	}
}
