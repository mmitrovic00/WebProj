﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Models
{
	public class Item
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Amount { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public List<Order> Orders { get; set; }
	}
}
