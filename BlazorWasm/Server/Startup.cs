using BlazorWasm.Server.Services;
using BlazorWasm.Shared;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlKata.Execution;
using System.Linq;

namespace BlazorWasm.Server
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(policy =>
			{
				policy.AddDefaultPolicy(opt => opt
					.AllowAnyOrigin()
					.SetIsOriginAllowed(origin => true)
					.AllowAnyHeader()
					.AllowAnyMethod()
					);
			});
			services.AddConfiguration<SettingsConfig>(this.Configuration, "MySettings");
			services.AddInfrastructure();
			services.AddDBService<QueryFactory>();
			services.AddControllersWithViews();
			services.AddRazorPages();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			/*Exception Handling
			HTTPS Redirection
			Static Files
			Cookie Policy
			Routing
			Authentication
			Authorization
			Session
			Endpoint Routing*/
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.AddMiddleware();

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseCors();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
