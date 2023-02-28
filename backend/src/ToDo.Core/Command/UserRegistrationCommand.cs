using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Command
{
	public class UserRegistrationCommand
	{
		[Required(ErrorMessage = "UserName is required")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}
}
