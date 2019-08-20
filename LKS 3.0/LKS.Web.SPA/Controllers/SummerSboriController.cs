using LKS.Data.Models;
using LKS.Data.Repositories;
using LKS.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummerSboriController : ControllerBase
    {
        private readonly ISummerSboriRepository _summerSboriRepository;

        public SummerSboriController(ISummerSboriRepository summerSboriRepository)
        {
            _summerSboriRepository = summerSboriRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetSummerSboriInfo()
        {
            return Ok(_summerSboriRepository.GetItem());
        }

        [HttpGet("[action]")]
        public IActionResult Update(SummerSbori model)
        {
            _summerSboriRepository.UpdateItem(model);
            return Ok();
        }
    }
}