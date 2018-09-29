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

			return View(model);
        }

		[HttpPost]
		public JsonResult GetStudents([FromBody]Newtonsoft.Json.Linq.JObject data)
		{
			var students = studentRepository.GetItems();
			int page;
			string sort = data.GetValue("sort").ToString(),
				filter = data.GetValue("filter").ToString(),
				filterCol = data.GetValue("filterCol").ToString();
			if (!String.IsNullOrWhiteSpace(filter) && !String.IsNullOrWhiteSpace(filterCol))
			{
				students = FilterStudents(students, filter, filterCol);
			}
			if (Int32.TryParse(data.GetValue("page").ToString(), out page) && sort != null)
			{
				
				students = SortStudents(students, sort);

				students = students.Skip((page - 1) * pageSize).Take(pageSize);
				return Json(new { ok = true, students = students.ToList() });
			}
			return Json(new { ok = false });
		}
		
		private IQueryable<Student> FilterStudents(IQueryable<Student> students, string filterText, string filterColumn)
		{
			filterText = filterText.ToLower();
			filterColumn = filterColumn.ToLower();
			switch (filterColumn)
			{
				case "middlename": return students.Where(ob => ob.MiddleName.ToLower().Contains(filterText));
				case "firstname": return students.Where(ob => ob.FirstName.ToLower().Contains(filterText));
				case "lastname": return students.Where(ob => ob.LastName.ToLower().Contains(filterText));
				case "numtroop": return students.Where(ob => ob.NumTroop.ToLower().Contains(filterText));
				default: return students;
			}
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