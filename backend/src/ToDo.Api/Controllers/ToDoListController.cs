using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Abstractions;
using ToDo.Core.Command;
using ToDo.Core.DTO;
using ToDo.Infrastructure.Services;

namespace ToDo.Api.Controllers
{
	[Authorize]
	public class ToDoListController : BaseController
	{
		private readonly IToDoListWriteService _toDoListWriteService;
		private readonly IToDoListReadService _toDoListReadService;

		public ToDoListController(IToDoListWriteService toDoListWriteService, IToDoListReadService toDoListReadService)
		{
			_toDoListWriteService = toDoListWriteService;
			_toDoListReadService = toDoListReadService;
		}

		[HttpGet("{userId}/lists")]
		public async Task<ActionResult<IEnumerable<ToDoListDto>>> GetToDoListsAsync(Guid userId)
		{
			var toDoList = await _toDoListReadService.GetToDoListsAsync(userId);
			return OkOrNotFound(toDoList);
		}

		[HttpGet("{toDoListId}/list")]
		public async Task<ActionResult<ToDoListDto>> GetToDoListAsync(Guid toDoListId)
		{
			var toDoList = await _toDoListReadService.GetToDoListAsync(toDoListId);
			return OkOrNotFound(toDoList);
		}
		
		[HttpPost]
		public async Task<ActionResult<ToDoListDto>> CreateToDoListAsync(CreateToDoListCommand toDoListDto)
		{
			await _toDoListWriteService.CreateToDoListAsync(toDoListDto);
			return NoContent();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateToDoListAsync(ToDoListUpdateCommand toDoListUpdateCommand)
		{
			await _toDoListWriteService.UpdateToDoListAsync(toDoListUpdateCommand);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveToDoListAsync(Guid id)
		{
			await _toDoListWriteService.RemoveToDoListAsync(id);

			return NoContent();
		}

		[HttpPut("visibilityOfList")]
		public async Task<IActionResult> ChangeVisibilityToDoListAsync(ListVisibilityCommand command)
		{
			var result = await _toDoListWriteService.ChangeVisibilityToDoListAsync(command.ListId);
			return Ok(result);
		}

		[HttpPut("visibilityOfFinishedItems")]
		public async Task<IActionResult> ChangeVisibilityOfCompletedItemsAsync(ListVisibilityOfFinishedItemsCommand command)
		{
			var result = await _toDoListWriteService.ChangeVisibilityOfCompletedItemsAsync(command.ListId);
			return Ok(result);
		}

		[HttpPut("clone")]
		public async Task<IActionResult> CloneList(CloneCommand command)
		{
			var result = await _toDoListWriteService.CopyToDoListAsync(command.ListId);
			return Ok(result);
		}
	}
}
