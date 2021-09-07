using Cars.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Data
{
    public class CarsDbContext : IdentityDbContext
    {
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Category> Categories { get; set; }

        public DbSet<Dealer> Dealers { get; set; }
        

        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Car>()
                .HasOne(c => c.Dealer)
                .WithMany(d => d.Cars)
                .HasForeignKey(c => c.DealerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Dealer>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Dealer>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
