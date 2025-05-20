using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Core.Controllers
{
    public class BattleController
    {
        private readonly StrategyGameDbContext context;

        public BattleController(StrategyGameDbContext _context)
        {
            this.context = _context;
        }

        public async Task<List<Battle>> GetFiveBattleResults()
        {
            var battles = await context.Battles
                .Take(5)
                .ToListAsync();

            return battles;
        }
    }
}
