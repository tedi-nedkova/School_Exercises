using Microsoft.EntityFrameworkCore;
using RetailChainData.Entities;

namespace RetailChainData
{
    public class RetailChainContext : DbContext
    {
        public RetailChainContext(DbContextOptions<RetailChainContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
