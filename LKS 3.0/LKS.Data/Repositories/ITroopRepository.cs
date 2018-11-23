using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.Data.Abstract
{
	public interface ITroopRepository : IRepository<Troop>
	{
		List<Troop> GetTroops();
	}
}
