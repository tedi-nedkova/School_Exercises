using Microsoft.EntityFrameworkCore;
using MoneyQuiz.Data;
using MoneyQuiz.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Core
{
    public class AnswerController
    {
        private readonly MoneyQuizDbContext _context;

        public AnswerController()
        {
            _context = new MoneyQuizDbContext();
        }
        public void AddAnswerToQuestion(int questionId, string text, bool isCorrect)
        {
            var answer = new Answer
            {
                QuestionId = questionId,
                AnswerText = text,
                IsCorrect = isCorrect
            };
            _context.Answers.Add(answer);

            _context.SaveChanges();
        }

        public void EditAnswer(int id, string newText, bool isCorrect)
        {
            var answer = _context.Answers.Find(id);

            if (answer != null)
            {
                answer.AnswerText = newText;
                answer.IsCorrect = isCorrect;

                _context.SaveChanges();
            }
        }

    }
}
