using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Data.Models;
using System;

namespace Project.Core
{
    public class QuizController
    {
        private readonly ProjectDbContext _context;

        public QuizController(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Quiz>> GetAllQuizzesAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task AssignQuizToShowAsync(int showId, int )
        {
            var show = await _context.Shows.FindAsync(showId);

            if (show != null)
            {
                show.
            }
        }
    }
}
