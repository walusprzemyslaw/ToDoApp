using ToDo.Core.DTO;

namespace ToDo.Core.Abstractions
{
	public interface IToDoListReadService
	{
		Task<IEnumerable<ToDoListDto>> GetToDoListsAsync(Guid userId);
		Task<ToDoListDto> GetToDoListAsync(Guid toDoListId);
	}
}