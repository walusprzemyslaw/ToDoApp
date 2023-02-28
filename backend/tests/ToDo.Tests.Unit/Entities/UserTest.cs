namespace ToDo.Tests.Unit.Entities
{
	[TestFixture]
	public class UserTests
	{
		[Test]
		public void Constructor_WithValidCredentials_SetsProperties()
		{
			// Arrange
			var username = "testuser";
			var password = "testpassword";

			// Act
			var user = new User(username, password);

			// Assert
			Assert.IsNotNull(user.UserId);
			Assert.AreEqual(username, user.Username);
			Assert.AreEqual(password, user.Password);
		}

		[Test]
		public void Constructor_WithNullUsername_ThrowsException()
		{
			// Arrange
			var password = "testpassword";

			// Act and Assert
			Assert.Throws<CredentialEmptyException>(() => new User(null, password));
		}

		[Test]
		public void Constructor_WithNullPassword_ThrowsException()
		{
			// Arrange
			var username = "testuser";

			// Act and Assert
			Assert.Throws<CredentialEmptyException>(() => new User(username, null));
		}
	}
}
