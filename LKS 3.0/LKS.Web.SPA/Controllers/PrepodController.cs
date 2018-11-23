using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrepodController : ControllerBase
    {
		private readonly IPrepodRepository _prepodRepository;

		public PrepodController(IPrepodRepository prepodRepository)
		{
			_prepodRepository = prepodRepository;
		}

		[HttpPost("[action]")]
		public IActionResult GetPrepodList()
		{
			return Ok(_prepodRepository.GetItems().Select(ob => new
			{
				ob.Id,
				ob.Initials
			}).ToList());
		}

	}
}