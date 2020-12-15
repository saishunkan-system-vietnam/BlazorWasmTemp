using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.Server.Services
{
	public interface IUserService : IUnitOfWork { }
	public class UsersService : IUserService
	{
		public UsersService(IUnitOfWork unitOfWork)
		{
			this.Users = unitOfWork.Users;
		}

		public IUsersRepository Users { get; set; }
	}
}
