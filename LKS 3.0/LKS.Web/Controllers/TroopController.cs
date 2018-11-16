using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    public class TroopController : Controller
    {
		ITroopRepository troopReposotory;

		public TroopController(ITroopRepository troopRepository)
		{
			this.troopReposotory = troopRepository;
		}
        public IActionResult Create()
        {
            return View();
        }
    }
}