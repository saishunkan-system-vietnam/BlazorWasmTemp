using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public UnitOfWork(IUsersRepository usersRepository)
		{
			this.Users = usersRepository;
		}
		public IUsersRepository Users { get; }

	}
}
