using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.Command;

public class UpdateToDoItemCommand
{
    [Required]
    public Guid ToDoItemId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Notes { get; set; }
    public string Description { get; set; }
    [Required]
    public string DueDate { get; set; }
}