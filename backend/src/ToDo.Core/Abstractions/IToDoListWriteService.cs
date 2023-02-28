using ToDo.Core.Command;
using ToDo.Core.DTO;

namespace ToDo.Core.Abstractions
{
	public interface IToDoListWriteService
	{
		Task CreateToDoListAsync(CreateToDoListCommand toDoListDto);
		Task UpdateToDoListAsync(ToDoListUpdateCommand toDoListDto);
		Task RemoveToDoListAsync(Guid listId);
		Task<ToDoListDto> CopyToDoListAsync(Guid listId);
		Task<bool> ChangeVisibilityToDoListAsync(Guid listId);
		Task<bool> ChangeVisibilityOfCompletedItemsAsync(Guid listId);
	}
}
