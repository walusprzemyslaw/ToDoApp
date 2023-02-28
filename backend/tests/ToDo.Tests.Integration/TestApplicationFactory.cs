using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Infrastructure.EF;

namespace ToDo.Tests.Integration
{
	internal class TestWebApplicationFactory : WebApplicationFactory<Program>
	{
		public HttpClient Client { get; }

		public TestWebApplicationFactory(Action<IServiceCollection> services = null)
		{
			Client = WithWebHostBuilder(builder =>
			{
				if (services is not null)
				{
					builder.ConfigureServices(services);
				}

				builder.UseEnvironment("test");
			}).CreateClient();
		}
	}
}
