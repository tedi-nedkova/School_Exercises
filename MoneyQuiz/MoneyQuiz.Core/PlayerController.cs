using MoneyQuiz.Data.Models;
using MoneyQuiz.Data;

public class PlayerController
{
    private readonly MoneyQuizDbContext _context;

    public PlayerController()
    {
        _context = new MoneyQuizDbContext();
    }

    public void AddPlayer(string name)
    {
        var player = new Player { Name = name };
        _context.Players.Add(player);
        _context.SaveChanges();
    }
}
