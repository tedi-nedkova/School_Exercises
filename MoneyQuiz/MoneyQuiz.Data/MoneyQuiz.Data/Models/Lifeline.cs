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

        public int UsedOnQuestionId { get; set; }

        [ForeignKey(nameof(UsedOnQuestionId))]
        public Question UserOnQuestion { get; set; } = null!;


        public int PlayerGameSessionId { get; set; }

        [ForeignKey(nameof(PlayerGameSessionId))]
        public PlayerGameSession PlayerGameSession { get; set; } = null!;
    }
}
