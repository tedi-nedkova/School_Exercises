using CourierFirm.Data;
using CourierFirm.Data.Models;
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
                .Include(c => c.CourierVehicles)
                .ToListAsync();
        }

        public async Task<Courier?> GetByIdAsync(int id)
        {
            return await _context.Couriers
                .Include(c => c.Office)
                .Include(c => c.CourierVehicles)
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

        public async Task AssignCouriersVehicle(int vehicleId, int courierId)
        {
            CourierVehicle courierVehicle = new CourierVehicle() 
            { 
                VehicleId = vehicleId,
                CourierId = courierId
            };

             _context.CouriersVehicles.Add(courierVehicle);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Courier>> GetCouriersByVehicleId(int vehicleId)
        {

            return await _context.CouriersVehicles
                .Where(cv => cv.VehicleId == vehicleId)
                .Select(cv => cv.Courier)
                .ToListAsync();
        }

    }
}
