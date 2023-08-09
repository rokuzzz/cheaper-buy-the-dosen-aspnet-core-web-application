﻿
using CBTD.Models;
using Microsoft.EntityFrameworkCore;

namespace CBTD.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)    
        {
            
        }

		public DbSet<Category> Categories { get; set; }  //the physical DB table will be named Categories
        public DbSet<Manufacturer> Manufacturers { get; set; }
        //insterting seed data when Model is physically created in the DB the first time
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = 1, CategoryName = "Non-Alcoholic Beverages", DisplayOrder = 1 },
				new Category { CategoryId = 2, CategoryName = "Wine", DisplayOrder = 2 },
				new Category { CategoryId = 3, CategoryName = "Snacks", DisplayOrder = 3 }
			   );

            modelBuilder.Entity<Manufacturer>().HasData(
             new Manufacturer { Id = 1, Name = "Coca Cola" },
             new Manufacturer { Id = 2, Name = "Yellow Tail" },
             new Manufacturer { Id = 3, Name = "Frito Lay" }
            );
        }

	}
}
