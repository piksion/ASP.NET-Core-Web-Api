using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		[HttpGet]
		public ActionResult<List<string>> GetAllUsers()
		{
			return Ok(StaticDb.UserNames);
		}

		[HttpGet("{id}")]
		public ActionResult<string> GetUserName (string username)
		{
			if(string.IsNullOrEmpty(username))
			{
				return BadRequest("The number can not be negative");
			}
			
			var user =  StaticDb.UserNames.FirstOrDefault(x => x.Equals(username));
			if(user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}
	}
}
