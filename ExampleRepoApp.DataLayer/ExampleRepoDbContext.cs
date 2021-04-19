using ExampleRepoApp.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleRepoApp.DataLayer
{
    public class ExampleRepoDbContext : DbContext
    {
        public ExampleRepoDbContext() { }
        
        public ExampleRepoDbContext(DbContextOptions<ExampleRepoDbContext> options) : base(options) { }
        
        public virtual DbSet<ExampleOwner> Owners { get; set; }
        public virtual DbSet<ExampleOwnerAddress> Addresses { get; set; }
        public virtual DbSet<ExampleVehicle> Vehicles { get; set; }
        public virtual DbSet<ExampleVehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExampleOwner>()
                .HasOne(x => x.Address)
                .WithMany(x => x.Owners)
                .HasForeignKey(x => x.AddressId);

            modelBuilder.Entity<ExampleVehicle>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.OwnerId);

            modelBuilder.Entity<ExampleVehicle>()
                .HasOne(x => x.VehicleType)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.VehicleTypeId);
        }
    }
}


