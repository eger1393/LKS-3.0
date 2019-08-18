using LKS.Data.Models;
using LKS.Data.Models.Enums;
using LKS.Data.Repositories;
using LKS.Infrastructure.Templates;
using LKS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Web.Controllers
{
	[Route("api/[controller]")]
	[Authorize(Roles = "Admin")]
	[ApiController]
	public class TemplateController : ControllerBase
	{
		private readonly ITroopRepository _troopRepository;
		private readonly IStudentRepository _studentRepository;
		private readonly ITemplateRepository _templateRepository;
		private readonly ICategoriesRepository _categoriesRepository;
		private readonly IHostingEnvironment _appEnvironment;

		public TemplateController(ITroopRepository troopRepository,
			IStudentRepository studentRepository,
			ITemplateRepository templateRepository,
			ICategoriesRepository categoriesRepository,
			IHostingEnvironment appEnvironment)
		{
			_templateRepository = templateRepository;
			_studentRepository = studentRepository;
			_troopRepository = troopRepository;
			_categoriesRepository = categoriesRepository;
			_appEnvironment = appEnvironment;
		}

        //[HttpGet("[action]")]
        //      // ReSharper disable once InconsistentNaming

        //      public async Task<IActionResult> CreateUniversityLKSTemplate
        //          ([FromHeader] CreateUniversityTemplateModel model)
        //{
        //	// TODO говнокод, отрефактрить

        //	var student = await _studentRepository.GetItem(model.StudentId);
        //	var students = new List<Data.Models.Student>();
        //	students.Add(student);
        //	TemplateProvider t = new TemplateProvider();
        //	string fileName = string.Empty;
        //	switch (model.Template)
        //	{
        //		case "universityAdmissionForm":
        //			fileName = "ЛКС_Форма_допуска.docx";
        //			break;
        //		case "universityCandidateExamen":
        //			fileName = "Лист_изучения_кандидата_на_призыв.docx";
        //			break;
        //		case "universityLKS":
        //			fileName = "Личная_карточка_студента.docx";
        //			break;
        //		default:
        //			return BadRequest("Неизвестный шаблон");
        //	}
        //	string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "template", fileName);
        //	var file = await t.CreateTemplate(path, students: students);

        //	return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);

        //}
        //      [HttpGet("[action]")]
        //public async Task<IActionResult> CreateUniversityTemplate
        //          ([FromHeader] CreateUniversityTemplateModel model)
        //{
        //	// TODO говнокод, отрефактрить
        //	var troop = await _troopRepository.GetItem(model.TroopId);
        //	var troops = new List<Data.Models.Troop>();
        //	troops.Add(troop);
        //	TemplateProvider t = new TemplateProvider();
        //	string fileName = string.Empty;
        //	string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "template");
        //	byte[] file = null;
        //	switch (model.Template)
        //	{
        //		// доки для взвода
        //		case "universityStudentList":
        //			fileName = "Список_взвода.docx";
        //			break;
        //		case "universityConditionsEducation":
        //			fileName = "Условия_обучения_в_вузе.docx";
        //			break;
        //		case "universityThematicControl":
        //			fileName = "Тематический_контроль.docx";
        //			break;
        //			//журнал
        //		case "universityJournalCover":
        //			fileName = "Журнал_обложка.docx";
        //			break;
        //		case "universityJournalFull":
        //			fileName = "Журнал_целиком.docx";
        //			break;
        //		case "universityJournalPenalties": // сейчас нет шаблона
        //			fileName = "Наряды_взыскания_инструктажи.docx";
        //			break;
        //		case "universityJournalAttendance":
        //			fileName = "Посещаемость.docx";
        //			break;
        //		case "universityJournalStudentList":
        //			fileName = "Список_взвода_для_журнала.docx";
        //			break;

        //		case "universityQuestionnaire":
        //			{
        //				fileName = "Анкета.docx";
        //				file = await t.CopyFile(Path.Combine(path ,fileName));
        //				break;
        //			}
        //		case "universitySampleQuestionnaire":
        //			{
        //				fileName = "Анкета_шабон.docx";
        //				file = await t.CopyFile(Path.Combine(path, fileName));
        //				break;
        //			}
        //		case "universityCycleStudentList":
        //			{
        //				fileName = "Список обучающихся на цикле.docx";
        //				file = await t.CreateTemplate(Path.Combine(path, fileName), students: _studentRepository.GetTrainStudents());
        //				break;
        //			}
        //		case "universityDeductionStudentList":
        //			{
        //				fileName = "Список студентов на отчисление.docx";
        //				file = await t.CreateTemplate(Path.Combine(path, fileName), students: _studentRepository.GetForDeductionsStudents());
        //				break;
        //			}
        //		case "universityExpellendStudentList":
        //			{
        //				fileName = "Список отчисленных студентов.docx";
        //				file = await t.CreateTemplate(Path.Combine(path, fileName), students: _studentRepository.GetSuspendedStudents());
        //				break;
        //			}
        //		default:
        //			return BadRequest("Неизвестный шаблон");
        //	}
        //	if (file == null)
        //		file = await t.CreateTemplate(Path.Combine(path, fileName), troops: troops);

        //	return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);

        //}
        [HttpPost("[action]")]
        public IActionResult SetTemlateData(SetTemplateData model)
        {
            HttpContext.Session.SetString("data", model.json);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CreateTemplate()
        {

			string json = HttpContext.Session.GetString("data");
			CreateTemplateModel model = JsonConvert.DeserializeObject<CreateTemplateModel>(json);
			Template template = await _templateRepository.GetItem(model.templateId);
			List<Troop> troops = _troopRepository.GetTroops().Where(x => model.troopIds.Contains(x.Id)).ToList();
			List<Student> students = _studentRepository.GetStudents(model.studentIds);

			// TODO говнокод, отрефактрить
			TemplateProvider t = new TemplateProvider();
			string fileName = template.Name + ".docx";
			string path = Path.Combine(_appEnvironment.WebRootPath, template.URI);
			if (template.Type != TemplateTypes.manyStudents)
			{
				byte[] file = await t.CreateTemplate(path, students, troops);
				return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", template.Name + ".docx");
			}
			else
			{
				using (var ms = new MemoryStream())
				{
					using (var zipArchive = new ZipArchive(ms, ZipArchiveMode.Create, true))
					{
						foreach (var item in students)
						{
							byte[] file = await t.CreateTemplate(path, new List<Student>() { item }, troops);
							var entry = zipArchive.CreateEntry(fileName.Replace(".", item.MiddleName + "."), CompressionLevel.Fastest);
							using (var entryStream = entry.Open())
							{
								entryStream.Write(file);
							}
						}
					}
					return File(ms.ToArray(), "application/zip", template.Name + ".zip");
				}
			}
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTemplate([FromForm] AddTemplateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string uniqueNameTemplate =
                model.templateName.Replace(" ", "_") + model.templateName.GetHashCode() + ".docx";

            string path = "/templates/" + uniqueNameTemplate;

            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await model.templateFile.CopyToAsync(fileStream);
            }

            _templateRepository.Create((model.categoryId, model.categoryName), (model.subcategoryId, model.subcategoryName), model.enumType, model.templateName, path.Replace("/", "\\").Remove(0, 2));

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetCategories(string parentId)
        {
            return Ok(_categoriesRepository.GetCategories(parentId));
        }

		[HttpGet("[action]")]
		public IActionResult GetTypes()
		{
			return Ok(Enum.GetValues(typeof(TemplateTypes)).OfType<TemplateTypes>().ToList());
		}

		[HttpGet("[action]")]
		public IActionResult GetTemplateList(string subCategoryId)
		{
			return Ok(_templateRepository.GetTemplates(subCategoryId)
				.Select(x => new
				{
					x.Id,
					x.Name,
					Type = x.Type,
					x.CategoryId
				}));

		}

		[HttpDelete("[action]")]
		public IActionResult DeleteTemplate(string id)
		{
			_templateRepository.DeleteTemplate(id);
			return Ok();
		}

	}
}