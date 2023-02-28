using Mapster;
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Abstractions;
using ToDo.Core.DTO;
using ToDo.Core.Entities;
using ToDo.Core.Enums;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.EF;

namespace ToDo.Infrastructure.Services
{
	public class ToDoItemReadService : IToDoItemReadService
	{
		private readonly IToDoItemRepository _toDoItemRepository;
		private readonly ToDoDbContext _toDoDbContext;
		private readonly IClock _clock;

		public ToDoItemReadService(IToDoItemRepository toDoItemRepository, ToDoDbContext toDoDbContext, IClock clock)
		{
			_toDoItemRepository = toDoItemRepository;
			_toDoDbContext = toDoDbContext;
			_clock = clock;
		}

		public async Task<IEnumerable<ToDoItemDto>> GetToDoItemsAsync(Guid listId)
		{
			var todoItems = await _toDoDbContext.ToDoItems.Where(x => x.ToDoListId == listId).ToListAsync();
			return todoItems.Adapt<IEnumerable<ToDoItemDto>>();
		}
		
		public Task<IEnumerable<ToDoItemDto>> GetDueTodayItemsAsync(Guid userId)
		{
			var currentDate = _clock.CurrentDay();
			var toDoLists =  _toDoDbContext.ToDoLists.Include(o => o.Items)
				.Where(list => list.UserId == userId)
				.Where(list => list.Items.Any(item => item.DueDate == currentDate && item.Status != ToDoStatus.Completed))
				.Select(list => list.ToDoListId);

			IQueryable<ToDoItem> toDoItems = _toDoDbContext.ToDoItems
				.Where(item => item.DueDate == currentDate
								&& item.Status != ToDoStatus.Completed
								&& toDoLists.Contains(item.ToDoListId));
			
			return Task.FromResult(toDoItems.Adapt<IEnumerable<ToDoItemDto>>());
		}

		public async Task<bool> AnyTodayItemsAsync(Guid userId)
		{
			var currentDate = _clock.CurrentDay();
			var result =  await _toDoDbContext.ToDoLists
				.Include(o => o.Items)
				.Where(list => list.UserId == userId)
				.Where(list => list.Items.Any(item => item.DueDate == currentDate && item.Status != ToDoStatus.Completed))
				.AnyAsync();
			return result;
		}

		public async Task<ToDoItemDto> GetToDoItemAsync(Guid itemId)
		{
			var toDoItem = await _toDoItemRepository.GetToDoItemAsync(itemId);
			return toDoItem.Adapt<ToDoItemDto>();
		}
	}
}
