using ToDo.Core.Entities;

namespace ToDo.Core.Repositories
{
	public interface IToDoListRepository
	{
		Task CreateToDoListAsync(ToDoList toDoList);
		Task<ToDoList> GetToDoListAsync(Guid id);
		Task UpdateToDoListAsync(ToDoList toDoList);
		Task RemoveToDoListAsync(ToDoList toDoList);
	}
}
