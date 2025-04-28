using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyQuiz.Data.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AnswerText { get; set; } = null!;

        [Required]
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; } = null!;
    }
}
