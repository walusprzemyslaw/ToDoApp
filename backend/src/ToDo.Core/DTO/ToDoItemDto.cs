using System.ComponentModel.DataAnnotations;

namespace ToDo.Core.DTO
{
	public class ToDoItemDto
	{
		public Guid ToDoItemId { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string Notes { get; set; }
		public DateTime CreatedDate { get; set; }
		[Required]
		public DateTime DueDate { get; set; }
		public ToDoStatusDto Status { get; set; }
		public Guid ToDoListId { get; set; }
	}
}
