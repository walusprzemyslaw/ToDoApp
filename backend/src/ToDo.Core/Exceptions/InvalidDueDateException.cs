namespace ToDo.Core.Exceptions
{
	public sealed class InvalidDueDateException : CustomException
	{
		public InvalidDueDateException() : base("Due date cannot be lower than today.")
		{
		}
	}
}
