using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Abstract;
using LKS.Web.SPA.Models;
using LKS.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.SPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddStudentController : ControllerBase
    {
        private readonly IStudentRepository _stydentRepository;

        public AddStudentController(IStudentRepository studentRepository)
        {
            this._stydentRepository = studentRepository;
        }

       
        [HttpPost("[action]")]
        public IActionResult GetInstGroupList()
        {
            var obj = _stydentRepository.GetInstGroupList().Select(ob => new
            {
                label = ob
            });
            return Ok(obj);
        }
        [HttpPost("[action]")]
        public IActionResult GetSpecInstList()
        {
            var obj = _stydentRepository.GetSpecInstList().Select(ob => new
            {
                label = ob
            });
            return Ok(obj);
        }
        [HttpPost("[action]")]
        public IActionResult GetRectalList()
        {
            var obj = _stydentRepository.GetRectalList().Select(ob => new
            {
                label = ob
            });
            return Ok(obj);
        }
        [HttpPost("[action]")]
        public IActionResult CreateStudent([FromBody]Student model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _stydentRepository.Create(model);
            return Ok();
        }
    }
}