namespace ToDo.Core.DTO;

public record LoginDto(string UserName, string Token, Guid UserId);