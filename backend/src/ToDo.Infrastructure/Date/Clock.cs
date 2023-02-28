using ToDo.Core.Abstractions;

namespace ToDo.Infrastructure.Date
{
	internal sealed class Clock : IClock
	{
		public DateTime CurrentDay() => DateTime.Today;
		public DateTime CurrentTime() => DateTime.Now;
	}
}
