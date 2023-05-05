using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Dto
{
	public class OrderDto
	{

		public int Id { get; set; }
		public UserDto User { get; set; }
		public ItemDto item { get; set; }
		public int Amount { get; set; }
		public string Address { get; set; }
		public string Comment { get; set; }
		public double Cost { get; set; }
		public double Time { get; set; }
		public DateTime Date { get; set; }

	}
}
