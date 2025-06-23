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

            string filePath = @"../../../../../CourierFirm.Data/Data/customers.txt";

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
                    FirstName = parts[0],
                    LastName = parts[1],
                    Email = parts[2],
                    PhoneNumber = parts[3],
                    Address = parts[4]
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

            string filePath = @"../../../../../CourierFirm.Data/Data/offices.txt";
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
                if (parts.Length != 2) continue;

                offices.Add(new Office
                {
                    Name = parts[0],
                    Location = parts[1]
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

            string filePath = @"../../../../../CourierFirm.Data/Data/vehicles.txt";
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
                if (parts.Length != 3) continue;

                vehicles.Add(new Vehicle
                {
                    Model = parts[0],
                    PlateNumber = parts[1],
                    Type = parts[2]
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

            string filePath = @"../../../../../CourierFirm.Data/Data/couriers.txt";
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
                if (parts.Length != 2) continue;

                couriers.Add(new Courier
                {
                    Name = parts[0],
                    OfficeId = int.Parse(parts[1]),
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

            string filePath = @"../../../../../CourierFirm.Data/Data/packages.txt";
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
                    TrackingNumber = parts[0],
                    WeightInKg = int.Parse(parts[1]),
                    CustomerId = int.Parse(parts[2]),
                    CourierId = int.Parse(parts[3]),
                    Type = parts[4],
                    DeliveryStatus = (DeliveryStatusType)int.Parse(parts[5]),
                    DeliveryAddress = parts[6],
                    DeliveryDate = DateTime.Parse(parts[7])
                });
            }

            await context.Packages.AddRangeAsync(packages);
            await context.SaveChangesAsync();
        }

        public async Task SeedCouriersVehiclesAsync()
        {
            if (await context.CouriersVehicles.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../../CourierFirm.Data/Data/couriersVehicles.txt";
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

            await context.CouriersVehicles.AddRangeAsync(couriersVehicles);
            await context.SaveChangesAsync();
        }

        public async Task SeedDeliveryRoutesAsync()
        {
            if (await context.DeliveryRoutes.AnyAsync())
            {
                return;
            }

            string filePath = @"../../../../../CourierFirm.Data/Data/deliveryRoutes.txt";
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
                if (parts.Length != 2) continue;

                deliveryRoutes.Add(new DeliveryRoute
                {
                    StartLocation = parts[0],
                    EndLocation = parts[1]
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

            string filePath = @"../../../../../CourierFirm.Data/Data/couriersDeliveryRoutes.txt";
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
