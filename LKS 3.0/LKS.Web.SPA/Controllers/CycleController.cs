using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.SPA.Controllers
{
    [Route("api/[controller]")]
	[Authorize]
	[ApiController]
    public class CycleController : ControllerBase
    {
		private readonly ICycleRepository _cycleRepository;

		public CycleController(ICycleRepository cycleRepository)
		{
			_cycleRepository = cycleRepository;
		}

		[HttpPost("[action]")]
		public IActionResult GetCycleList()
		{
			return Ok(_cycleRepository.GetItems().Select(ob => new
			{
				ob.Id,
				ob.Number
			}));
		}
	}
}