using Microsoft.EntityFrameworkCore;
using VottingApp.Models;

namespace VottingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Poll>()
                .HasMany(p => p.Options)
                .WithOne(o => o.Poll)
                .HasForeignKey(o => o.PollId)
                .OnDelete(DeleteBehavior.Cascade); // This is okay

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Poll)
                .WithMany()
                .HasForeignKey(v => v.PollId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade loop

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Option)
                .WithMany()
                .HasForeignKey(v => v.OptionId)
                .OnDelete(DeleteBehavior.Restrict); // Prevents cascade loop

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany()
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Optional

            modelBuilder.Entity<Poll>()
       .Property(p => p.AllowedUserIds)
       .HasConversion(
           v => string.Join(",", v),
           v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
       );
        }

    }
}
