using Microsoft.EntityFrameworkCore;
using UberClone.Core.Entities;
using UberClone.Core.Enums;

namespace UberClone.Infrastructure.Contexts
{
    public class MockDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public MockDbContext(DbContextOptions<MockDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Trip entity
            modelBuilder.Entity<Trip>().HasKey(t => t.Id); // Primary key

            modelBuilder.Entity<Trip>().Property(t => t.StartTime).IsRequired(); // Make StartTime required

            modelBuilder
                .Entity<Trip>()
                .HasOne(t => t.Driver) // Relationship configuration
                .WithMany(d => d.OrderHistory)
                .HasForeignKey(t => t.DriverId);

            modelBuilder
                .Entity<Trip>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.OrderHistory)
                .HasForeignKey(t => t.CustomerId);

            modelBuilder
                .Entity<Trip>()
                .HasData(
                    new Trip
                    {
                        TripId = 1,
                        Destination = "City Center",
                        DriverId = 1,
                        CustomerId = 1,
                        StartTime = DateTime.Now
                    }
                );
            // Additional configurations as needed

            modelBuilder.Entity<Trip>().OwnsOne(t => t.StartLocation);
            modelBuilder.Entity<Trip>().OwnsOne(t => t.EndLocation);
        }
    }
}
