using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TShirtShop.Core;
using TShirtShop.Core.Models;

namespace TShirtShop.Data
{
    public class TShirtDbContext : IdentityDbContext<IdentityUser>
    {
        public TShirtDbContext(DbContextOptions<TShirtDbContext> options)
            : base(options)
        {

        }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed Size
            modelBuilder.Entity<Size>().HasData(new Size { SizeId = 1, Name = "Small" });
            modelBuilder.Entity<Size>().HasData(new Size { SizeId = 2, Name = "Medium" });
            modelBuilder.Entity<Size>().HasData(new Size { SizeId = 3, Name = "Large" });

            //seed tshirts

            //modelBuilder.Entity<Shirt>().HasData(new Shirt
            //{
            //    Id = 1,
            //    SizeId = 2,
            //    Gender = GenderEnum.Male,
            //    Name = "C# Developer",
            //    Description = "C# Developer",
            //    Price = 500,
            //    ImageLocation = "threadbird-logo-black.jpg",
            //    ImageThumnNailLocation = "threadbird-logo-black.jpg"
            //});

            //modelBuilder.Entity<Shirt>().HasData(new Shirt
            //{
            //    Id = 2,
            //    SizeId = 3,
            //    Gender = GenderEnum.Male,
            //    Name = "HTML",
            //    Description = "HTML",
            //    Price = 500,
            //    ImageLocation = "world-shirt_large.jpg",
            //    ImageThumnNailLocation = "world-shirt_large.jpg"

            //});

            //modelBuilder.Entity<Shirt>().HasData(new Shirt
            //{
            //    Id = 3,
            //    SizeId = 1,
            //    Gender = GenderEnum.Male,
            //    Name = "Java Developer",
            //    Description = "Java Developer",
            //    Price = 500,
            //    ImageLocation = "White_Tshirt.jpg",
            //    ImageThumnNailLocation = "White_Tshirt.jpg"

            //});
            //modelBuilder.Entity<Shirt>().HasData(new Shirt
            //{
            //    Id = 4,
            //    SizeId = 3,
            //    Gender = GenderEnum.Male,
            //    Name = "HTML",
            //    Description = "HTML",
            //    Price = 500,
            //    ImageLocation = "world-shirt_large.jpg",
            //    ImageThumnNailLocation = "world-shirt_large.jpg"


            //});

        }
    }
}
