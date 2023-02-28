using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Command;

public class CreateToDoListCommand
{
    [Required]
    public string Name { get; set; }
    [Required]
    public Guid UserId { get; set; }
}