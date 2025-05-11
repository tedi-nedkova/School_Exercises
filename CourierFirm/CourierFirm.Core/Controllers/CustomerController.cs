using CourierFirm.Data;
using CourierFirm.Data.Enum;
using Microsoft.EntityFrameworkCore;

namespace CourierFirm.Core.Controllers
{
    public class CustomerController
    {
        private readonly CourierFirmDbContext _context;

        public CustomerController(CourierFirmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .Include(c => c.Packages)
                .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Packages)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);

            if (existingCustomer == null)
            {
                return false;
            }

            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.PhoneNumber = customer.PhoneNumber;

            _context.Customers.Update(existingCustomer);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return false;
            }

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Customer>> GetCustomersWithActiveDeliveries()
        {
            return await _context.Customers
                .Where(c => c.Packages.Any(p => p.DeliveryStatus != DeliveryStatusType.Delivered))
                .Include(c => c.Packages)
                .ToListAsync();
        }

        public async Task<List<Customer>> GetTopFiveCustomersByPackagesCount()
        {
            return await _context.Customers
                .OrderByDescending(c => c.Packages.Count)
                .Take(5)
                .ToListAsync();
        }
    }
}
