using LKS.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class RelativeController : ControllerBase
    {
        private readonly IRelativeRepository _relativeRepository;

        public RelativeController(IRelativeRepository relativeRepository)
        {
            _relativeRepository = relativeRepository;
        }
    }
}