using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.DTO
{
	public class ToDoListDto
	{
		public Guid ToDoListId { get; set; }
		[Required]
		public string Name { get; set; }
		public bool Visibility { get; set; }
		public bool HiddenFinishedItems { get; set; }
		public IEnumerable<ToDoItemDto> Items { get; set; }
		[Required]
		public Guid UserId { get; set; }
	}
}
