using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekat.Models;

namespace Projekat.Infrastructure.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{

            builder.HasKey(x => x.Id); //Podesavam primarni kljuc tabele

            builder.Property(x => x.Id).ValueGeneratedOnAdd(); //Kazem da ce se primarni kljuc
                                                               //automatski generisati prilikom dodavanja,
                                                               //redom 1 2 3...

            builder.Property(x => x.Comment).HasMaxLength(100);//kazem da je maks duzina 30 karaktera

          

            builder.HasOne(x => x.User) //Kazemo da Student ima jedan fakultet
                   .WithMany(x => x.Orders) // A jedan fakultet vise studenata
                   .HasForeignKey(x => x.UserId);// Ako se obrise fakultet kaskadno se brisu svi njegovi studenti

            builder.HasOne(x => x.item) //Kazemo da Student ima jedan fakultet
                   .WithMany(x => x.Orders) // A jedan fakultet vise studenata
                   .HasForeignKey(x => x.ItemId);// Ako se obrise fakultet kaskadno se brisu svi njegovi studenti



        }
    }
}
