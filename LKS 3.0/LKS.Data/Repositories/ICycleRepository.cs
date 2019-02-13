using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.Data.Repositories
{
	public interface ICycleRepository : IRepository<Cycle>
	{
		List<Cycle> GetItems();
	}
}