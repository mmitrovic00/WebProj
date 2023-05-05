using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Dto
{
	public class UserDto
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Birthday { get; set; }
		public string Address { get; set; }
		public UserType UserType { get; set; }
		public string ImagePath { get; set; }
	}
}
