using Microsoft.EntityFrameworkCore;
using Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {

        }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
                : base(options)
        {

        }

        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowContestant> ShowsContestants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=STUDENT19;Database=ProjectDb;Integrated Security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShowContestant>()
                .HasKey(sc => new { sc.ShowId, sc.ContestantId });

            modelBuilder.Entity<ShowContestant>()
                .HasOne(sc => sc.Show)
                .WithMany(s => s.ShowContestants)
                .HasForeignKey(sc => sc.ShowId);

            modelBuilder.Entity<ShowContestant>()
                .HasOne(sc => sc.Contestant)
                .WithMany(c => c.ShowContestants)
                .HasForeignKey(sc => sc.ContestantId);

            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.Show)
                .WithMany(s => s.Quizzes)
                .HasForeignKey(q => q.ShowId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(z => z.Questions)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
