using BlazorWasm.Shared;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Infrastructure.Repositories
{
	public class BaseRepository
	{
		public SettingsConfig Config { get; private set; }
		public QueryFactory Db { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseRepository"/> class.
		/// </summary>
		/// <param name="config"></param>
		/// <param name="db"></param>
		public BaseRepository(SettingsConfig config, QueryFactory db)
		{
			this.Config = config;
			this.Db = db;
		}
	}
}
