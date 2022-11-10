using Microsoft.EntityFrameworkCore;

namespace Serverapp
{
    public class DestinationaddrContext:DbContext
    {
        public DbSet<Destinationaddr> Adresses { get; set; } = null!;
        public DestinationaddrContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=testtask0911.db");
        }
    }
}
