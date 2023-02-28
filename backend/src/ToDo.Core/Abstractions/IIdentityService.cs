using ToDo.Core.DTO;

namespace ToDo.Core.Abstractions;

public interface IIdentityService
{
    Task<LoginDto> LoginAsync(string username, string password);
    Task RegisterAsync(string username, string password);
}