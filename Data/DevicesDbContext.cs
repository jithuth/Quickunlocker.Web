using Microsoft.EntityFrameworkCore;
using Quickunlocker.Web.Models;

namespace Quickunlocker.Web.Data
{
    public class DevicesDbContext : DbContext
    {
        public DevicesDbContext(DbContextOptions<DevicesDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Network> Networks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Global query filter to exclude soft-deleted devices
            modelBuilder.Entity<Device>()
                .HasQueryFilter(d => !d.IsDeleted);

            // Configure indexes for devices
            modelBuilder.Entity<Device>()
                .HasIndex(d => d.Tac);

            modelBuilder.Entity<Device>()
                .HasIndex(d => d.IsDeleted);

            // Global query filter to exclude soft-deleted countries
            modelBuilder.Entity<Country>()
                .HasQueryFilter(c => !c.IsDeleted);

            // Configure indexes for countries
            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Code)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.IsActive);

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.IsDeleted);

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.DisplayOrder);

            // Global query filter to exclude soft-deleted networks
            modelBuilder.Entity<Network>()
                .HasQueryFilter(n => !n.IsDeleted);

            // Configure indexes for networks
            modelBuilder.Entity<Network>()
                .HasIndex(n => n.CountryId);

            modelBuilder.Entity<Network>()
                .HasIndex(n => n.IsActive);

            modelBuilder.Entity<Network>()
                .HasIndex(n => n.IsDeleted);

            modelBuilder.Entity<Network>()
                .HasIndex(n => n.DisplayOrder);

            // Configure relationship
            modelBuilder.Entity<Network>()
                .HasOne(n => n.Country)
                .WithMany()
                .HasForeignKey(n => n.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
