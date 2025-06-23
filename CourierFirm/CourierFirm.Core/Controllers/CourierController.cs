using CourierFirm.Data;
using Microsoft.EntityFrameworkCore;

namespace CourierFirm.Core.Controllers
{
    public class CourierController
    {
        private readonly CourierFirmDbContext _context;

        public CourierController(CourierFirmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Courier>> GetAllAsync()
        {
            return await _context.Couriers
                .Include(c => c.Office)
                .Include(c => c.Vehicle)
                .ToListAsync();
        }

        public async Task<Courier?> GetByIdAsync(int id)
        {
            return await _context.Couriers
                .Include(c => c.Office)
                .Include(c => c.Vehicle)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Courier courier)
        {
            await _context.Couriers.AddAsync(courier);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Courier courier)
        {
            var existingCourier = await _context.Couriers.FindAsync(courier.Id);

            if (existingCourier == null)
            {
                return false;
            }

            existingCourier.Name = courier.Name;
            existingCourier.OfficeId = courier.OfficeId;
            existingCourier.VehicleId = courier.VehicleId;

            _context.Couriers.Update(existingCourier);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var courier = await _context.Couriers.FindAsync(id);

            if (courier == null)
            {
                return false;
            }

            _context.Couriers.Remove(courier);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Vehicle>> GetVehiclesByCourierId(int courierId)
        {
            return await _context.CouriersVehicle
                .Where(cv => cv.CourierId == courierId)
                .Select(cv => cv.Vehicle)
                .ToListAsync();
        }

        public async Task<List<DeliveryRoute>> GetDeliveryRouteByCourierName(string courierName)
        {

           return await _context.CouriersDeliveryRoutes
                .Include(cdr => cdr.Courier)
                .Include(cdr => cdr.DeliveryRoute)
                .Where(cdr => cdr.Courier.Name == courierName)
                .Select(cdr => cdr.DeliveryRoute)
                .ToListAsync();
        }

        public async Task<List<Package>> GetPackagesByCourierId(int courierId)
        {
           return await _context.Packages
                .Include(p => p.Courier)
                .Where(p => p.CourierId == courierId)
                .ToListAsync();
        }
    }
}
