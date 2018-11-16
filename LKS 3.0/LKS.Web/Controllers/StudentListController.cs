using LKS.Data.Abstract;
using LKS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace LKS.Web.Controllers
{
	public class StudentListController : Controller
	{
		//private const int pageSize = 20;
		//IStudentRepository studentRepository;
		//ICycleRepository cycleRepository;
		//public StudentListController(IStudentRepository studentRepository, ICycleRepository cycleRepository)
		//{
		//	this.cycleRepository = cycleRepository;
		//	this.studentRepository = studentRepository;
		//}

		//public IActionResult Index()
		//{
		//	//var model = studentRepository.GetItems().ToList();//todo
		//	//ViewBag.pageSize = pageSize;
		//	//return View(model);
		//}

		//[HttpPost]
		//public JsonResult GetStudents([FromBody]Newtonsoft.Json.Linq.JObject data)
		//{
		//	//var students = studentRepository.GetItems().Include(ob => ob.Troop).ThenInclude(ob => ob.Cycle).AsQueryable();
		//	//int page;
		//	//string sort = data.GetValue("sort")?.ToString(),
		//	//	filter = data.GetValue("filter")?.ToString(),
		//	//	filterCol = data.GetValue("filterCol")?.ToString(),
		//	//	cycle = data.GetValue("selectCycle")?.ToString(),
		//	//	troop = data.GetValue("selectTroop")?.ToString();
		//	//if(!String.IsNullOrWhiteSpace(cycle) && cycle != "#")
		//	//{
		//	//	students = students.Where(ob => ob.Troop.Cycle.Number == cycle);
		//	//}
		//	//if (!String.IsNullOrWhiteSpace(troop))
		//	//{
		//	//	students = students.Where(ob => ob.Troop.NumberTroop == troop);
		//	//}
		//	//if (!String.IsNullOrWhiteSpace(filter) && !String.IsNullOrWhiteSpace(filterCol))
		//	//{
		//	//	students = FilterStudents(students, filter, filterCol);
		//	//}
		//	//if (Int32.TryParse(data.GetValue("page").ToString(), out page) && sort != null)
		//	//{

		//	//	students = SortStudents(students, sort);
		//	//	int count = students.Count();
		//	//	students = students.Skip((page - 1) * pageSize).Take(pageSize);
		//	//	return Json(new
		//	//	{
		//	//		ok = true,
		//	//		count,
		//	//		students = students.ToList()
		//	//	});
		//	//}
		//	//return Json(new { ok = false });
		//}

		
		//public JsonResult GetCycle(string cycleId = null)
		//{
		//	//if (cycleId == null || cycleId == "#")
		//	//{
		//	//	return Json(cycleRepository.GetItems().Select(p => new
		//	//	{
		//	//		id = "cycle-" + p.Id,
		//	//		parent = "#",
		//	//		text = p.Number,
		//	//		children = true,
		//	//	}));
		//	//}
		//	//else
		//	//{
		//	//	string correctCycleId = cycleId.Replace("cycle-", "");
		//	//	return Json(cycleRepository.GetItems().Include(ob => ob.Troops).FirstOrDefault(ob => ob.Id == correctCycleId)?.Troops.Select(p => new
		//	//	{
		//	//		id = "trop-" + p.Id,
		//	//		parent = cycleId,
		//	//		text = p.NumberTroop,
		//	//		children = false,
		//	//	}));
		//	//}
		//}

		//private IQueryable<Student> FilterStudents(IQueryable<Student> students, string filterText, string filterColumn)
		//{
		//	filterText = filterText.ToLower();
		//	filterColumn = filterColumn.ToLower();
		//	switch (filterColumn)
		//	{
		//		case "middlename": return students.Where(ob => ob.MiddleName.ToLower().Contains(filterText));
		//		case "firstname": return students.Where(ob => ob.FirstName.ToLower().Contains(filterText));
		//		case "lastname": return students.Where(ob => ob.LastName.ToLower().Contains(filterText));
		//		case "numtroop": return students.Where(ob => ob.Troop.NumberTroop.ToLower().Contains(filterText));
		//		default: return students;
		//	}
		//}
		//private IQueryable<Student> SortStudents(IQueryable<Student> students, string sort)
		//{
		//	sort = sort.ToLower();
		//	switch (sort)
		//	{
		//		case "middlename": return students.OrderBy(ob => ob.MiddleName);
		//		case "middlenamedesc": return students.OrderByDescending(ob => ob.MiddleName);
		//		case "firstname": return students.OrderBy(ob => ob.FirstName);
		//		case "firstnamedesc": return students.OrderByDescending(ob => ob.FirstName);
		//		case "lastname": return students.OrderBy(ob => ob.LastName);
		//		case "lastnamedesc": return students.OrderByDescending(ob => ob.LastName);
		//		case "numtroop": return students.OrderBy(ob => ob.NumTroop);
		//		case "numtroopdesc": return students.OrderByDescending(ob => ob.NumTroop);
		//		default: return students.OrderBy(ob => ob.NumTroop);
		//	}
		//}

		//public OkResult createStudents()
		//{
		//	var troops = cycleRepository.GetItems().Include(ob => ob.Troops).FirstOrDefault()?.Troops;
		//	System.Collections.Generic.List<Student> students = new System.Collections.Generic.List<Student>();
		//	for(int i = 0; i < 10000; i++)
		//	{
		//		students.Add(new Student
		//		{
		//			FirstName = "fName" + i,
		//			LastName = "lName" + i,
		//			MiddleName = "mName" + i,
		//			TroopId = "1"
		//		});
		//	}
		//	studentRepository.CreateRange(students);
		//	return new OkResult();
		//}
	}
}
