using ToDo.Core.Exceptions;

namespace ToDo.Infrastructure.Exceptions;

public class UsernameInUseException : CustomException
{
    public UsernameInUseException() : base("Username already exist.")
    {
    }
}