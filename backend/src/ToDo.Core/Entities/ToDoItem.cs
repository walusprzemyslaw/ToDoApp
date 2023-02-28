using ToDo.Core.Abstractions;
using ToDo.Core.Enums;
using ToDo.Core.Exceptions;

namespace ToDo.Core.Entities;

public class ToDoItem
{
    public ToDoItem()
    {
    }

    private ToDoItem(string name, string description, string notes, DateTime dueDate, ToDoStatus toDoStatus,
        Guid toDoListId, IClock clock)
    {
        var currentDay = clock.CurrentDay();
        ToDoListId = toDoListId;
        ToDoItemId = Guid.NewGuid();
        Description = description;
        Notes = notes;
        CreatedDate = currentDay;
        Status = toDoStatus;
        SetDueDate(dueDate, currentDay);
        SetName(name);
    }

    public Guid ToDoItemId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set;}
    public string Notes { get; private set;}
    public DateTime CreatedDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public ToDoStatus Status { get; private set; }
    public Guid ToDoListId { get; set; }
    public virtual ToDoList ToDoList { get; set;}

    public static ToDoItem CreateNewToDoItem(string name, string description, string notes, DateTime dueDate,
        Guid toDoListId, IClock clock)
    {
        return new(name, description, notes, dueDate, ToDoStatus.NotStarted, toDoListId, clock);
    }

    public ToDoItem CloneToDoItem(Guid toDoListId, IClock clock)
    {
        return new(Name, Description, Notes, DueDate, Status, toDoListId, clock);
    }
    public void UpdateToDoItem(string name, string description, string notes, DateTime dueDate, IClock clock)
    {
        SetName(name);
        SetDueDate(dueDate, clock.CurrentDay());
        Description = description;
        Notes = notes;
    }

    public ToDoStatus ChangeStatus(ToDoStatus status)
    {
        Status = status;
        return Status;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new InvalidEntityNameException();
        if (Name == name) return;

        Name = name;
    }

    private void SetDueDate(DateTime dueDate, DateTime currentUtcDate)
    {
        if (dueDate < currentUtcDate) throw new InvalidDueDateException();
        if (DueDate == dueDate) return;

        DueDate = dueDate.Date;
    }
}