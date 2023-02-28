using ToDo.Core.Entities;
using ToDo.Core.Enums;

namespace ToDo.Core.Repositories
{
	public interface IToDoItemRepository
	{
		Task CreateToDoItemAsync(ToDoItem toDoItem);
		Task<ToDoItem> GetToDoItemAsync(Guid id);
		Task UpdateToDoItemAsync(ToDoItem toDoItem);
		Task RemoveToDoItemAsync(ToDoItem toDoItem);
	}
}
