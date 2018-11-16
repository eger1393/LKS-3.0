using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Abstract
{
	public interface IRepository<T>
	{
		Task Create(T item);
		Task CreateRange(ICollection<T> item);
		Task Delete(T item);
		Task DeleteRange(ICollection<T> item);
		Task Update(T item);
		Task<T> GetItem(string id);
	}
}
