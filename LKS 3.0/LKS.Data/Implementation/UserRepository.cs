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
		private readonly DataContext _context;

		public UserRepository(DataContext context)
		{
			_context = context;
		}

		public IQueryable<User> GetAllUsers(string role)
		{
			return _context.Users.Where(x => x.Role == role);
		}

		public async Task Create(User item)
		{
			if (!string.IsNullOrEmpty(item.Login))
			{
				var user = _context.Users.FirstOrDefault(x => x.Login == item.Login);
				if (user != null)
				{
					await Update(item);
					return;
				}
			}
			_context.Users.Add(item);
			_context.SaveChanges();
        }

		public async Task CreateRange(ICollection<User> item)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(User item)
		{
			_context.Users.Remove(item);
            await _context.SaveChangesAsync();
        }

		public async Task DeleteRange(ICollection<User> item)
		{
			throw new NotImplementedException();
		}

		public async Task<User> GetItem(string id)
		{
			return _context.Users.FirstOrDefault(x => x.Id == id);
		}

		public async Task<User> GetByLogin(string login)
		{
			return _context.Users.FirstOrDefault(x => x.Login == login);
		}

		public async Task Update(User item)
		{
			_context.Users.Update(item);
            await _context.SaveChangesAsync();
        }
	}
}
