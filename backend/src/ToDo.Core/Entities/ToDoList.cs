using ToDo.Core.Abstractions;
using ToDo.Core.Exceptions;

namespace ToDo.Core.Entities;

public class ToDoList
{
    private ICollection<ToDoItem> _items = new List<ToDoItem>();
    public Guid ToDoListId { get; private set;}
    public string Name { get; private set; }
    public bool Visibility { get; private set; }
    public bool HiddenFinishedItems { get; private set; }
    public virtual IEnumerable<ToDoItem> Items
    {
        get => _items;
        set => _items = new List<ToDoItem>(value);
    }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public ToDoList(){ }

    public ToDoList(string name, Guid userId)
    {
        ToDoListId = Guid.NewGuid();
        SetName(name);
        Visibility = true;
        HiddenFinishedItems = false;
        UserId = userId;
    }
    
    public ToDoList Clone(IClock clock)
    {
        var copiedToDoList = new ToDoList($"{Name} (Copy)", UserId);
        foreach (var item in _items)
        {
            var toDoItem = item.CloneToDoItem(copiedToDoList.ToDoListId, clock);
            copiedToDoList.AssignToDoItem(toDoItem);
        }

        return copiedToDoList;
    }
    
    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new InvalidEntityNameException();
        if (Name == name) return;

        Name = name;
    }
    
    internal void AssignToDoItem(ToDoItem item)
    {
        if (item.ToDoListId != ToDoListId) throw new ToDoListIdDiscrepacyException();
        _items.Add(item);
    }

    public bool ChangeListVisibility()
    {
        Visibility = !Visibility;
        return Visibility;
    }

	public bool ChangeVisibilityOfFinishedItems()
	{
		HiddenFinishedItems = !HiddenFinishedItems;
		return HiddenFinishedItems;
	}
}