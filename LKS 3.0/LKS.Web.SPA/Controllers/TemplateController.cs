using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LKS.Data.Repositories;
using LKS.Infrastructure.Templates;
using LKS.Web.Models;
using LKS.Web.SPA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
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
        // ReSharper disable once InconsistentNaming

        public async Task<IActionResult> CreateUniversityLKSTemplate
            ([FromHeader] CreateUniversityTemplateModel model)
		{
			// TODO говнокод, отрефактрить
			
			var student = await _studentRepository.GetItem(model.StudentId);
			var students = new List<Data.Models.Student>();
			students.Add(student);
			TemplateProvider t = new TemplateProvider();
			string fileName = string.Empty;
			switch (model.Template)
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
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "template", fileName);
			var file = await t.CreateTemplate(path, students: students);

			return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);

		}
        [HttpGet("[action]")]
		public async Task<IActionResult> CreateUniversityTemplate
            ([FromHeader] CreateUniversityTemplateModel model)
		{
			// TODO говнокод, отрефактрить
			var troop = await _troopRepository.GetItem(model.TroopId);
			var troops = new List<Data.Models.Troop>();
			troops.Add(troop);
			TemplateProvider t = new TemplateProvider();
			string fileName = string.Empty;
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "template");
			byte[] file = null;
			switch (model.Template)
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
						file = await t.CopyFile(Path.Combine(path ,fileName));
						break;
					}
				case "universitySampleQuestionnaire":
					{
						fileName = "Анкета_шабон.docx";
						file = await t.CopyFile(Path.Combine(path, fileName));
						break;
					}
				case "universityCycleStudentList":
					{
						fileName = "Список обучающихся на цикле.docx";
						file = await t.CreateTemplate(Path.Combine(path, fileName), students: _studentRepository.GetTrainStudents());
						break;
					}
				case "universityDeductionStudentList":
					{
						fileName = "Список студентов на отчисление.docx";
						file = await t.CreateTemplate(Path.Combine(path, fileName), students: _studentRepository.GetForDeductionsStudents());
						break;
					}
				case "universityExpellendStudentList":
					{
						fileName = "Список отчисленных студентов.docx";
						file = await t.CreateTemplate(Path.Combine(path, fileName), students: _studentRepository.GetSuspendedStudents());
						break;
					}
				default:
					return BadRequest("Неизвестный шаблон");
			}
			if (file == null)
				file = await t.CreateTemplate(Path.Combine(path, fileName), troops: troops);

			return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);

		}
	}
}