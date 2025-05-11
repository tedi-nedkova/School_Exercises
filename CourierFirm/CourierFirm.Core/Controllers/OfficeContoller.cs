using CourierFirm.Data;
using Microsoft.EntityFrameworkCore;

namespace CourierFirm.Core.Controllers
{
    public class OfficeContoller
    {
        private readonly CourierFirmDbContext _context;

        public OfficeContoller(CourierFirmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Office>> GetAllAsync()
        {
            return await _context.Offices
                .Include(o => o.Couriers)
                .ToListAsync();
        }

        public async Task<Office?> GetByIdAsync(int id)
        {
            return await _context.Offices
                .Include(o => o.Couriers)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Office office)
        {
            await _context.Offices.AddAsync(office);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Office office)
        {
            var existingOffice = await _context.Offices.FindAsync(office.Id);

            if (existingOffice == null)
            {
                return false;
            }

            existingOffice.Name = office.Name;
            existingOffice.Location = office.Location;

            _context.Offices.Update(existingOffice);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var office = await _context.Offices.FindAsync(id);

            if (office == null)
            {
                return false;
            }

            _context.Offices.Remove(office);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Office> GetOfficeWithMostCouriers()
        {
            return await _context.Offices
                .OrderByDescending(o => o.Couriers.Count)
                .FirstAsync();
        }
    }
}
