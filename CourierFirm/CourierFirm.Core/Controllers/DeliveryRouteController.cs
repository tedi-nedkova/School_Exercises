using CourierFirm.Data;
using Microsoft.EntityFrameworkCore;

namespace CourierFirm.Core.Controllers
{
    public class DeliveryRouteController
    {
        private readonly CourierFirmDbContext _context;

        public DeliveryRouteController(CourierFirmDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeliveryRoute>> GetAllAsync()
        {
            return await _context.DeliveryRoutes
                .Include(r => r.CourierDeliveryRoutes)
                .ToListAsync();
        }

        public async Task<DeliveryRoute?> GetByIdAsync(int id)
        {
            return await _context.DeliveryRoutes
                .Include(r => r.CourierDeliveryRoutes)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(DeliveryRoute route)
        {
            await _context.DeliveryRoutes.AddAsync(route);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(DeliveryRoute route)
        {
            var existingDeliveryRoute = await _context.DeliveryRoutes.FindAsync(route.Id);
            if (existingDeliveryRoute == null)
            {
                return false;
            }

            existingDeliveryRoute.StartLocation = route.StartLocation;
            existingDeliveryRoute.EndLocation = route.EndLocation;

            _context.DeliveryRoutes.Update(existingDeliveryRoute);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var route = await _context.DeliveryRoutes.FindAsync(id);

            if (route == null)
            {
                return false;
            }

            _context.DeliveryRoutes.Remove(route);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
