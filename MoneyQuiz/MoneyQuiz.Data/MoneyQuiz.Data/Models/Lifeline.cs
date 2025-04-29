using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyQuiz.Data.Models
{
    public class Lifeline
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = null!;

        [ForeignKey(nameof(UserOnQuestion))]
        public int UsedOnQuestionId { get; set; }

        public Question UserOnQuestion { get; set; } = null!;


        [ForeignKey(nameof(PlayerGameSession))]
        public int PlayerGameSessionId { get; set; }

        public PlayerGameSession PlayerGameSession { get; set; } = null!;
    }
}
