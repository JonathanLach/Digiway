using Microsoft.EntityFrameworkCore;
using System;

namespace DigiwayModel
{
    public class DigiwayContext : DbContext
    {
        public DigiwayContext(DbContextOptions options):base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("digiway");
            modelBuilder.Entity<UserCompany>().HasKey(table => new { table.UserId, table.CompanyId });
            modelBuilder.Entity<Friendship>().HasKey(table => new { table.UserId, table.FriendId });
            modelBuilder.Entity<Friendship>(f =>
                {
                    f.HasOne(u => u.User).WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull);
                    f.HasOne(fr => fr.Friend).WithMany().HasForeignKey("FriendId").OnDelete(DeleteBehavior.ClientSetNull);
                }
            );
         }

        public DbSet<ActionRecord> ActionRecords { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PurchaseRecord> PurchaseRecords { get; set; }
        public DbSet<TransferRecord> TransferRecords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
    }
}
