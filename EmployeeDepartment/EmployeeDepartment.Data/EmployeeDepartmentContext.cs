using EmployeeDepartment.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace EmployeeDepartment.Data
{
    public class EmployeeDepartmentContext : DbContext
    {
        public EmployeeDepartmentContext(DbContextOptions<EmployeeDepartmentContext> options)
           : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
