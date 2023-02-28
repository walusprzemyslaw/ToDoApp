using Mapster;
using ToDo.Core.Abstractions;
using ToDo.Core.Command;
using ToDo.Core.DTO;
using ToDo.Core.Entities;
using ToDo.Core.Enums;
using ToDo.Core.Extensions;
using ToDo.Core.Repositories;
using ToDo.Infrastructure.Exceptions;

namespace ToDo.Infrastructure.Services;

public class ToDoItemWriteService : IToDoItemWriteService
{
    private readonly IToDoItemRepository _toDoItemRepository;
    private readonly IClock _clock;

    public ToDoItemWriteService(IToDoItemRepository toDoItemRepository, IClock clock)
    {
        _toDoItemRepository = toDoItemRepository;
        _clock = clock;
    }

    public async Task<ToDoItemDto> CreateToDoItemAsync(CreateToDoItemCommand toDoItemDto)
    {
        var toDoItem = ToDoItem.CreateNewToDoItem(toDoItemDto.Name, toDoItemDto.Description, toDoItemDto.Notes,
            toDoItemDto.DueDate.ParseDate(), toDoItemDto.ToDoListId, _clock);
        await _toDoItemRepository.CreateToDoItemAsync(toDoItem);
        return toDoItem.Adapt<ToDoItemDto>();
    }

    public async Task UpdateToDoItemAsync(UpdateToDoItemCommand command)
    {
        ToDoItem toDoItem = await _toDoItemRepository.GetToDoItemAsync(command.ToDoItemId) ?? throw new LackOfToDoItemException("Lack of todoItem");
		toDoItem.UpdateToDoItem(command.Name, command.Description, command.Notes, command.DueDate.ParseDate(), _clock);
        await _toDoItemRepository.UpdateToDoItemAsync(toDoItem);
    }

    public async Task RemoveToDoItemAsync(Guid id)
    {
        var itemId = await _toDoItemRepository.GetToDoItemAsync(id);
        await _toDoItemRepository.RemoveToDoItemAsync(itemId);
    }

    public async Task ChangeToDoStatusAsync(Guid id, int status)
    {
        ToDoItem toDoItem = await _toDoItemRepository.GetToDoItemAsync(id) ?? throw new LackOfToDoItemException($"Could not find ToDoItem with id: {id}");
		if (Enum.IsDefined(typeof(ToDoStatus), status))
        {
            ToDoStatus myEnumValue = (ToDoStatus)status;
            toDoItem.ChangeStatus(myEnumValue);
            await _toDoItemRepository.UpdateToDoItemAsync(toDoItem);
        }
        else
        {
            throw new InvalidStatusForItemException($"Invalid status for item: {id}");
        }

    }
}