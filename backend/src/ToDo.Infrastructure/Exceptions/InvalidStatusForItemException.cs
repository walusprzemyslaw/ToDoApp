using ToDo.Core.Exceptions;

namespace ToDo.Infrastructure.Exceptions;

public class InvalidStatusForItemException : CustomException
{
    public InvalidStatusForItemException(string message) : base(message)
    {
    }
}