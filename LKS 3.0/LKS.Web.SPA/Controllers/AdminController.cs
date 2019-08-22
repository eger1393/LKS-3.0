using LKS.Data.Repositories;
using LKS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LKS.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAdminList()
        {
            return Ok(_adminRepository.GetItems().Select(x => new
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

        [HttpPost("[action]")]
        public IActionResult SetAdminList(SetAdminListModel model)
        {
            _adminRepository.UpdateItems(model.admins);
            return Ok();
        }
    }
}