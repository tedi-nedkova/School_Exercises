using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Data;
using UniversitySystem.Data.Models;

namespace UniversitySystem.Controllers
{
    public class FacultyController
    {
        public UniversityDbContext context;

        public FacultyController(UniversityDbContext _context)
        {
            context = _context;
        }

        public void AddFaculty(string name, int universityId)
        {
            var faculty = new Faculty()
            {
                Name = name,
                UniversityId = universityId
            };

            context.Faculties.Add(faculty);

            context.SaveChanges();
        }

        public List<Faculty> GetFacultiesByUniversityId(int universityId)
        {
            var faculties = context.Faculties
                .Where(f => f.UniversityId == universityId)
                .ToList();

            return faculties;
        }

        public List<Faculty> GetFacultiesByName(string name)
        {
            var faculties = context.Faculties
                .Where(f => f.Name == name)
                .ToList();

            return faculties;
        }

        public Faculty? GetFacultyByNameAndUniversityId(string name, int universityId)
        {
            var faculty = context.Faculties
                .FirstOrDefault(f => f.Name == name && f.UniversityId == universityId);

            return faculty;
        }
    }
}
