using ToDo.Core.Abstractions;
using ToDo.Core.DTO;
using ToDo.Core.Entities;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.Exceptions;
using ToDo.Infrastructure.Handlers;

namespace ToDo.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenHandler _tokenHandler;
    private readonly IPasswordHandler _passwordHandler;
    public IdentityService(IPasswordHandler passwordHandler, IUserRepository userRepository, ITokenHandler tokenHandler)
    {
        _passwordHandler = passwordHandler;
        _userRepository = userRepository;
        _tokenHandler = tokenHandler;
    }

    public async Task<LoginDto> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByNameAsync(username) ?? throw new InvalidCredentialException($"{username} not exist!");
		var passwordOk = await _passwordHandler.CheckPasswordAsync(password, user.Password);
        if (!passwordOk)
        {
            throw new InvalidCredentialException($"Invalid password!");
        }

        var token = await _tokenHandler.CreateTokenAsync(user);
        return new LoginDto(username, token, user.UserId);
    }

    public async Task RegisterAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByNameAsync(username);
        if (user is not null)
        {
            throw new UsernameInUseException();
        }

        var securedPassword = await _passwordHandler.HashPasswordAsync(password);
        user = new User(username, securedPassword);
        await _userRepository.AddUserAsync(user);
    }
}