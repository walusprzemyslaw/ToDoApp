using ToDo.Core.Exceptions;

namespace ToDo.Infrastructure.Exceptions;

public class LackOfToDoItemException : CustomException
{
    public LackOfToDoItemException(string message) : base(message)
    {
    }
}