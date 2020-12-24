using BlazorWasm.Server.Services;
using BlazorWasm.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : BaseController
	{

		public UsersController(IServices services) : base(services)
		{

		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var data = await this.UsersService.Users.GetAllAsync();
			return Ok(data);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await this.UsersService.Users.GetByIdAsync(id);
			if (data == null) return Ok();
			return Ok(data);
		}
		[HttpPost]
		public async Task<IActionResult> Add(Users product)
		{
			var data = await this.UsersService.Users.AddAsync(product);
			return Ok(data);
		}
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var data = await this.UsersService.Users.DeleteAsync(id);
			return Ok(data);
		}
		[HttpPut]
		public async Task<IActionResult> Update(Users product)
		{
			var data = await this.UsersService.Users.UpdateAsync(product);
			return Ok(data);
		}
	}
}
