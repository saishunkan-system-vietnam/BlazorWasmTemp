using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.Server.Services
{
	public interface IServices 
	{
		IUserService UserService { get; }
	}

	public class Services : IServices
	{
		public IUserService UserService { get; }
		public Services(IUserService userService)
		{
			this.UserService = userService;
		}
	}
}
