namespace ToDo.Core.Exceptions
{
	public sealed class ItemEmptyException : CustomException
	{
		public ItemEmptyException() : base("Item cannot be null.")
		{
		}
	}
}
