using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.DAL.Abstract;
using LKS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    public class AddedStudentController : Controller
    {
		IStudentRepository studentRepository;
		public AddedStudentController(IStudentRepository studentRepository)
		{
			this.studentRepository = studentRepository;
		}
        // GET: AddedStudent/Create
        public ActionResult Create()
        {
            ViewBag.InstGroups = studentRepository.GetItems().Select(u => u.InstGroup).ToList();
            
            return View(); 
        }

        // POST: AddedStudent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(Student student)//IFormCollection collection)
        {
                studentRepository.Create(student);
                return RedirectToAction("Create");
		}

        // GET: AddedStudent/Edit/5
        
    }
}