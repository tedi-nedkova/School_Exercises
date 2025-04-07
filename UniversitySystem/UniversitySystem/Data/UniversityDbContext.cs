using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversitySystem.Data.Models;

namespace UniversitySystem.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
        {

        }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
                : base(options)
        {

        }

        public virtual DbSet <Faculty> Faculties{ get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=STUDENT19;Database=UniversitySystem;Integrated Security=true;TrustServerCertificate=true;");
        }
    }
}
