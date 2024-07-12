using Microsoft.EntityFrameworkCore;

namespace Test_task.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Chat> Chats => Set<Chat>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<User> Users => Set<User>();
        public ApplicationDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=test.db");
        }
    }
}
