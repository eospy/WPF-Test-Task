using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Serverapp
{
    public class MouseEventsContext : DbContext
    {
        public MouseEventsContext() => Database.EnsureCreated();
        public DbSet<Mouseevents> Mouseevents { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite("Data Source=testtask0911.db");
        }
       
    }
}
