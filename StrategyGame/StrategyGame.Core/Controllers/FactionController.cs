using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Core.Controllers
{
    public class FactionController
    {
        private readonly StrategyGameDbContext context;

        public FactionController(StrategyGameDbContext _context)
        {
            this.context = _context;
        }

        public async Task<List<Faction>> GetFactionUnitsAndBuildings()
        {
             var faction = await context.Factions
                .Include(f => f.Units)
                .Include(f => f.Buildings)
                .Where(f => f.Name == "Human")
                .ToListAsync();

            return faction;
        }
    }
}
