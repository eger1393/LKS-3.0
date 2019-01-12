﻿using System;
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
		public IActionResult UpdateTroop(Troop model)
		{
			_troopRepository.Update(model);
			return Ok();
		}

		[HttpDelete("[action]")]
		public IActionResult DeleteTroop(Troop model)
		{
			//_troopRepository.Update(model);
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
		public IActionResult GetTroopList()
		{
			return Ok(_troopRepository.GetTroops().Select(x => new
			{
				x.Id,
				x.ArrivalDay,
				x.NumberTroop,
				cycleNumber = x.Cycle.Number,
				prepodInitials = x.Prepod.Initials
			}));
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