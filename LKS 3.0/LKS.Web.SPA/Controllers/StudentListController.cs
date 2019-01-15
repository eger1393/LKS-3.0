using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using LKS.Web.SPA.Models;
using LKS.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentListController : Controller
    {
		private readonly IStudentRepository _stydentRepository;

		public StudentListController(IStudentRepository studentRepository)
		{
			this._stydentRepository = studentRepository;
		}

		[HttpPost("[action]")]
		public IActionResult GetStudentListData([FromBody]GetStudentListDataModel model)
		{
			var studentList = _stydentRepository.GetStudents(model.Filters, model.SelectTroop).Select(ob => new
			{
				ob.Id,
				ob.FirstName,
				ob.LastName,
				ob.MiddleName, 
				ob.Position,
				ob.Kurs,
				ob.NumTroop,
				numbTroop = ob.Troop?.NumberTroop,
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

			});
			return new JsonResult(new { studentList = studentList.ToArray() });
		}

        [HttpPost("[action]")]
        public IActionResult GetInstGroupList()
        {
            var obj = _stydentRepository.GetInstGroupList().Select(ob => new
            {
                label = ob
            });//.ToDictionary<string, string>(ob => ob, ob => ob);
            return Ok(obj);
        }

    
		[HttpPost("[action]")]
		public IActionResult SetStudentStatus([FromBody]SetStudentStatusModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			_stydentRepository.SetStudentStatus(model.id, model.status);
			return Ok();
		}

		[HttpPost("[action]")]
		public IActionResult SetStudentPosition([FromBody]SetStudentPositionModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			_stydentRepository.SetStudentPosition(model.id, model.position);
			return Ok();
		}

        [HttpPost("[action]")]
        public IActionResult CreateStudent([FromBody]Student model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _stydentRepository.Create(model);
            return Ok();
        }

    }
}