using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LKS.Data.Models;

namespace LKS.Infrastructure.Authenticate
{
	
    public class JwtAuth : IJwtAuth
    {
        private readonly string _jwtSecret;
        private readonly int _jwtLifespan;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtAuth(string jwtSecret, int jwtLifespan, string issuer, string audience)
        {
            _jwtSecret = jwtSecret;
            _jwtLifespan = jwtLifespan;
            _issuer = issuer;
            _audience = audience;
        }

        public AuthenticateModel CreateToken(User user)
        {
            //var expirationTime = DateTime.UtcNow.AddSeconds(_jwtLifespan);

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.Login),
				new Claim(ClaimTypes.Role, user.Role),
				new Claim("TroopId", user.TroopId ?? string.Empty)
            };

            var jwt = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.Add(TimeSpan.FromSeconds(_jwtLifespan)),
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret)),
                    SecurityAlgorithms.HmacSha256
                ));

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

			return new AuthenticateModel
			{
				Name = user.Login,
				Token = token,
				Role = user.Role,
				TroopId = user.TroopId
            };
        }
    }
}
