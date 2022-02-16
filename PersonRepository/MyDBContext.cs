using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TimeSheet.DB.Entity;

namespace TimeSheet.DB
{
    public sealed class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(x => x.Id).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(x => x.Id).IsUnique();
        }
    }
}
