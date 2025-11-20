
namespace EmployeeDepartment.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
