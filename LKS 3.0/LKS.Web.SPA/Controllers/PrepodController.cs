using LKS.Data.Abstract;
using LKS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
				ob.AdditionalInfo,
				ob.Coolness,
				ob.FirstName,
				ob.LastName,
				ob.MiddleName,
				ob.PrepodRank,
				ob.Initials
			}).ToList());
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> GetPrepod(string id)
		{
			if (string.IsNullOrEmpty(id))
				return BadRequest("bad id");
			var ob = await _prepodRepository.GetItem(id);
			return Ok(new
			{
				ob.Id,
				ob.AdditionalInfo,
				ob.Coolness,
				ob.FirstName,
				ob.LastName,
				ob.MiddleName,
				ob.PrepodRank,
				ob.Initials
			});
		}

		[HttpPost("[action]")]
		public IActionResult CreatePrepod(Prepod model)
		{
			_prepodRepository.Create(model);
			return Ok();
		}

		[HttpPost("[action]")]
		public IActionResult UpdatePrepod(Prepod model)
		{
			_prepodRepository.Update(model);
			return Ok();
		}

		[HttpDelete("[action]")]
		public IActionResult DeletePrepod(Prepod model)
		{
			_prepodRepository.Delete(model);
			return Ok();
		}

	}
}