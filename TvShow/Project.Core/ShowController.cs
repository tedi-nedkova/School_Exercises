using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Data.Models;
using System;

public class ShowController
{
    private readonly ProjectDbContext _context;

    public ShowController(ProjectDbContext context)
    {
        _context = context;
    }

    public async Task AddShowAsync(Show show)
    {
        await _context.Shows.AddAsync(show);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Show>> GetAllShowsAsync()
    {
        return await _context.Shows
            .Include(s => s.Quizzes)
            .Include(s => s.ShowContestants)
            .ToListAsync();
    }
}
