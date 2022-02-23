using Microsoft.EntityFrameworkCore;
using TimeSheet.DB.DAL.Entity;

namespace TimeSheet.DB
{
    public sealed class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
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
