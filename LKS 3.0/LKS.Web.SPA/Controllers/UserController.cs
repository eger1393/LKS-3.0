using System.Collections.Generic;
using System.Linq;
using LKS.Data.Models;
using LKS.Data.Providers;
using LKS.Data.Repositories;
using LKS.Infrastructure.Authenticate;
using LKS.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LKS.Web.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IJwtAuth _auth;
		private readonly IUserRepository _userRepository;
		private readonly IPasswordProvider _passwordProvider;

		public UserController(IJwtAuth auth, IUserRepository userRepository, IPasswordProvider passwordProvider)
		{
			_auth = auth;
			_userRepository = userRepository;
			_passwordProvider = passwordProvider;
		}

		[HttpPost("[action]")]
		[AllowAnonymous]
		public IActionResult Login([FromBody]LoginModel model)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			User user = _userRepository.GetByLogin(model.Login).Result;
			if (user == null || !_passwordProvider.VerifyHashedPassword(user.Password, model.Login, model.Password))
				return Forbid("Пользователь с данным сочетанием логина/пароля не найден");

			var token = _auth.CreateToken(user);

			return Ok(token);
		}
        [HttpGet("[action]")]
		[Authorize(Roles = "Admin")]
		public IActionResult UpdatePassword([FromQuery] string login)
		{
			User user = _userRepository.GetByLogin(login).Result;
			if (user == null)
				return BadRequest("user not found!");
			string password = _passwordProvider.GetRandomPassword(8);
			user.Password = _passwordProvider.GetHash(password, user.Login);
			_userRepository.Create(user);
			return Ok(new { login = user.Login, password });
		}
        [HttpGet("[action]")]
		[Authorize(Roles = "Admin")]
		public IActionResult GetAllUsers()
		{
			List<User> users = _userRepository.GetAllUsers("User").ToList();
			return Ok(users.Select(x => new
			{
				x.Id,
				x.Login,
				x.Role,
				x.TroopId
			}));
		}
	}
}