using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LKS.Data.Repositories;
using LKS.Infrastructure.Templates;
using LKS.Web.SPA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace LKS.Web.SPA.Controllers
{
    [Route("api/[controller]")]
	[Authorize(Roles = "Admin")]
	[ApiController]
    public class TemplateController : ControllerBase
    {
		private readonly ITroopRepository _troopRepository;
		private readonly IStudentRepository _studentRepository;

		public TemplateController(ITroopRepository troopRepository, IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
			_troopRepository = troopRepository;
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> CreateUniversityLKSTemplate([FromHeader] CreateUniversityTemplateModel model)
		{
			// TODO говнокод, отрефактрить
			
			var student = await _studentRepository.GetItem(model.studentId);
			var students = new List<Data.Models.Student>();
			students.Add(student);
			TemplateProvider t = new TemplateProvider();
			string fileName = string.Empty;
			switch (model.template)
			{
				case "universityAdmissionForm":
					fileName = "ЛКС_Форма_допуска.docx";
					break;
				case "universityCandidateExamen":
					fileName = "Лист_изучения_кандидата_на_призыв.docx";
					break;
				case "universityLKS":
					fileName = "Личная_карточка_студента.docx";
					break;
				default:
					return BadRequest("Неизвестный шаблон");
			}
			var file = await t.CreateTemplate(@"template/" + fileName, Students: students);

			return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);

		}

		[HttpGet("[action]")]
		public async Task<IActionResult> CreateUniversityTemplate([FromHeader] CreateUniversityTemplateModel model)
		{
			// TODO говнокод, отрефактрить
			var troop = await _troopRepository.GetItem(model.troopId);
			var troops = new List<Data.Models.Troop>();
			troops.Add(troop);
			TemplateProvider t = new TemplateProvider();
			string fileName = string.Empty;
			byte[] file = null;
			switch (model.template)
			{
				// доки для взвода
				case "universityStudentList":
					fileName = "Список_взвода.docx";
					break;
				case "universityConditionsEducation":
					fileName = "Условия_обучения_в_вузе.docx";
					break;
				case "universityThematicControl":
					fileName = "Тематический_контроль.docx";
					break;
					//журнал
				case "universityJournalCover":
					fileName = "Журнал_обложка.docx";
					break;
				case "universityJournalFull":
					fileName = "Журнал_целиком.docx";
					break;
				case "universityJournalPenalties": // сейчас нет шаблона
					fileName = "Наряды_взыскания_инструктажи.docx";
					break;
				case "universityJournalAttendance":
					fileName = "Посещаемость.docx";
					break;
				case "universityJournalStudentList":
					fileName = "Список_взвода_для_журнала.docx";
					break;

				case "universityQuestionnaire":
					{
						fileName = "Анкета.docx";
						file = await t.CopyFile(@"template/" + fileName);
						break;
					}
				case "universitySampleQuestionnaire":
					{
						fileName = "Анкета_шабон.docx";
						file = await t.CopyFile(@"template/" + fileName);
						break;
					}
				case "universityCycleStudentList":
					{
						fileName = "Список обучающихся на цикле.docx";
						file = await t.CreateTemplate(@"template/" + fileName, Students: _studentRepository.GetTrainStudents());
						break;
					}
				case "universityDeductionStudentList":
					{
						fileName = "Список студентов на отчисление.docx";
						file = await t.CreateTemplate(@"template/" + fileName, Students: _studentRepository.GetForDeductionsStudents());
						break;
					}
				case "universityExpellendStudentList":
					{
						fileName = "Список отчисленных студентов.docx";
						file = await t.CreateTemplate(@"template/" + fileName, Students: _studentRepository.GetSuspendedStudents());
						break;
					}
				default:
					return BadRequest("Неизвестный шаблон");
			}
			if (file == null)
				file = await t.CreateTemplate(@"template/" + fileName, troops: troops);

			return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);

		}
	}
}