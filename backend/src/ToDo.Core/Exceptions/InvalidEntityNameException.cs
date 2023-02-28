namespace ToDo.Core.Exceptions
{
	public sealed class InvalidEntityNameException : CustomException
	{
		public InvalidEntityNameException() : base("Entity name is invalid.")
		{
		}
	}
}
