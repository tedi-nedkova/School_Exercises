using EmployeeDepartment.Data;
using EmployeeDepartment.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartment.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly EmployeeDepartmentContext context;
        public DepartmentController(EmployeeDepartmentContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await context.Departments.ToListAsync();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            context.Add(department);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            context.Departments.Update(department);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var dept = await context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dept = await context.Departments.FindAsync(id);
            context.Departments.Remove(dept);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
