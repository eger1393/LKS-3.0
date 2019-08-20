using LKS.Data.Repositories;
using LKS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LKS.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAdminList()
        {
            return Ok(_adminRepository.GetAdmins().Select(x => new
            {
                x.Id,
                x.Command,
                x.Collness,
                x.MiddleName,
                x.FirstName,
                x.LastName,
                x.Rank
            }));
        }

        [HttpGet("[action]")]
        public IActionResult SetAdminList(SetAdminListModel model)
        {
            _adminRepository.SetAdmins(model.Admins);
            return Ok();
        }
    }
}