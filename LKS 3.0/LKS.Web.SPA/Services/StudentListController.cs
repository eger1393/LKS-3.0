using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.SPA.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentListController : ControllerBase
    {
		IStudentRepository stydentRepository;
		public StudentListController(IStudentRepository studentRepository)
		{
			this.stydentRepository = studentRepository;
		}

		[HttpPost("[action]")]
		public  async Task<IActionResult> GetStudents()
		{
			//var data = stydentRepository.GetItems().Take(20).ToList();
			return Ok();//new { data });
		}

    }
}