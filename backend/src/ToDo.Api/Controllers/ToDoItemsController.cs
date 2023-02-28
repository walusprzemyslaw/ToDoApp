using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Abstractions;
using ToDo.Core.Command;
using ToDo.Core.DTO;
using ToDo.Infrastructure.Services;

namespace ToDo.Api.Controllers
{
	[Authorize]
	public class ToDoItemsController : BaseController
	{
		private readonly IToDoItemWriteService _toDoItemWriteService;
		private readonly IToDoItemReadService _toDoItemReadService;

		public ToDoItemsController(IToDoItemWriteService toDoItemWriteService, IToDoItemReadService toDoItemReadService)
		{
			_toDoItemWriteService = toDoItemWriteService;
			_toDoItemReadService = toDoItemReadService;
		}

		[HttpGet("{listId}")]
		public async Task<ActionResult<IEnumerable<ToDoItemDto>>> GetToDoItemAsync(Guid listId)
		{
			var toDoItem = await _toDoItemReadService.GetToDoItemsAsync(listId);
			return Ok(toDoItem);
		}
		
		[HttpGet("item/{id}")]
		public async Task<IActionResult> GetToDoItemsAsync(Guid id)
		{
			var items = await _toDoItemReadService.GetToDoItemAsync(id);
			return Ok(items);
		}
		
		[HttpPost]
		public async Task<ActionResult<ToDoItemDto>> CreateToDoItemAsync(CreateToDoItemCommand toDoItemDto)
		{
			await _toDoItemWriteService.CreateToDoItemAsync(toDoItemDto);
			return NoContent();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateToDoItemAsync(UpdateToDoItemCommand command)
		{
			await _toDoItemWriteService.UpdateToDoItemAsync(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveToDoItemAsync(Guid id)
		{
			await _toDoItemWriteService.RemoveToDoItemAsync(id);
			return NoContent();
		}

		[HttpGet("{id}/today")]
		public async Task<IActionResult> GetDueTodayItemsAsync(Guid id)
		{
			var items = await _toDoItemReadService.GetDueTodayItemsAsync(id);
			return Ok(items);
		}
		
		[HttpGet("{userId}/AnyDueDatesToday")]
		public async Task<IActionResult> GetAnyDueDatesTodayAsync(Guid userId)
		{
			return Ok(await _toDoItemReadService.AnyTodayItemsAsync(userId));
		}
		
		[HttpPut("status")]
		public async Task<IActionResult> ChangeStatusOfItem(ToDoItemStatusCommand command)
		{
			await _toDoItemWriteService.ChangeToDoStatusAsync(command.ToDoItemId, command.StatusDto);
			return Ok();
		}
	}
}
