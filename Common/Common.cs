using BlazorWasm.Shared;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
	public class Common
	{
		private readonly SettingsConfig _config;

		public Common(SettingsConfig configuration)
		{
			_config = configuration;
		}

	}
}
