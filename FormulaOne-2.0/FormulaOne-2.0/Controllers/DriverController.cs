using FormulaOne_2._0.Data.Models;
using FormulaOne_2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne_2._0.Controllers
{
    public class DriverController()
    {
        private FormulaOneExtendedContext Context { get; set; } = new FormulaOneExtendedContext();
        public async Task<List<Driver>> GetAllDrivers()
        {
            var drivers = await Context.Drivers
                .Select(d => new Driver
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    BirthDate = d.BirthDate,
                    Nationality = d.Nationality,
                })
                .ToListAsync();

            return drivers;
        }

        public async Task<Driver> GetDriverById(int id)
        {
            var driver = await Context.Drivers
                .FindAsync(id);

            return driver;
        }

        public async Task<List<Driver>> GetDriversByLastName(string lastName)
        {
            var drivers = await Context.Drivers
                .Where(d => d.LastName == lastName)
                .ToListAsync();

            return drivers;
        }

        public async Task<List<Driver>> GetDriversByNationality(string nationality)
        {
            var drivers = await Context.Drivers
               .Where(d => d.Nationality == nationality)
               .ToListAsync();

            return drivers;
        }
    }
}
