using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entities;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.EF;

namespace ToDo.Infrastructure.Repositories
{
	public class ToDoItemRepository : IToDoItemRepository
	{
		private readonly ToDoDbContext _dbContext;

		public ToDoItemRepository(ToDoDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateToDoItemAsync(ToDoItem toDoItem)
		{
			_dbContext.ToDoItems.Add(toDoItem);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<ToDoItem> GetToDoItemAsync(Guid id)
		{
			return await _dbContext.ToDoItems.FirstOrDefaultAsync(t => t.ToDoItemId == id);
		}

		public async Task UpdateToDoItemAsync(ToDoItem toDoItem)
		{
			_dbContext.ToDoItems.Update(toDoItem);
			await _dbContext.SaveChangesAsync();
		}

		public async Task RemoveToDoItemAsync(ToDoItem toDoItem)
		{
			_dbContext.ToDoItems.Remove(toDoItem);
			await _dbContext.SaveChangesAsync();
		}
	}
}
