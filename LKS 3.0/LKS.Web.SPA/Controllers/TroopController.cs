using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using LKS.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TroopController : ControllerBase
    {
		private readonly ITroopRepository _troopRepository;

		public TroopController(ITroopRepository troopRepository)
		{
			_troopRepository = troopRepository;
		}
    
        [HttpPost("[action]")]
		public IActionResult CreateTroop(Troop model)
		{
			_troopRepository.Create(model);
			return Ok();
		}

		[HttpPost("[action]")]
		public IActionResult GetTroopList()
		{
			return Ok(_troopRepository.GetTroops().Select(ob => new
			{
				ob.Id,
				ob.NumberTroop
			}));
		}
    }
}