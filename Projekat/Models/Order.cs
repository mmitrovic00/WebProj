using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Models
{
	public class Order
	{
		public int Id { get; set; }
		public User User { get; set; }
		public string UserId { get; set; }
		public Item item { get; set; }
		public long ItemId { get; set; }
		public int Amount { get; set; }
		public string Address { get; set; }
		public string Comment { get; set; }
		public double Cost { get; set; }
		public double Time { get; set; }
		public DateTime Date { get; set; }
		
	}
}
