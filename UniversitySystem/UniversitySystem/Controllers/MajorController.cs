using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Data;
using UniversitySystem.Data.Models;

namespace UniversitySystem.Controllers
{
    public class MajorController
    {
        public UniversityDbContext context;

        public MajorController(UniversityDbContext _context)
        {
            context = _context;
        }

        public void AddMajor(string name, int facultyId)
        {
            var major = new Major()
            {
                Name = name,
                FacultyId = facultyId
            };

            context.Add(major);

            context.SaveChanges();
        }

        public List<Major> GetMajorsByFacultyId(int facultyId)
        {
            var majors = context.Majors
                .Where(m => m.FacultyId == facultyId)
                .ToList();

            return majors;
        }

        public List<Major> GetMajorsByName(string name)
        {
            var majors = context.Majors
                .Where(m => m.Name == name)
                .ToList();

            return majors;
        }

        public Major? GetMajorByNameAndFacultyId(string name, int facultyId)
        {
            var major = context.Majors
                .FirstOrDefault(m => m.Name == name && m.FacultyId == facultyId);

            return major;
        }
    }
}
