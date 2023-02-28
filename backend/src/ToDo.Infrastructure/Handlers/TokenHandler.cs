using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Handlers
{
	public class TokenHandler : ITokenHandler
	{
		private readonly IConfiguration _configuration;
		public TokenHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public Task<string> CreateTokenAsync(User user)
		{
			List<Claim> claims = new();
			claims.Add(new Claim(ClaimTypes.GivenName, user.Username));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Key"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				_configuration["jwt:Issuer"],
				_configuration["jwt:Audience"],
				claims,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: credentials);

			return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
		}
	}
}
