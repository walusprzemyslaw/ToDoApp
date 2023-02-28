namespace ToDo.Core.Exceptions
{
	public sealed class CredentialEmptyException : CustomException
	{
		public CredentialEmptyException(string message) : base(message)
		{
		}
	}
}