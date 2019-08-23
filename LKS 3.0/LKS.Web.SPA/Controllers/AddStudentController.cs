using LKS.Data.Helpers;
using LKS.Data.Repositories;
using LKS.Web.Helpers;
using LKS.Web.Models;
using LKS.Web.SPA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AddStudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRelativeRepository _relativeRepository;

        public AddStudentController(IStudentRepository studentRepository, IRelativeRepository relativeRepository)
        {
            _studentRepository = studentRepository;
            _relativeRepository = relativeRepository;
        }


        [HttpPost("[action]")]
        public IActionResult GetInstGroupList()
        {
            var obj = _studentRepository.GetInstGroupList().Select(ob => new
            {
                label = ob
            });
            return Ok(obj);
        }
        [HttpPost("[action]")]
        public IActionResult GetLanguagesList()
        {
            var obj = _studentRepository.GetLanguagesList().Select(ob => new
            {
                label = ob
            }).ToList();
            if (!obj.Any())
            {
                obj.Add(new { label = "Английский" });
            }
            return Ok(obj);
        }
        [HttpPost("[action]")]
        public IActionResult GetSpecInstList()
        {
            var obj = _studentRepository.GetSpecInstList().Select(ob => new
            {
                label = ob
            });
            return Ok(obj);
        }
        [HttpPost("[action]")]
        public IActionResult GetRectalList()
        {
            var obj = _studentRepository.GetRectalList().Select(ob => new
            {
                label = ob
            });
            return Ok(obj);
        }
        [HttpPost("[action]")]
        public IActionResult GetStudent([FromBody]GetStudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obj = _studentRepository.GetStudent(model.id);
            return Ok(obj);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateStudent([FromForm]SaveStudentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Photo != null)
            {
                if (!string.IsNullOrEmpty(model.Student?.ImagePath))
                {
                    ImageHelper.DeleteImage(model.Student.ImagePath);
                }

                Guard.Argument.IsNotNull(() => model.Student);
                model.Student.ImagePath = await ImageHelper.SaveImageAsync(model.Photo);
            }

            _studentRepository.UpdateStudent(model.Student, model.Relatives);
            return Ok();
        }



    }
}