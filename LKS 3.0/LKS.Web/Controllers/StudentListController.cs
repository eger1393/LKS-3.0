using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.DAL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    public class StudentListController : Controller
    {
		IStudentRepository studentRepository;
		public StudentListController(IStudentRepository studentRepository)
		{
			this.studentRepository = studentRepository;
		}
		
        public IActionResult Index()
        {
			var model = studentRepository.GetItems().ToList();
            return View(model);
        }

		[HttpPost]
		public JsonResult GetStudents([FromBody]Newtonsoft.Json.Linq.JObject data)
		{
			const int pageSize = 2;
			int page;
			if(Int32.TryParse(data.GetValue("page").ToString(),out page))
			{
				var students = studentRepository.GetItems().Skip((page - 1) * pageSize).Take(pageSize).ToList();
				return Json(new { ok = true, students = students });
			}
			return Json(new { ok = true });
		}
	}
}