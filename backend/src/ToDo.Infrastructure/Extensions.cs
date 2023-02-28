using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Core.Abstractions;
using ToDo.Core.Entities;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.Date;
using ToDo.Infrastructure.Exceptions.Middleware;
using ToDo.Infrastructure.Handlers;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Services;

namespace ToDo.Infrastructure
{
	public static class Extensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddScoped<IToDoItemWriteService, ToDoItemWriteService>()
				.AddScoped<IToDoListWriteService, ToDoListWriteService>()
				.AddScoped<IToDoItemRepository, ToDoItemRepository>()
				.AddScoped<IToDoItemReadService, ToDoItemReadService>()
				.AddScoped<IToDoListReadService, ToDoListReadService>()
				.AddScoped<IToDoListRepository, ToDoListRepository>()
				.AddScoped<IUserRepository, UserRepository>()
				.AddScoped<IIdentityService, IdentityService>()
				.AddScoped<ExceptionMiddleware>()
				.AddScoped<ITokenHandler, TokenHandler>()
				.AddScoped<IPasswordHandler, PasswordHandler>()
				.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>()
				.AddSingleton<IClock, Clock>();

			return services;
		}
	}
}
