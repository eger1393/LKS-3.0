using System;
using System.Collections.Generic;
using System.Text;
using LKS.Data.Models;

namespace LKS.Data.Repositories
{
	public interface ICycleRepository : IRepository<Cycle>
	{
        IEnumerable<Cycle> GetItems();
	}
}