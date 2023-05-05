using AutoMapper;
using Projekat.Dto;
using Projekat.Infrastructure;
using Projekat.Interfaces;
using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Projekat.Services
{
	public class UserService : IUserService
	{
		private readonly IMapper _mapper;
		private readonly WSDBContext _dbContext;
		public UserService(IMapper mapper, WSDBContext dbContext)
		{
			_mapper = mapper;
			_dbContext = dbContext;
		}
		public UserDto AddUser(UserDto newUser)
		{

			User user = _mapper.Map<User>(newUser);
			user.Password = Hash(user.Password);
			_dbContext.Users.Add(user);
			_dbContext.SaveChanges();

			return _mapper.Map<UserDto>(newUser); //Dobra je praksa vratiti kreirani objekat nazad,
													 //narocito ako se auto generise ID
		}

		public UserDto GetByUserName(string UserName)
		{
			return _mapper.Map<UserDto>(_dbContext.Users.Find(UserName));

		}

		public UserDto UpdateUser(string UserName, UserDto newUser)
		{
			User user = _dbContext.Users.Find(UserName); //Ucitavamo objekat u db context (ako postoji naravno)
			user.Email = newUser.Email;
			user.Password = Hash(newUser.Password);
			user.Name = newUser.Name;
			user.LastName = newUser.LastName;
			user.Birthday = newUser.Birthday;
			user.Address = newUser.Address;

			_dbContext.SaveChanges(); //Samo menjanje polja ucitanog studenta iz baze podataka je dovoljno
									  //da se ti podaci promene i u bazi nakon cuvanja

			return _mapper.Map<UserDto>(user);
		}

		public string Hash(string password)
		{
			// Create a new instance of the SHA256 hashing algorithm
			SHA256 sha256 = SHA256.Create();

			// Convert the password string to a byte array
			byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

			// Compute the hash value of the password using the SHA256 algorithm
			byte[] hashBytes = sha256.ComputeHash(passwordBytes);

			// Convert the hash value to a string representation
			string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

			// The resulting hash string can be stored in the database for later verification
			return hash;
		}
	}
}
