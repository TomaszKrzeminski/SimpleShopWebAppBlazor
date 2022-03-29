using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleShopWebApp.Models;


namespace SimpleShopWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


       
            modelBuilder.Entity<ApplicationUser>()
                .HasOne<Instructor>(s => s.Instructor)
                .WithOne(ad => ad.ApplicationUser)
                .HasForeignKey<Instructor>(ad => ad.ApplicationUserId);      



        modelBuilder.Entity<ApplicationUser>()
                .HasOne<Cart>(s => s.cart)
                .WithOne(ad => ad.ApplicationUser)
                .HasForeignKey<Cart>(ad => ad.ApplicationUserId);




            modelBuilder.Entity<PaymentCategory>().HasKey(sc => new { sc.PaymentId, sc.CategoryId });



        }



        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<PaymentCategory> PaymentCategories { get; set; }









    }
}
