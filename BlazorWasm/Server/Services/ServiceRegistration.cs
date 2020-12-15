using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.Server.Services
{
	public static class ServiceRegistration
	{
		public static void AddConfiguration<T>(this IServiceCollection services,
												IConfiguration configuration,
												string configurationTag = null)
												where T : class
		{
			if (string.IsNullOrEmpty(configurationTag))
			{
				configurationTag = typeof(T).Name;
			}

			var instance = Activator.CreateInstance<T>();
			new ConfigureFromConfigurationOptions<T>(configuration.GetSection(configurationTag)).Configure(instance);
			services.AddSingleton(instance);
		}

		public static void AddDBService<T>(this IServiceCollection services)
		{
			var provider = services.BuildServiceProvider();
			var dbRespository = provider.GetRequiredService<IDbRespository>();

			var connection = dbRespository.CreateConnAsync().Result;

			var compiler = new MySqlCompiler();

			QueryFactory factory = new QueryFactory(connection, compiler);

			services.AddSingleton(factory);
			//services.AddTransient(provider => { return factory; });
		}


		public static void AddInfrastructure(this IServiceCollection services)
		{
			// Repository
			services.AddTransient<IUsersRepository, UsersRepository>();
			services.AddTransient<IDbRespository, DbRespository>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();

			// Service
			services.AddTransient<IUserService, UsersService>(); 
		}
	}
}
