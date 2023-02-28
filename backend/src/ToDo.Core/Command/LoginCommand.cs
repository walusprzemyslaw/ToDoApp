using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Command;

public class LoginCommand
{
    [Required(ErrorMessage = "UserName is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}