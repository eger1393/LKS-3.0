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
		private readonly ITemplateProvider _templateProvider;

		public TemplateController(ITroopRepository troopRepository,
			IStudentRepository studentRepository,
			ITemplateRepository templateRepository,
			ICategoriesRepository categoriesRepository,
			IHostingEnvironment appEnvironment,
			ITemplateProvider templateProvider)
		{
			_templateRepository = templateRepository;
			_studentRepository = studentRepository;
			_troopRepository = troopRepository;
			_categoriesRepository = categoriesRepository;
			_appEnvironment = appEnvironment;
			_templateProvider = templateProvider;
		}
		
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
			string fileName = template.Name + ".docx";
			string path = Path.Combine(_appEnvironment.WebRootPath, template.URI);
			if (template.Type != TemplateTypes.singleStudent)
			{
				byte[] file = await _templateProvider.CreateTemplate(path, students, troops);
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
							byte[] file = await _templateProvider.CreateTemplate(path, new List<Student>() { item }, troops);
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
                model.templateName.Replace(" ", "_") + "_" + model.templateName.GetHashCode() + ".docx";

            string path = "/templates/" + uniqueNameTemplate;

            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await model.templateFile.CopyToAsync(fileStream);
            }

            _templateRepository.Create((model.categoryId, model.categoryName), (model.subcategoryId, model.subcategoryName), model.enumType, model.templateName, path.Replace("/", "\\").Remove(0, 1));

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GetCategories(string parentId)
        {
            return Ok(_categoriesRepository.GetCategories(parentId));
        }

        [AllowAnonymous]
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
                    x.Type,
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