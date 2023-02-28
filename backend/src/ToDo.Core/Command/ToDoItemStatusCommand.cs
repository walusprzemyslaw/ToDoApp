namespace ToDo.Core.Command;

public class ToDoItemStatusCommand
{
    public int StatusDto { get; set; }
    public Guid ToDoItemId { get; set; }
}