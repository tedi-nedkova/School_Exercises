using CourierFirm.Data;
using CourierFirm.Data.Enum;
using CourierFirm.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourierFirm.Core
{
    public class DataSeed
    {
        private readonly CourierFirmDbContext context;

        public DataSeed(CourierFirmDbContext _context)
        {
           context = _context;
        }

        public async Task SeedCustomersAsync()
        {
            if (await context.Customers.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../CourierFirm.Data/Data/customers.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            var customers = new List<Customer>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 5) continue;

                customers.Add(new Customer
                {
                    Id = int.Parse(parts[0]),
                    FirstName = parts[1],
                    LastName = parts[2],
                    Email = parts[3],
                    PhoneNumber = parts[4]
                });
            }

            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }

        public async Task SeedOfficesAsync()
        {
            if (await context.Offices.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../CourierFirm.Data/Data/offices.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            var offices = new List<Office>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 3) continue;

                offices.Add(new Office
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Location = parts[2]
                });
            }

            await context.Offices.AddRangeAsync(offices);
            await context.SaveChangesAsync();
        }

        public async Task SeedVehiclesAsync()
        {
            if (await context.Vehicles.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../CourierFirm.Data/Data/vehicles.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            var vehicles = new List<Vehicle>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 4) continue;

                vehicles.Add(new Vehicle
                {
                    Id = int.Parse(parts[0]),
                    Model = parts[1],
                    PlateNumber = parts[2],
                    Type = parts[3]
                });
            }

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();
        }

        public async Task SeedCouriersAsync()
        {
            if (await context.Couriers.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../CourierFirm.Data/Data/couriers.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            var couriers = new List<Courier>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 4) continue;

                couriers.Add(new Courier
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    OfficeId = int.Parse(parts[2]),
                    VehicleId = int.Parse(parts[3])
                });
            }

            await context.Couriers.AddRangeAsync(couriers);
            await context.SaveChangesAsync();
        }

        public async Task SeedPackagesAsync()
        {
            if (await context.Packages.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../CourierFirm.Data/Data/packages.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            var packages = new List<Package>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 8) continue;

                packages.Add(new Package
                {
                    Id = int.Parse(parts[0]),
                    TrackingNumber = parts[1],
                    WeightInKg = int.Parse(parts[2]),
                    CustomerId = int.Parse(parts[3]),
                    CourierId = int.Parse(parts[4]),
                    Type = parts[5],
                    DeliveryStatus = (DeliveryStatusType)int.Parse(parts[6]),
                    DeliveryDate = DateTime.Parse(parts[7])
                });
            }

            await context.Packages.AddRangeAsync(packages);
            await context.SaveChangesAsync();
        }

        public async Task SeedCouriersVehiclesAsync()
        {
            if (await context.CouriersVehicle.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../CourierFirm.Data/Data/couriersVehicles.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            var couriersVehicles = new List<CourierVehicle>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 2) continue;

                couriersVehicles.Add(new CourierVehicle
                {
                    CourierId = int.Parse(parts[0]),
                    VehicleId = int.Parse(parts[1])
                });
            }

            await context.CouriersVehicle.AddRangeAsync(couriersVehicles);
            await context.SaveChangesAsync();
        }

        public async Task SeedDeliveryRoutesAsync()
        {
            if (await context.DeliveryRoutes.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../CourierFirm.Data/Data/deliveryroutes.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            var deliveryRoutes = new List<DeliveryRoute>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 3) continue;

                deliveryRoutes.Add(new DeliveryRoute
                {
                    Id = int.Parse(parts[0]),
                    StartLocation = parts[1],
                    EndLocation = parts[2]
                });
            }

            await context.DeliveryRoutes.AddRangeAsync(deliveryRoutes);
            await context.SaveChangesAsync();
        }

        public async Task SeedCouriersDeliveryRoutesAsync()
        {
            if (await context.CouriersDeliveryRoutes.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../CourierFirm.Data/Data/deliveryroutes.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = await File.ReadAllLinesAsync(filePath);
            var couriersDeliveryRoutes = new List<CourierDeliveryRoute>();

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length != 2) continue;

                couriersDeliveryRoutes.Add(new CourierDeliveryRoute
                {
                    CourierId = int.Parse(parts[0]),
                    DeliveryRouteId = int.Parse(parts[1])
                });
            }

            await context.CouriersDeliveryRoutes.AddRangeAsync(couriersDeliveryRoutes);
            await context.SaveChangesAsync();
        }
    }
}
