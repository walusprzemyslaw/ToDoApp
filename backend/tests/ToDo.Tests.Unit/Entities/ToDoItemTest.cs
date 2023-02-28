namespace ToDo.Tests.Unit.Entities
{
	[TestFixture]
	public class ToDoItemTests
	{
		private ToDoItem _toDoItem;
		private Mock<IClock> _clockMock;

		[SetUp]
		public void Setup()
		{
			_clockMock = new Mock<IClock>();
			_clockMock.Setup(c => c.CurrentDay()).Returns(new DateTime(2023, 2, 27));
			_toDoItem = ToDoItem.CreateNewToDoItem("Test Item", "Test Description", "Test Notes",
				new DateTime(2023, 3, 1), Guid.NewGuid(), _clockMock.Object);
		}

		[Test]
		public void CreateNewToDoItem_CreatesNewToDoItemWithCorrectValues()
		{
			Assert.AreEqual("Test Item", _toDoItem.Name);
			Assert.AreEqual("Test Description", _toDoItem.Description);
			Assert.AreEqual("Test Notes", _toDoItem.Notes);
			Assert.AreEqual(new DateTime(2023, 3, 1), _toDoItem.DueDate);
			Assert.AreEqual(ToDoStatus.NotStarted, _toDoItem.Status);
		}

		[Test]
		public void CloneToDoItem_CreatesNewToDoItemWithCorrectValuesAndDifferentId()
		{
			var clonedItem = _toDoItem.CloneToDoItem(Guid.NewGuid(), _clockMock.Object);
			Assert.AreEqual(_toDoItem.Name, clonedItem.Name);
			Assert.AreEqual(_toDoItem.Description, clonedItem.Description);
			Assert.AreEqual(_toDoItem.Notes, clonedItem.Notes);
			Assert.AreEqual(_toDoItem.DueDate, clonedItem.DueDate);
			Assert.AreEqual(_toDoItem.Status, clonedItem.Status);
			Assert.AreNotEqual(_toDoItem.ToDoItemId, clonedItem.ToDoItemId);
		}

		[Test]
		public void UpdateToDoItem_UpdatesToDoItemWithNewValues()
		{
			_toDoItem.UpdateToDoItem("Updated Name", "Updated Description", "Updated Notes", new DateTime(2023, 3, 2), _clockMock.Object);
			Assert.AreEqual("Updated Name", _toDoItem.Name);
			Assert.AreEqual("Updated Description", _toDoItem.Description);
			Assert.AreEqual("Updated Notes", _toDoItem.Notes);
			Assert.AreEqual(new DateTime(2023, 3, 2), _toDoItem.DueDate);
		}

		[Test]
		public void ChangeStatus_ChangesStatusToInProgress()
		{
			var newStatus = _toDoItem.ChangeStatus(ToDoStatus.InProgress);
			Assert.AreEqual(ToDoStatus.InProgress, newStatus);
		}

		[Test]
		public void SetDueDate_ThrowsInvalidDueDateExceptionForPastDate()
		{
			Assert.Throws<InvalidDueDateException>(() => _toDoItem.UpdateToDoItem("Invalid Due Date", "Test Description", "Test Notes", new DateTime(2022, 1, 1), _clockMock.Object));
		}

		[Test]
		public void SetName_ThrowsInvalidEntityNameExceptionForNullName()
		{
			Assert.Throws<InvalidEntityNameException>(() => _toDoItem.UpdateToDoItem(null, "Test Description", "Test Notes", new DateTime(2023, 3, 2), _clockMock.Object));
		}

		[Test]
		public void SetName_ThrowsInvalidEntityNameExceptionForEmptyName()
		{
			Assert.Throws<InvalidEntityNameException>(() => _toDoItem.UpdateToDoItem("", "Test Description", "Test Notes", new DateTime(2023, 3, 2), _clockMock.Object));
		}
	}
}