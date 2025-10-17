using GoldCard.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldCard.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Card> Cards => Set<Card>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<User>(e =>
            {
                e.Property(u => u.CustomerNumber).IsRequired().HasMaxLength(50);
                e.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
                e.Property(u => u.LastName).IsRequired().HasMaxLength(100);
                e.Property(u => u.Town).IsRequired().HasMaxLength(100);
                e.HasIndex(u => u.CustomerNumber).IsUnique();
            });

            b.Entity<Card>(e =>
            {
                e.Property(c => c.CardNumber).IsRequired().HasMaxLength(50);
                e.Property(c => c.CardType).IsRequired().HasMaxLength(50);
                e.HasIndex(c => c.CardNumber).IsUnique();
            });
        }
    }
}
