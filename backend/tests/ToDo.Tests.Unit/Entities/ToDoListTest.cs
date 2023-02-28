namespace ToDo.Tests.Unit.Entities
{
    [TestFixture]
	public class ToDoListTests
	{
		private Mock<IClock> _clockMock;

		[SetUp]
		public void SetUp()
		{
			_clockMock = new Mock<IClock>();
		}

		[Test]
		public void ToDoList_CreatedWithValidName_SetsProperties()
		{
			// Arrange
			var name = "Test List";
			var userId = Guid.NewGuid();

			// Act
			var toDoList = new ToDoList(name, userId);

			// Assert
			Assert.AreEqual(name, toDoList.Name);
			Assert.IsTrue(toDoList.Visibility);
			Assert.IsFalse(toDoList.HiddenFinishedItems);
			Assert.AreEqual(userId, toDoList.UserId);
			Assert.AreEqual(0, toDoList.Items.Count());
		}

		[Test]
		public void ToDoList_CreatedWithInvalidName_ThrowsException()
		{
			// Arrange
			var name = "   ";
			var userId = Guid.NewGuid();

			// Act & Assert
			Assert.Throws<InvalidEntityNameException>(() => new ToDoList(name, userId));
		}

		[Test]
		public void SetName_ValidName_SetsName()
		{
			// Arrange
			var toDoList = new ToDoList("Test List", Guid.NewGuid());
			var newName = "New Name";

			// Act
			toDoList.SetName(newName);

			// Assert
			Assert.AreEqual(newName, toDoList.Name);
		}

		[Test]
		public void SetName_InvalidName_ThrowsException()
		{
			// Arrange
			var toDoList = new ToDoList("Test List", Guid.NewGuid());
			var invalidName = "  ";

			// Act & Assert
			Assert.Throws<InvalidEntityNameException>(() => toDoList.SetName(invalidName));
		}

		[Test]
		public void Clone_CreatesCopyWithDifferentIdAndName()
		{
			// Arrange
			var toDoList = new ToDoList("Test List", Guid.NewGuid());
			_clockMock.Setup(c => c.CurrentDay()).Returns(DateTime.UtcNow);

			// Act
			var clonedList = toDoList.Clone(_clockMock.Object);

			// Assert
			Assert.AreNotEqual(toDoList.ToDoListId, clonedList.ToDoListId);
			Assert.AreNotEqual(toDoList.Name, clonedList.Name);
			Assert.IsTrue(clonedList.Name.StartsWith(toDoList.Name));
			Assert.AreEqual(toDoList.UserId, clonedList.UserId);
			Assert.AreEqual(toDoList.Items.Count(), clonedList.Items.Count());
		}

		[Test]
		public void Clone_CreatesCopyWithClonedItems()
		{
			// Arrange
			var toDoList = new ToDoList("Test List", Guid.NewGuid());
			var item1 = ToDoItem.CreateNewToDoItem("Test Item 1", "Test Item Description 1", "Test Item Notes 1", DateTime.Today.AddDays(1), toDoList.ToDoListId, _clockMock.Object);
			var item2 = ToDoItem.CreateNewToDoItem("Test Item 2", "Test Item Description 2", "Test Item Notes 2", DateTime.Today.AddDays(2), toDoList.ToDoListId, _clockMock.Object);
			var item3 = ToDoItem.CreateNewToDoItem("Test Item 3", "Test Item Description 3", "Test Item Notes 3", DateTime.Today.AddDays(3), toDoList.ToDoListId, _clockMock.Object);
			toDoList.AssignToDoItem(item1);
			toDoList.AssignToDoItem(item2);
			toDoList.AssignToDoItem(item3);

			// Act
			var clonedToDoList = toDoList.Clone(_clockMock.Object);

			// Assert
			Assert.AreEqual(toDoList.UserId, clonedToDoList.UserId);
			Assert.AreEqual(toDoList.Name + " (Copy)", clonedToDoList.Name);
			Assert.AreEqual(toDoList.Visibility, clonedToDoList.Visibility);
			Assert.AreEqual(toDoList.HiddenFinishedItems, clonedToDoList.HiddenFinishedItems);
			Assert.AreEqual(toDoList.Items.Count(), clonedToDoList.Items.Count());
			for (int i = 0; i < toDoList.Items.Count(); i++)
			{
				Assert.AreEqual(toDoList.Items.ElementAt(i).Name, clonedToDoList.Items.ElementAt(i).Name);
				Assert.AreEqual(toDoList.Items.ElementAt(i).Description, clonedToDoList.Items.ElementAt(i).Description);
				Assert.AreEqual(toDoList.Items.ElementAt(i).Notes, clonedToDoList.Items.ElementAt(i).Notes);
				Assert.AreEqual(toDoList.Items.ElementAt(i).DueDate, clonedToDoList.Items.ElementAt(i).DueDate);
				Assert.AreEqual(toDoList.Items.ElementAt(i).Status, clonedToDoList.Items.ElementAt(i).Status);
			}
		}

		[Test]
		public void ChangeListVisibility_ChangesVisibility()
		{
			// Arrange
			var toDoList = new ToDoList("Test List", Guid.NewGuid());

			// Act
			var visibility1 = toDoList.ChangeListVisibility();
			var visibility2 = toDoList.ChangeListVisibility();

			// Assert
			Assert.IsFalse(visibility1);
			Assert.IsTrue(visibility2);
		}

		[Test]
		public void ChangeVisibilityOfFinishedItems_ChangesVisibility()
		{
			// Arrange
			var toDoList = new ToDoList("Test List", Guid.NewGuid());

			// Act
			var visibility1 = toDoList.ChangeVisibilityOfFinishedItems();
			var visibility2 = toDoList.ChangeVisibilityOfFinishedItems();

			// Assert
			Assert.IsTrue(visibility1);
			Assert.IsFalse(visibility2);
		}
	}
}
