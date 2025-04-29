using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data;
using MoneyQuiz.Data.Models;

public class QuestionController
{
    private readonly MoneyQuizDbContext _context;

    public QuestionController()
    {
        _context = new MoneyQuizDbContext();
    }

    public void AddQuestion(string text, decimal amount)
    {
        var question = new Question
        {
          QuestionText = text,
          Amount = amount
        };

        _context.Questions.Add(question);

        _context.SaveChanges();
    }

    public void EditQuestion(int id, string newText)
    {
        var question = _context.Questions.Find(id);

        if (question != null)
        {
            question.QuestionText = newText;

            _context.SaveChanges();
        }
    }

    public void PrintQuestionsAboveAmount()
    {
        var questions = _context.Questions
            .Where(q => q.Amount > 3000)
            .Select(q => q.QuestionText)
            .ToList();

        questions.ForEach(q => Console.WriteLine(q));
    }

    public void PrintAllQuestionsWithAnswers()
    {
        var questions = _context.Questions
            .Include(q => q.Answers)
            .ToList();

        foreach (var question in questions)
        {
            Console.WriteLine($"Question: {question.QuestionText}");
            foreach (var answer in question.Answers)
            {
                Console.WriteLine($" - {answer.AnswerText}");
            }
        }
    }

    public void PrintCorrectAnswerForAmount(decimal amount)
    {
        var questions = _context.Questions
            .Include(q => q.Answers)
            .Where(q => q.Amount == amount)
            .ToList();

        foreach (var question in questions)
        {
            var correct = question.Answers.FirstOrDefault(a => a.IsCorrect);
            Console.WriteLine($"Question: {question.QuestionText}");
            Console.WriteLine($"Correct: {correct?.AnswerText}");
        }
    }
}
