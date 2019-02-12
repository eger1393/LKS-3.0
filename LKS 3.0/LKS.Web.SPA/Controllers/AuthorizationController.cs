using LKS.Infrastructure.Authenticate;
using LKS.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MassRecruitment.WEB.Controllers
{

	class authmodel
	{
		public string Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
	}

	[Route("api/auth")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		private readonly IJwtAuth _auth;
		private List<authmodel> UserList = new List<authmodel>()
		{
			new authmodel() {Id = "1", Login = "Admin", Password="P@ssw0rd", Role="Admin"},
			new authmodel() {Id = "2", Login = "User", Password = "P@ssw0rd", Role="User"}
		};

		public AuthorizationController(IJwtAuth auth)
		{
			_auth = auth;
		}

		[HttpPost("[action]")]
		[AllowAnonymous]
		public IActionResult Login([FromBody]LoginModel model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			authmodel user = UserList.FirstOrDefault(x=>x.Login == model.Login && x.Password == model.Password);
			if (user == null)
				return Forbid("Пользователь с данным сочетанием логина/пароля не найден");

			var token = _auth.CreateToken(user.Login, user.Role);

			return Ok(token);
		}
	}
}