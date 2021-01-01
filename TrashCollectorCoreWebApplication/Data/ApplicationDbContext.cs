using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollectorCoreWebApplication.Models;

namespace TrashCollectorCoreWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
             );

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
             );

            builder.Entity<Day>()
                .HasData(
                new Day
                {
                    Id = 1,
                    Name = "Monday"
                }, new Day
                {
                    Id = 2,
                    Name = "Tuesday"
                });
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Day> Days { get; set; }

    }
}
