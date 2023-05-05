using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Projekat.Infrastructure.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
            builder.HasKey(x => x.UserName); //Podesavam primarni kljuc tabele

            //builder.Property(x => x.Id).ValueGeneratedOnAdd(); //Kazem da ce se primarni kljuc
                                                               //automatski generisati prilikom dodavanja,
                                                               //redom 1 2 3...

            builder.Property(x => x.Name).HasMaxLength(30);//kazem da je maks duzina 30 karaktera
            builder.Property(x => x.LastName).HasMaxLength(30);

            builder.HasIndex(x => x.Email).IsUnique();//Kazem da je broj indeksa studenta
                                                      //jedinstven podatak (ne smeju biti 2 ista)

        }
	}
}
