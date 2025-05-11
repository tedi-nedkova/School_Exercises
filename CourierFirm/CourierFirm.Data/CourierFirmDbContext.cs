using CourierFirm.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CourierFirm.Data
{
    public class CourierFirmDbContext : DbContext
    {
        public CourierFirmDbContext()
        {

        }

        public CourierFirmDbContext(DbContextOptions<CourierFirmDbContext> options)
                : base(options)
        {

        }

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<CourierDeliveryRoute> CouriersDeliveryRoutes { get; set; }
        public DbSet<CourierVehicle> CouriersVehicle {  get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryRoute> DeliveryRoutes { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6VQ6QDR\\SQLEXPRESS;Database=CourierFirm;Integrated Security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
