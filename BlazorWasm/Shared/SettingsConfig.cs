using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm.Shared
{
	public sealed class SettingsConfig
	{
		public bool Log { get; set; }
		public string Domain { get; set; }
		public string ConnectionStringId { get; set; }
		public Parameters Parameters { get; set; }
		public Jwt Jwt { get; set; }

		public MailSettings MailSettings { get; set; }
	}

	public sealed class Parameters
	{
		public bool IsProduction { get; set; }
	}

	public sealed class Jwt
	{
		public string Key { get; set; }
		public string Issuer { get; set; }
	}

	public sealed class MailSettings
	{
		public string Email { get; set; }
		public string Pass { get; set; }
		public string MailAdminRcv { get; set; }
	}
}
