using ToDo.Core.Exceptions;

namespace ToDo.Core.Entities
{
	public class User
	{
		private IEnumerable<ToDoList> _toDoLists = new List<ToDoList>();
		public Guid UserId { get; private set; }
		public string Username { get; private set; }
		public string Password { get; private set; }
		public virtual IEnumerable<ToDoList> ToDoLists
		{
			get => _toDoLists;
			set => _toDoLists = new List<ToDoList>(value);
		}

		public User()
		{
		}

		public User(string username, string password)
		{
			UserId = Guid.NewGuid();
			Username = username ?? throw new CredentialEmptyException("Username can not be empty");
			Password = password ?? throw new CredentialEmptyException("Password can not be empty");
		}
	}
}
