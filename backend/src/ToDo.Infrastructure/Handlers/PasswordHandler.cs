using Microsoft.AspNetCore.Identity;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Handlers
{
	public class PasswordHandler : IPasswordHandler
	{
		private readonly IPasswordHasher<User> _passwordHasher;
		public PasswordHandler(IPasswordHasher<User> passwordHasher)
		{
			_passwordHasher = passwordHasher;
		}

		public Task<bool> CheckPasswordAsync(string password, string securedPassword)
			=> Task.FromResult(_passwordHasher.VerifyHashedPassword(default, securedPassword, password) == PasswordVerificationResult.Success);

		public Task<string> HashPasswordAsync(string password)
			=> Task.FromResult(_passwordHasher.HashPassword(default, password));
	}
}
