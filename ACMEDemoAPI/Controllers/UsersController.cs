using Microsoft.AspNetCore.Mvc;
using WinDemoAPI.Interfaces;
using WinDemoAPI.Models.Domain;
using WinDemoAPI.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WinDemoAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepo _userObj;

		public UsersController(IUserRepo userObj)
		{
			_userObj = userObj;
		}
		// GET: api/<UsersController>
		[HttpGet]
		public async Task<IEnumerable<User>> Get()
		{
			return await _userObj.GetAllUserAsync();
		}

		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> Get(int id)
		{
			var user = await _userObj.GetUserByIdAsync(id);
			return user;
		}

		// POST api/<UsersController>
		[HttpPost]
		[ValidateModel]
		public async Task<ActionResult<User>> Post([FromBody] User user)
		{
			if (user == null)
			{
				return NotFound();
			}

		 	var result = await _userObj.AddUserAsync(user);

			return Ok(result);
		}

		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		[ValidateModel]
		public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
		{
			return await _userObj.UpdateUserAsync(id, user);
		}

		
		// DELETE api/<UsersController>/5
		[HttpDelete]
		[Route("{Id}")]
		public async Task<IActionResult> Delete(int Id)
		{
			var userdata = await _userObj.DeleteUserAsync(Id);
			return Ok(userdata);
		}
	}
}
