using Microsoft.EntityFrameworkCore;
using System;

namespace DigiwayDB
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("digiway");
        }

        public DbSet<EventCategory> EventCategories { get; set; }
    }
}
