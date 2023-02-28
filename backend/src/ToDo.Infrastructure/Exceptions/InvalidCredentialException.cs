using ToDo.Core.Exceptions;

namespace ToDo.Infrastructure.Exceptions;

public class InvalidCredentialException : CustomException
{
    public InvalidCredentialException(string message) : base(message)
    {
    }
}