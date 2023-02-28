using ToDo.Core.Entities;

namespace ToDo.Core.Repositories
{
	public interface IUserRepository
	{
		Task AddUserAsync(User user);
		Task<User> GetUserByNameAsync(string username);
	}
}
