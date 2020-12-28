using BlazorWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWasm.Client.HttpRepositories
{
	public interface IUsersHttpRepository
	{
		Task<List<Users>> GetUsers();
	}
	public class UsersHttpRepository : BaseHttp, IUsersHttpRepository
	{

		public UsersHttpRepository(HttpClient client) : base(client) { }

		public async Task<List<Users>> GetUsers()
		{
			List<Users> users = new List<Users>();
			try
			{
				var res = await this.Client.GetAsync("users");
				//var res = await this.Client.GetAsync("/api/users");
				var data = await res.Content.ReadAsStringAsync();
				users = JsonSerializer.Deserialize<List<Users>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
				
			}
			catch(Exception e)
			{
				
			}

			return users;
		}
	}
}
