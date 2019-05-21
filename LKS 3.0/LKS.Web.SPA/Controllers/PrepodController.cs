using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LKS.Data.Models;
using LKS.Data.Repositories;
using LKS.Web.Models;

namespace LKS.Web.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
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
		[Authorize(Roles = "Admin")]
		public IActionResult CreatePrepod(PrepodModel model)
		{
			_prepodRepository.Create(new Prepod {
                Id = model.Id,
                AdditionalInfo = model.AdditionalInfo,
                Coolness = model.Coolness,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                PrepodRank = model.PrepodRank
            }, model.Login);
			return Ok();
		}

		[HttpPost("[action]")]
		[Authorize(Roles = "Admin")]
		public IActionResult UpdatePrepod(Prepod model)
		{
			_prepodRepository.Update(model);
			return Ok();
		}

		[HttpDelete("[action]")]
		[Authorize(Roles = "Admin")]
		public IActionResult DeletePrepod(Prepod model)
		{
			_prepodRepository.Delete(model);
			return Ok();
		}

	}
}