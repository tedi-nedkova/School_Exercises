using CourierFirm.Data;
using CourierFirm.Data.Enum;
using Microsoft.EntityFrameworkCore;

namespace CourierFirm.Core.Controllers
{
    public class PackageController
    {
        private readonly CourierFirmDbContext _context;

        public PackageController(CourierFirmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Package>> GetAllAsync()
        {
            return await _context.Packages
                .Include(p => p.Customer)
                .Include(p => p.Courier)
                .ToListAsync();
        }

        public async Task<Package?> GetByIdAsync(int id)
        {
            return await _context.Packages
                .Include(p => p.Customer)
                .Include(p => p.Courier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Package package)
        {
            await _context.Packages.AddAsync(package);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Package package)
        {
            var existingPackage = await _context.Packages.FindAsync(package.Id);

            if (existingPackage == null) return false;

            existingPackage.TrackingNumber = package.TrackingNumber;
            existingPackage.WeightInKg = package.WeightInKg;
            existingPackage.CustomerId = package.CustomerId;
            existingPackage.CourierId = package.CourierId;
            existingPackage.Type = package.Type;
            existingPackage.DeliveryStatus = package.DeliveryStatus;
            existingPackage.DeliveryDate = package.DeliveryDate;

            _context.Packages.Update(existingPackage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var package = await _context.Packages.FindAsync(id);

            if (package == null)
            {
                return false;
            }

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Package>> GetLateDeliveries()
        {
            return await _context.Packages
                .Where(p => p.DeliveryDate != null &&
                    p.DeliveryDate < DateTime.Now &&
                    p.DeliveryStatus != DeliveryStatusType.Delivered)
                .Include(p => p.Customer)
                .Include(p => p.Courier)
                .ToListAsync();
        }

        public async Task<List<Package>> GetPackagesByTypeAndWeight(string type, decimal minWeight, decimal maxWeight)
        {
            return await _context.Packages
                .Where(p => p.Type == type && p.WeightInKg >= minWeight && p.WeightInKg <= maxWeight)
                .ToListAsync();
        }

        public async Task<List<Package>> GetUnassignedPackages()
        {
            return await _context.Packages
                .Where(p => p.CourierId == 0) 
                .ToListAsync();
        }
    }
}
