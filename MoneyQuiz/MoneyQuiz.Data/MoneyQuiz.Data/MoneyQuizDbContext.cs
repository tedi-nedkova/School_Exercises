using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data
{
    public class MoneyQuizDbContext : DbContext
    {
        public MoneyQuizDbContext()
        {
            
        }

        public MoneyQuizDbContext(DbContextOptions<MoneyQuizDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<GameSession>GameSessions { get; set; }
        public DbSet<Lifeline> Lifelines { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerAnswer> PlayersAnswers { get; set; }
        public DbSet<PlayerGameSession> PlayersGameSessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=STUDENT19;Database=MoneyQuiz;Integrated Security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
