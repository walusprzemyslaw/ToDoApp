using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Handlers
{
	public interface ITokenHandler
	{
		Task<string> CreateTokenAsync(User user);
	}
}
