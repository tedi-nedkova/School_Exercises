using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MoneyQuiz.Data.Models
{
    public class PlayerAnswer
    {
        [Key]
        public int Id { get; set; }

        public int PlayerSessionId { get; set; }
        [ForeignKey(nameof(PlayerSessionId))]
        public PlayerGameSession PlayerGameSession { get; set; } = null!;

        public bool IsCorrect { get; set; }

        public int AnswerId { get; set; }
        [ForeignKey(nameof(AnswerId))]
        public Answer Answer { get; set; } = null!;
    }
}
