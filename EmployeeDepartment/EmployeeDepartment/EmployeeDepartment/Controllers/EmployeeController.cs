using EmployeeDepartment.Data;
using EmployeeDepartment.Data.Entities;
using EmployeeDepartment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDepartmentContext _context;

        public EmployeeController(EmployeeDepartmentContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .ToListAsync();

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentId =
                new SelectList(_context.Departments, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            employee.Department = await _context.Departments
                .FirstAsync(d => d.Id == employee.DepartmentId);

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.DepartmentId =
                new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
                return NotFound();

            _context.Update(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
