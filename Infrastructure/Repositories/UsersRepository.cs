using BlazorWasm.Shared;
using Infrastructure.Interfaces;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public interface IUsersRepository : IGenericRepository<Users>
	{
	}

	public class UsersRepository : BaseRepository, IUsersRepository
	{
		public UsersRepository(SettingsConfig config, QueryFactory db) : base(config, db)
		{
		}

		public async Task<int> AddAsync(Users entity)
		{
			var result = await this.Db.Query("users").InsertAsync(new
			{
				UserId = entity.UserId,
				Password = entity.Password,
				FullName = entity.FullName,
				BirthDt = entity.BirthDt,
				Phone = entity.Phone,
				UsUpdateDtTm = entity.UsUpdateDtTm,
				DelFlg = entity.DelFlg,
			});

			return result;
		}

		public async Task<int> DeleteAsync(int id)
		{
			var result = await this.Db.Query("users").Where("UserId", id).DeleteAsync();

			return result;
		}

		public async Task<IEnumerable<Users>> GetAllAsync()
		{
			var users = await this.Db.Query("users").GetAsync<Users>();

			return users;
		}

		public async Task<Users> GetByIdAsync(int id)
		{
			var users = await this.Db.Query("users").Where("UserId", id).FirstAsync();

			return users;
		}

		public async Task<int> UpdateAsync(Users entity)
		{
			var result = await this.Db.Query("users").Where("UserId", entity.UserId).UpdateAsync(new
			{
				FullName = entity.FullName,
				BirthDt = entity.BirthDt,
				Phone = entity.Phone,
				UsUpdateDtTm = entity.UsUpdateDtTm,
				DelFlg = entity.DelFlg,
			});

			return result;
		}
	}
}
