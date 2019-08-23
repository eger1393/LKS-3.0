using LKS.Data.Models;
using LKS.Data.Repositories;
using LKS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class SummerSboryController : ControllerBase
    {
        private readonly ISummerSboryRepository _summerSboryRepository;

        public SummerSboryController(ISummerSboryRepository summerSboryRepository)
        {
            _summerSboryRepository = summerSboryRepository;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult GetSummerSboryInfo()
        {
            return Ok(_summerSboryRepository.GetItem());
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult SetSummerSboryInfo([FromBody]SummerSbory model)
        {
            _summerSboryRepository.UpdateItem(model);
            return Ok();
        }
    }
}