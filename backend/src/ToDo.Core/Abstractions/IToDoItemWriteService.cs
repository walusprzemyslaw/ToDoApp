using ToDo.Core.Command;
using ToDo.Core.DTO;

namespace ToDo.Core.Abstractions
{
	public interface IToDoItemWriteService
	{
		Task<ToDoItemDto> CreateToDoItemAsync(CreateToDoItemCommand toDoItem);
		Task UpdateToDoItemAsync(UpdateToDoItemCommand command);
		Task RemoveToDoItemAsync(Guid itemId);
		Task ChangeToDoStatusAsync(Guid id, int status);
	}
}