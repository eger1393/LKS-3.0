using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LKS.Data.Models;

namespace LKS.Data.Repositories
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> GetByLogin(string login);
		IQueryable<User> GetAllUsers(string role);
	}
}
