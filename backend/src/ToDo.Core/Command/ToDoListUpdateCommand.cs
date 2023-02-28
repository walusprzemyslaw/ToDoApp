using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Command;

public class ToDoListUpdateCommand
{
    [Required]
    public Guid ToDoListId { get; set; }
    [Required]
    public string Name { get; set; }
}