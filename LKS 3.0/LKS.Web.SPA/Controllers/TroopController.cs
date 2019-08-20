using System;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Models;
using LKS.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    [Route("api/[controller]")]
	[Authorize]
	[ApiController]
    public class TroopController : ControllerBase
    {
		private readonly ITroopRepository _troopRepository;

		public TroopController(ITroopRepository troopRepository)
		{
			_troopRepository = troopRepository;
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("[action]")]
		public IActionResult CreateTroop(Troop model)
		{
			_troopRepository.Create(model);
			return Ok();
		}
        [Authorize(Roles = "Admin")]
		[HttpPost("[action]")]
		public IActionResult UpdateTroop(Troop model)
		{
			_troopRepository.Update(model);
			return Ok();
		}
        [Authorize(Roles = "Admin")]
		[HttpDelete("[action]")]
		public IActionResult DeleteTroop(Troop model)
		{
			_troopRepository.Delete(model);
			return Ok();
		}
        [HttpPost("[action]")]
		public IActionResult GetTroopNumberList()
		{
			return Ok(_troopRepository.GetTroops().Select(ob => new
			{
				ob.Id,
				ob.NumberTroop,
                ob.Students
			}));
		}
        [HttpGet("[action]")]
		public async Task<IActionResult> GetTroop(string id)
		{
			var res = await _troopRepository.GetItem(id);
			return Ok( new
			{
				res.NumberTroop,
				res.CycleId,
				res.ArrivalDay,
				res.PrepodId
			});
		}
        [HttpPost("[action]")]
		public async Task<IActionResult> GetTroopList()
		{
			if (User.IsInRole("User"))
			{
				string troopId = User.Claims.FirstOrDefault(x => x.Type == "TroopId")?.Value;
				if (String.IsNullOrEmpty(troopId))
					return BadRequest("Troop number is null");
                var troop = await _troopRepository.GetItem(troopId);

				return Ok(new Troop[] { troop });
			}
			else
			{
				return Ok(_troopRepository.GetTroops().Select(x => new
				{
					x.Id,
					x.ArrivalDay,
					x.NumberTroop,
					cycleNumber = x.Cycle.Number,
					x.CycleId,
					prepodInitials = x.Prepod.Initials,
					x.PrepodId,
					x.IsSboriTroop
				}));
			}
		}
        [HttpGet("[action]")]
		public async Task<IActionResult> GetTroopStudentsListInitial(string troopId)
		{
			var troop = await _troopRepository.GetItem(troopId);

			return Ok(troop.Students?.Select(ob => new
			{
				id = ob.Id,
				initials = ob.Initials
			}));
		}
    }
}