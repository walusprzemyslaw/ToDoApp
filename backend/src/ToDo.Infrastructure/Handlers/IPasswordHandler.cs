using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Handlers
{
	public interface IPasswordHandler
	{
		Task<string> HashPasswordAsync(string password);
		Task<bool> CheckPasswordAsync(string password, string securedPassword);
	}
}
