using CourierFirm.Data;
using Microsoft.EntityFrameworkCore;

namespace CourierFirm.Core.Controllers
{
    public class VehicleController
    {
        private readonly CourierFirmDbContext _context;

        public VehicleController(CourierFirmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles
                .Include(v => v.Couriers)
                .ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _context.Vehicles
                .Include(v => v.Couriers)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Vehicle vehicle)
        {
            var existing = await _context.Vehicles.FindAsync(vehicle.Id);

            if (existing == null)
            {
                return false;
            }

            existing.PlateNumber = vehicle.PlateNumber;
            existing.Model = vehicle.Model;
            existing.Type = vehicle.Type;

            _context.Vehicles.Update(existing);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return false;
            }

            _context.Vehicles.Remove(vehicle);

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


    }
}
