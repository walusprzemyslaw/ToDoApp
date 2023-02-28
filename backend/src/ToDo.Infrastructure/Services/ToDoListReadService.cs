using Mapster;
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Abstractions;
using ToDo.Core.DTO;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.EF;

namespace ToDo.Infrastructure.Services
{
	public class ToDoListReadService : IToDoListReadService
	{
		private readonly ToDoDbContext _toDoDbContext;

		public ToDoListReadService(ToDoDbContext toDoDbContext)
		{
			_toDoDbContext = toDoDbContext;
		}

		public async Task<IEnumerable<ToDoListDto>> GetToDoListsAsync(Guid userId)
		{
			var toDoLists = await _toDoDbContext.ToDoLists.Where(list => list.UserId == userId).ToListAsync();
			return toDoLists.Adapt<IEnumerable<ToDoListDto>>();
		}

		public async Task<ToDoListDto> GetToDoListAsync(Guid toDoListId)
		{
			var toDoList = await _toDoDbContext.ToDoLists.FirstOrDefaultAsync(x => x.ToDoListId == toDoListId);
			return toDoList.Adapt<ToDoListDto>();
		}

	}
}
