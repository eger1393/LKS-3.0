using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using LKS.Web.SPA.Models;
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
			var studentList = _stydentRepository.GetStudents(model.filters).Select(ob => new
			{
				ob.FirstName,
				ob.LastName,
				ob.MiddleName, 
				ob.Rank,
				ob.Kurs,
				ob.NumTroop,
				numbTroop = ob.Troop?.NumberTroop,
				ob.Collness,
				ob.Status,

			});
			return new JsonResult(new { studentList = studentList.ToArray() });
		}

        [HttpPost("[action]")]
        public IActionResult GetInstGroupList()
        {
            return Ok(_stydentRepository.GetInstGroupList());
        }

    }
}