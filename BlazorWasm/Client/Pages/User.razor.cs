using BlazorWasm.Client.HttpRepositories;
using BlazorWasm.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.Client.Pages
{
	public partial class User : ComponentBase, IDisposable
	{
		public List<Users> UsersList { get; set; } = new List<Users>();

		[Inject]
		public IUsersHttpRepository UsersRepo { get; set; }

		[Inject]
		public HttpInterceptorService Interceptor { get; set; }

		protected async override Task OnInitializedAsync()
		{
			Interceptor.RegisterEvent();
			UsersList = await UsersRepo.GetUsers();
		}

		public void Dispose() => Interceptor.DisposeEvent();
	}
}
