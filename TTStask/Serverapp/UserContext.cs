using Microsoft.EntityFrameworkCore;
namespace Serverapp
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public UserContext()=>Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=testtask0911.db");
        }
         
        }
}
