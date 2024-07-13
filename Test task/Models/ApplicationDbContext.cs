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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasOne(u => u.Creator)
                .WithMany(c => c.MyChats)
                .HasForeignKey(u => u.CreatorId);

            modelBuilder.Entity<Chat>()
                .HasMany(u => u.Users)
                .WithMany(c => c.Chats);

            modelBuilder.Entity<Message>()
                .HasOne(u => u.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(u => u.ChatId);

            modelBuilder.Entity<Message>()
                .HasOne(u => u.User)
                .WithMany(c => c.Messages)
                .HasForeignKey(u => u.UserId);
        }
    }
}
