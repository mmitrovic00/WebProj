using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekat.Models;

namespace Projekat.Infrastructure.Configurations
{
	public class ItemConfiguration : IEntityTypeConfiguration<Item>
	{

		public void Configure(EntityTypeBuilder<Item> builder)
		{
			builder.HasKey(x => x.Id); //Podesavam primarni kljuc tabele

			builder.Property(x => x.Id).ValueGeneratedOnAdd(); //Kazem da ce se primarni kljuc
															   //automatski generisati prilikom dodavanja,
															   //redom 1 2 3...

			builder.Property(x => x.Name).HasMaxLength(30);//kazem da je maks duzina 30 karaktera
			builder.Property(x => x.Description).HasMaxLength(100);
		}
	}
}
