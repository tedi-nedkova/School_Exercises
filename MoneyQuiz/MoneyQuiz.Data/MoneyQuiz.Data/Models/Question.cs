using System.ComponentModel.DataAnnotations;

namespace MoneyQuiz.Data.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        public ICollection<Answer> Answers { get; set; }
            = new List<Answer>();
    }
}
