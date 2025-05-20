using StrategyGame.Core.Controllers;

namespace StrategyGame.ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
           StrategyGameDbContext context = new StrategyGameDbContext();

            BattleController battleController = new BattleController(context);
            FactionController factionController = new FactionController(context);
            PlayerController playerController = new PlayerController(context);


            Console.WriteLine("First Query");
            var players = await playerController.GetPlayersWithResources();

            players.ForEach(pr => Console.WriteLine($"{pr.Player.Username} - {pr.Resource.Name}"));

            Console.WriteLine("Second Query");
            var battles = await battleController.GetFiveBattleResults();

            battles.ForEach(b => Console.WriteLine($"{b.StartedAt} - {b.EndedAt} {b.Result}"));

            Console.WriteLine("Third Query");
            var factions = await factionController.GetFactionUnitsAndBuildings();

            foreach (var item in factions)
            {
                Console.WriteLine(item.Name);
                foreach (var item1 in item.Units)
                {
                    Console.WriteLine(item1.Name);
                }
                foreach (var item2 in item.Units)
                {
                    Console.WriteLine(item2.Name);
                }
            }

        }
    }
}
