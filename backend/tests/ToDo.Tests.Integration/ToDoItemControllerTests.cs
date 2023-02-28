using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Abstractions;
using ToDo.Core.Entities;
using ToDo.Infrastructure.EF;
using ToDo.Infrastructure.Handlers;
using ToDo.Infrastructure.Repositories;
using ToDo.Infrastructure.Services;
using Microsoft.Extensions.Configuration;

namespace ToDo.Tests.Integration
{
	[TestFixture]
	public class ToDoItemControllerTests
	{
		private DbContextOptions<ToDoDbContext> _options;
		private ToDoDbContext _dbContext;
		private IdentityService _identityService;
		private Mock<IClock> _clockMock;
		private Mock<IPasswordHasher<User>> _passwordHasher;
		private Mock<IConfiguration> _configuration;

		[SetUp]
		public void SetUp()
		{
			_clockMock.Setup(c => c.CurrentDay()).Returns(new DateTime(2023, 2, 27));
			_options = new DbContextOptionsBuilder<ToDoDbContext>()
				.UseInMemoryDatabase(databaseName: "test_db")
				.Options;

			_dbContext = new ToDoDbContext(_options, _clockMock.Object);
			_identityService = new IdentityService(new PasswordHandler(_passwordHasher.Object), new UserRepository(_dbContext), new TokenHandler(_configuration.Object));
		}

		[Test]
		public async Task LoginAsync_WithValidCredentials_ReturnsLoginDto()
		{
			// Arrange
			var user = new User("test_user", "hashed_password");
			_dbContext.Users.Add(user);
			await _dbContext.SaveChangesAsync();

			// Act
			var result = await _identityService.LoginAsync("test_user", "password");

			// Assert
			Assert.NotNull(result);
			Assert.AreEqual("test_user", result.UserName);
			Assert.IsNotNull(result.Token);
			Assert.AreEqual(user.UserId, result.UserId);
		}

		[TearDown]
		public void TearDown()
		{
			_dbContext.Database.EnsureDeleted();
			_dbContext.Dispose();
		}
	}
}
