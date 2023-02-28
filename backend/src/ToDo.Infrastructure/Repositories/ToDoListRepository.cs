using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entities;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.EF;

namespace ToDo.Infrastructure.Repositories
{
	public class ToDoListRepository : IToDoListRepository
	{
		private readonly ToDoDbContext _dbContext;

		public ToDoListRepository(ToDoDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateToDoListAsync(ToDoList toDoList)
		{
			await _dbContext.ToDoLists.AddAsync(toDoList);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<ToDoList> GetToDoListAsync(Guid id)
		{
			return await _dbContext.ToDoLists.FindAsync(id);
		}

		public async Task<IEnumerable<ToDoList>> GetToDoListsAsync()
		{
			return await _dbContext.ToDoLists.ToListAsync();
		}

		public async Task UpdateToDoListAsync(ToDoList toDoList)
		{
			_dbContext.ToDoLists.Update(toDoList);
			await _dbContext.SaveChangesAsync();
		}

		public async Task RemoveToDoListAsync(ToDoList toDoList)
		{
			_dbContext.ToDoLists.Remove(toDoList);
			await _dbContext.SaveChangesAsync();
		}
	}
}
