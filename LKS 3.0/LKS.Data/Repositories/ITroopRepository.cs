using LKS.Data.Repositories;
using LKS.Data.Models;
using LKS.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LKS.Data.Repositories
{
	public interface ITroopRepository : IRepository<Troop>
	{
		List<Troop> GetTroops();
		Troop GetBuNum(string num);


	}
}
