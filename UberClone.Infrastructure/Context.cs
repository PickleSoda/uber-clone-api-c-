using Microsoft.EntityFrameworkCore;
using UberClone.Core.Entities;

namespace UberClone.Infrastructure.Contexts
{
    public class MockDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public MockDbContext(DbContextOptions<MockDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Trip>(entity =>
            // {
            //     entity.HasKey(t => t.Id);
            //     entity.Property(t => t.StartTime).IsRequired();
            //     entity.OwnsOne(t => t.StartLocation);
            //     entity.OwnsOne(t => t.EndLocation);

            //     // Configure the relationships
            //     entity
            //         .HasOne(t => t.Customer)
            //         .WithMany(c => c.OrderHistory)
            //         .OnDelete(DeleteBehavior.Restrict); // No need to specify foreign key

            //     entity
            //         .HasOne(t => t.Driver)
            //         .WithMany(d => d.OrderHistory)
            //         .OnDelete(DeleteBehavior.Restrict); // No need to specify foreign key
            // });

            // // Ensure configurations for other entities as needed
            // modelBuilder.Entity<Customer>(entity =>
            // {
            //     entity.HasMany<Trip>().WithOne().HasForeignKey(ct => ct.CustomerId);
            // });

            // modelBuilder.Entity<Driver>(entity =>
            // {
            //     entity.HasMany<Trip>().WithOne().HasForeignKey(dt => dt.DriverId);
            // });

            // // Ensure to ignore the base User.OrderHistory if it's not used or causes conflict
            // modelBuilder.Entity<User>().Ignore(u => u.OrderHistory);
        }
    }
}
