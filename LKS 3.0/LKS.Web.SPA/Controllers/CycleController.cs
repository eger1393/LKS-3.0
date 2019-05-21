using System.Linq;
using LKS.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
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