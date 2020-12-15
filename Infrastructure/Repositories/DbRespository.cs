using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorWasm.Shared;
using MySql.Data.MySqlClient;
using SqlKata.Execution;

namespace Infrastructure.Repositories
{
	public interface IDbRespository
	{
		Task<IDbConnection> CreateConnAsync();
	}
	public class DbRespository : IDbRespository
	{
		public SettingsConfig Config { get; private set; }

		public DbRespository(SettingsConfig config)
		{
			this.Config = config;
		}

		public async Task<IDbConnection> CreateConnAsync()
		{
			var conn = new MySqlConnection(this.Config.ConnectionStringId);
			await conn.OpenAsync();
			return conn;
		}
	}
}