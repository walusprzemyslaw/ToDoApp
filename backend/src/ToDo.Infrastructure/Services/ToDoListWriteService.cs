using Mapster;
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Abstractions;
using ToDo.Core.Command;
using ToDo.Core.DTO;
using ToDo.Core.Entities;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.EF;
using ToDo.Infrastructure.Exceptions;

namespace ToDo.Infrastructure.Services
{
	public class ToDoListWriteService : IToDoListWriteService
	{
		private readonly IToDoListRepository _toDoListRepository;
		private readonly ToDoDbContext _dbContext;
		private readonly IClock _clock;

		public ToDoListWriteService(IToDoListRepository toDoListRepository, ToDoDbContext dbContext, IClock clock)
		{
			_toDoListRepository = toDoListRepository;
			_dbContext = dbContext;
			_clock = clock;
		}

		public async Task CreateToDoListAsync(CreateToDoListCommand toDoListDto)
		{
			var toDoList = new ToDoList(toDoListDto.Name, toDoListDto.UserId);
			await _toDoListRepository.CreateToDoListAsync(toDoList);
		}

		public async Task UpdateToDoListAsync(ToDoListUpdateCommand toDoListDto)
		{
			var toDoList = await _dbContext.ToDoLists.FindAsync(toDoListDto.ToDoListId) ?? throw new LackOfToDoListException($"Missing ToDoList.");
			toDoList.SetName(toDoListDto.Name);

			await _toDoListRepository.UpdateToDoListAsync(toDoList);
		}

		public async Task RemoveToDoListAsync(Guid listId)
		{
			var toDoList = await _toDoListRepository.GetToDoListAsync(listId);
			await _toDoListRepository.RemoveToDoListAsync(toDoList);
		}

		public async Task<ToDoListDto> CopyToDoListAsync(Guid listId)
		{
			var toDoList = await _dbContext.ToDoLists.Include(l => l.Items).FirstAsync(l => l.ToDoListId == listId);
			var result = toDoList.Clone(_clock);
			await _toDoListRepository.CreateToDoListAsync(result);
			return result.Adapt<ToDoListDto>();
		}

		public async Task<bool> ChangeVisibilityToDoListAsync(Guid listId)
		{
			var toDoList = await _toDoListRepository.GetToDoListAsync(listId);
			bool visibility = toDoList.ChangeListVisibility();
			await _toDoListRepository.UpdateToDoListAsync(toDoList);
			return visibility;
		}

		public async Task<bool> ChangeVisibilityOfCompletedItemsAsync(Guid listId)
		{
			var toDoList = await _toDoListRepository.GetToDoListAsync(listId);
			bool visibilityOfFinishedItems = toDoList.ChangeVisibilityOfFinishedItems();
			await _toDoListRepository.UpdateToDoListAsync(toDoList);
			return visibilityOfFinishedItems;
		}
	}
}
