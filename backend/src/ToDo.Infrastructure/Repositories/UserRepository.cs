using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entities;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.EF;

namespace ToDo.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ToDoDbContext _dbContext;

    public UserRepository(ToDoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByNameAsync(string username)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(x => x.Username == username);
    }
}