using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Abstractions;
using ToDo.Core.Command;
using ToDo.Core.DTO;
using ToDo.Infrastructure.Services;

namespace ToDo.Api.Controllers
{
	public class UserController : BaseController
	{
		private readonly IIdentityService _identityService;

		public UserController(IIdentityService identityService)
		{
			_identityService = identityService;
		}
		
		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationCommand registerUserRegistration)
		{
			await _identityService.RegisterAsync(registerUserRegistration.Username, registerUserRegistration.Password);
			return StatusCode(StatusCodes.Status201Created); 
		}

		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<LoginDto>> LoginAsync([FromBody] LoginCommand loginRequest)
		{
			var token = await _identityService.LoginAsync(loginRequest.Username, loginRequest.Password);
			return Ok(token);
		}
	}
}
