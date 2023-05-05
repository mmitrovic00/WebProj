using Projekat.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Interfaces
{
	public interface IUserService
	{
		UserDto AddUser(UserDto newUser);
		UserDto GetByUserName(string UserName);
		UserDto UpdateUser(string UserName,UserDto newUser);
	}
}
