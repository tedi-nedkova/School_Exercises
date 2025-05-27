using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Project.Data;
using Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core
{
    public class ContestantController
    {
        private readonly ProjectDbContext _context;

        public ContestantController(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task AddContestantAsync(Contestant contestant)
        {
            await _context.Contestants.AddAsync(contestant);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contestant>> GetAllContestantsAsync()
        {
            return await _context.Contestants.ToListAsync();
        }

        public async Task AssignToShowAsync(int contestantId, int showId)
        {
            var contestant = await _context.Contestants
                .Include(c => c.ShowContestants)
                .FirstOrDefaultAsync(c => c.Id == contestantId);

            var show = await _context.Shows.FindAsync(showId);

            if (contestant != null && show != null)
            {
                var mappingTable = new ShowContestant()
                {
                    ContestantId = contestantId,
                    ShowId = showId
                };

                await _context.ShowsContestants.AddAsync(mappingTable);
                await _context.SaveChangesAsync();
            }
        }
    }
}
