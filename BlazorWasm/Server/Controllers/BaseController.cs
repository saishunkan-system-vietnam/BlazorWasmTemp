using BlazorWasm.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.Server.Controllers
{
	public class BaseController : Controller
	{
		protected IUserService UsersService { get; }

		protected BaseController(IUserService usersService)
		{
			this.UsersService = usersService;
		}
	}
}
