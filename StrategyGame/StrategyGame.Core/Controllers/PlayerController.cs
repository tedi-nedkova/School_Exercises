using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Core.Controllers
{
    public class PlayerController
    {
        private readonly StrategyGameDbContext context;

        public PlayerController(StrategyGameDbContext _context)
        {
            this.context = _context;
        }

        public async Task<List<PlayerResource>> GetPlayersWithResources()
        {
            var playersResources = await context.PlayerResources
                    .Include(pr => pr.Player)
                    .Include(pr => pr.Resource)
                    .ToListAsync();

            return playersResources;
        }
    }
}
