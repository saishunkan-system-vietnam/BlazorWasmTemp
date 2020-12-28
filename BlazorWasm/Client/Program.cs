using BlazorWasm.Client.HttpRepositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorWasm.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.Services.AddAntDesign();

			builder.Services.AddHttpClient("API", (sp, cl) =>
			{
				cl.BaseAddress = new Uri("https://localhost:5011/api/");
				cl.EnableIntercept(sp);
			});
			builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("API"));
			builder.Services.AddHttpClientInterceptor();

			builder.Services.AddScoped<IUsersHttpRepository, UsersHttpRepository>();

			await builder.Build().RunAsync();
		}
	}
}
