using Microsoft.AspNetCore.Mvc;
using Projekat.Dto;
using Projekat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Controllers
{

	[Route("api/users")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("{userName}")]
		public IActionResult Get(string userName)
		{
			return Ok(_userService.GetByUserName(userName));
		}

		[HttpPost]
		public IActionResult CreateUser([FromBody] UserDto user)
		{
			return Ok(_userService.AddUser(user));
		}


		[HttpPut("{userName}")]
		public IActionResult ChangeUser(string userName, [FromBody] UserDto stud)
		{
			return Ok(_userService.UpdateUser(userName, stud));
		}
	}
}
