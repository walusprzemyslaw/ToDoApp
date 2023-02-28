using ToDo.Core.DTO;

namespace ToDo.Core.Abstractions
{
	public interface IToDoItemReadService
	{
		Task<ToDoItemDto> GetToDoItemAsync(Guid itemId);
		Task<IEnumerable<ToDoItemDto>> GetToDoItemsAsync(Guid listId);
		Task<IEnumerable<ToDoItemDto>> GetDueTodayItemsAsync(Guid userId);
		Task<bool> AnyTodayItemsAsync(Guid userId);
	}
}
