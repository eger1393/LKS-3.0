using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.DAL.Abstract;
using LKS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    public class StudentListController : Controller
    {
		private const int pageSize = 2;
		IStudentRepository studentRepository;
		public StudentListController(IStudentRepository studentRepository)
		{
			this.studentRepository = studentRepository;
		}
		
        public IActionResult Index()
        {
			var model = studentRepository.GetItems().ToList();//todo
			ViewBag.StudentsCount = studentRepository.GetItems().Count();

			return View(model);
        }

		[HttpPost]
		public JsonResult GetStudents([FromBody]Newtonsoft.Json.Linq.JObject data)
		{
			int page;
			string sort = data.GetValue("sort").ToString();
			if (Int32.TryParse(data.GetValue("page").ToString(), out page) && sort != null)
			{
				var students = studentRepository.GetItems();
				students = SortStudents(students, sort);

				students = students.Skip((page - 1) * pageSize).Take(pageSize);
				return Json(new { ok = true, students = students.ToList() });
			}
			return Json(new { ok = false });
		}

		private IQueryable<Student> SortStudents(IQueryable<Student> students, string sort)
		{
			sort = sort.ToLower();
			switch (sort)
			{
				case "middlename": return students.OrderBy(ob => ob.MiddleName);
				case "middlenamedesc": return students.OrderByDescending(ob => ob.MiddleName);
				case "firstname": return students.OrderBy(ob => ob.FirstName);
				case "firstnamedesc": return students.OrderByDescending(ob => ob.FirstName);
				case "lastname": return students.OrderBy(ob => ob.LastName);
				case "lastnamedesc": return students.OrderByDescending(ob => ob.LastName);
				case "numtroop": return students.OrderBy(ob => ob.NumTroop);
				case "numtroopdesc": return students.OrderByDescending(ob => ob.NumTroop);
				default: return students.OrderBy(ob => ob.NumTroop);
			}
		}
	}
}