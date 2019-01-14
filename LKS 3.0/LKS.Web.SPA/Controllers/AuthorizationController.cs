using LKS.Infrastructure.Authenticate;
using LKS.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MassRecruitment.WEB.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		private readonly IJwtAuth _auth;

		public AuthorizationController(IJwtAuth auth)
		{
			_auth = auth;
		}

		[HttpPost("[action]")]
		[AllowAnonymous]
		public IActionResult Login([FromBody]LoginModel model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			if(model.Login != "Popov" || model.Password != "P@ssw0rd")
				return Forbid("Пользователь с данным сочетанием логина/пароля не найден");
			
			var token = _auth.CreateToken(model.Login);

			return Ok(token);
		}
	}
}