using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Data;
using UniversitySystem.Data.Models;

namespace UniversitySystem.Controllers
{
    public class UniversityController
    {
        public UniversityDbContext context;

        public UniversityController(UniversityDbContext _context)
        {
            context = _context;
        }

        public void AddUniversity(string name)
        {
            var university = new University()
            {
                Name = name,
            };

            context.Universities.Add(university);

            context.SaveChanges();
        }

        public List<University> GetAllUniversities()
        {
            var universities = context.Universities
                .ToList();

            return universities;
        }

        public University? GetUniversityByName(string name)
        {
            var university = context.Universities
                .FirstOrDefault(u => u.Name == name);

            return university;
        }

        public int? GetUniversityIdByName(string name)
        {
            var university = context.Universities
               .FirstOrDefault(u => u.Name == name);

            return university.Id;
        }
    }
}
