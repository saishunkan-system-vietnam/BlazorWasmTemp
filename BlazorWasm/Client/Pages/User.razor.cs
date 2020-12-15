using BlazorWasm.Client.HttpRepositories;
using BlazorWasm.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.Client.Pages
{
	public partial class User : ComponentBase
	{
		public List<Users> UsersList { get; set; } = new List<Users>();

		[Inject]
		public IUsersHttpRepository UsersRepo { get; set; }

		protected async override Task OnInitializedAsync()
		{
			UsersList = await UsersRepo.GetUsers();

			//just for testing
			foreach (var product in UsersList)
			{

			}
		}
	}
}
