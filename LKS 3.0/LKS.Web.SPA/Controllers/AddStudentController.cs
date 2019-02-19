using LKS.Data.Repositories;
using LKS.Web.Helpers;
using LKS.Web.Models;
using LKS.Web.SPA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Web.SPA.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	[ApiController]
	public class AddStudentController : ControllerBase
	{
		private readonly IStudentRepository _stydentRepository;
		private readonly IRelativeRepository _relativeRepository;

		public AddStudentController(IStudentRepository studentRepository, IRelativeRepository relativeRepository)
		{
			this._stydentRepository = studentRepository;
			this._relativeRepository = relativeRepository;
		}


		[HttpPost("[action]")]
		public IActionResult GetInstGroupList()
		{
			var obj = _stydentRepository.GetInstGroupList().Select(ob => new
			{
				label = ob
			});
			return Ok(obj);
		}
		[HttpPost("[action]")]
		public IActionResult GetLanguagesList()
		{
			var obj = _stydentRepository.GetLanguagesList().Select(ob => new
			{
				label = ob
			}).ToList();
			if (obj.Count() == 0)
			{
				obj.Add(new { label = "Английский" });
			}
			return Ok(obj);
		}
		[HttpPost("[action]")]
		public IActionResult GetSpecInstList()
		{
			var obj = _stydentRepository.GetSpecInstList().Select(ob => new
			{
				label = ob
			});
			return Ok(obj);
		}
		[HttpPost("[action]")]
		public IActionResult GetRectalList()
		{
			var obj = _stydentRepository.GetRectalList().Select(ob => new
			{
				label = ob
			});
			return Ok(obj);
		}
		[HttpPost("[action]")]
		public IActionResult GetStudent([FromBody]GetStudentModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var obj = _stydentRepository.GetStudent(model.id);
			return Ok(obj);
		}
		[HttpPost("[action]")]
		public async Task<IActionResult> CreateStudent([FromForm]SaveStudentModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
            if (model.Photo != null)
            {
                if (!string.IsNullOrEmpty(model.Student?.ImagePath))
                    ImageHelper.DeleteImage(model.Student.ImagePath);
                model.Student.ImagePath = await ImageHelper.SaveImageAsync(model.Photo);
            }
            await _stydentRepository.Create(model.Student);
			return Ok();
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> UpdateStudent([FromForm]SaveStudentModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (model.Photo != null)
			{
				if (!string.IsNullOrEmpty(model.Student?.ImagePath))
					ImageHelper.DeleteImage(model.Student.ImagePath);
				model.Student.ImagePath = await ImageHelper.SaveImageAsync(model.Photo);
			}

			await _stydentRepository.Update(model.Student);
			return Ok();
		}
	}
}