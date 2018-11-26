using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using LKS.Infrastructure.Templates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace LKS.Web.SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
		private readonly ITroopRepository _troopRepository;

		public TemplateController(ITroopRepository troopRepository)
		{
			_troopRepository = troopRepository;
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> CreateTemplate()
		{
			var troop = _troopRepository.GetBuNum("520");
			TemplateProvider t = new TemplateProvider();
			var file = t.CreateTemplate(@"template/test.docx", Students: troop.Students);

			return File(file, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "test.docx");

		}
	}
}