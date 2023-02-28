using ToDo.Core.Exceptions;

namespace ToDo.Infrastructure.Exceptions;

public class LackOfToDoListException : CustomException
{
    public LackOfToDoListException(string message) : base(message)
    {
    }
}