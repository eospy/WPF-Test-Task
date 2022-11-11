using Microsoft.EntityFrameworkCore;
using AppLibrary;
namespace Serverapp
{
    public class DatabaseContext:DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Mouseevents> Events => Set<Mouseevents>();
        public DbSet<Destinationaddr> Addresses => Set<Destinationaddr>();
        public DatabaseContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=testtask0911.db");
        }
    }
}
