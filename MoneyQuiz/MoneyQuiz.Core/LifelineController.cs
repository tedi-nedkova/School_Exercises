using MoneyQuiz.Data;

public class LifelineController
{
    private readonly MoneyQuizDbContext _context;

    public LifelineController()
    {
        _context = new MoneyQuizDbContext();
    }

    public void DeleteLifeline(int id)
    {
        var lifeline = _context.Lifelines.Find(id);
        if (lifeline != null)
        {
            _context.Lifelines.Remove(lifeline);
            _context.SaveChanges();
        }
    }
}
