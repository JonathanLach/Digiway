using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigiwayWebapi.Models
{
    public partial class DigiwayContext : DbContext
    {
        public DigiwayContext(DbContextOptions options):base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("digiway");
            modelBuilder.Entity<UserCompany>().HasKey(table => new { table.UserId, table.CompanyId });
            modelBuilder.Entity<User>().Property(u => u.Money).HasDefaultValue(0);
            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithOne(f => f.User).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Friendship>().HasOne(fr => fr.User).WithMany(u => u.Friends).OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<ActionRecord> ActionRecords { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
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
