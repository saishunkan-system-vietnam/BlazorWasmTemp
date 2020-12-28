using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWasm.Client.HttpRepositories
{
	public class BaseHttp
	{
		//private readonly HttpClient _client;
		protected HttpClient Client;// => _client ?? throw new ArgumentNullException();
		protected BaseHttp(HttpClient client)
		{
			this.Client = client;
		}
	}
}
