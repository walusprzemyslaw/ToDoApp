namespace ToDo.Core.Exceptions
{
	public sealed class ToDoListIdDiscrepacyException : CustomException
	{
		public ToDoListIdDiscrepacyException() : base("Item does not belong to this list.")
		{
		}
	}
}
