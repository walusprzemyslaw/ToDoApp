namespace ToDo.Core.Abstractions
{
	public interface IClock
	{
		DateTime CurrentDay();
		DateTime CurrentTime();
	}
}
