using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Models;
using LKS.Data.Repositories;
using LKS.Web.SPA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    [Route("api/[controller]")]
	[Authorize]
	[ApiController]
    public class StudentListController : Controller
    {
		private readonly IStudentRepository _studentRepository;
        public StudentListController(IStudentRepository studentRepository)
		{
			this._studentRepository = studentRepository;
		}

		[HttpPost("[action]")]
		public IActionResult GetStudentListData([FromBody]GetStudentListDataModel model)
		{
			if(User.IsInRole("User"))
			{
				string troopId = User.Claims.FirstOrDefault(x => x.Type == "TroopId")?.Value;
				if (String.IsNullOrEmpty(troopId))
					return BadRequest("Troop number is null");
				// установил номер взвода пользователя( чтобы злобные хацкеры не могли вытянуть данные других взводов)
				model.SelectTroop = troopId;
			}

			var studentList = _studentRepository.GetStudents(model.Filters, model.SelectTroop).Select(ob => new
			{
				ob.Id,
				ob.FirstName,
				ob.LastName,
				ob.MiddleName, 
				ob.Position,
				ob.Kurs,
				ob.TroopId,
				ob.SboryTroopId,
                numTroop = ob.Troop?.NumberTroop,
				ob.Collness,
				ob.Status,//
				ob.Birthday,
				ob.Citizenship,
				ob.ConditionsOfEducation,
				ob.DateOfOrder,
				ob.Faculty,
				ob.FamiliStatys,
				ob.Growth,
				ob.HomePhone,
				ob.InstGroup,
				ob.MobilePhone,
				ob.Nationality,
				ob.NumberOfOrder,
				ob.PlaceBirthday,
				ob.PlaceOfRegestration,
				ob.PlaceOfResidence,
				ob.ProjectOrder,
				ob.Rectal,
				ob.School,
				ob.SpecialityName,
				ob.SpecInst,
				ob.YearOfAddMAI,
				ob.YearOfAddVK,
				ob.YearOfEndMAI,
				ob.YearOfEndVK,
				ob.Initials,

			});
			return new JsonResult(new { studentList = studentList.ToArray() });
		}
        [Authorize(Roles = "Admin")]
		[HttpPost("[action]")]
		public IActionResult SetStudentStatus([FromBody]SetStudentStatusModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
            _studentRepository.SetStudentStatus(model.id, model.status);
			return Ok();
		}
        [Authorize(Roles = "Admin")]
		[HttpPost("[action]")]
		public IActionResult SetStudentPosition([FromBody]SetStudentPositionModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
            _studentRepository.SetStudentPosition(model.id, model.position);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("[action]")]
		public async Task<IActionResult> SetStudentSboryTroop([FromBody]List<Student> students)
		{
			await _studentRepository.UpdateSboryTroopId(students);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("[action]")]
		public async Task<IActionResult> GetStudenAssessments(string troopId)
		{
			return Ok(_studentRepository.GetSboryStudentWithAssessments(troopId).Select(x => new {
				x.Id,
				x.FirstName,
				x.LastName,
				x.MiddleName,
				x.Initials,
				x.AssesmentId,
				x.Assessment
			}));
		}
		[Authorize(Roles = "Admin")]
		[HttpPost("[action]")]
		public async Task<IActionResult> SaveAssessments([FromBody] List<Student> students)
		{
			_studentRepository.SaveAssessments(students);
			return Ok();
		}

	}
}