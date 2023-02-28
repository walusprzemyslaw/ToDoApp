using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Command;

public class CreateToDoItemCommand
{
    [Required]
    public string Name { get; set; }
    public string Notes { get; set; }
    public string Description { get; set; }
    [Required]
    public string DueDate { get; set; }
    [Required]
    public Guid ToDoListId { get; set; }
}