using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace MoneyQuiz.Data.Models
{
    [PrimaryKey(nameof(PlayerId), nameof(GameSessionId))]
    public class PlayerGameSession
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; } = null!;

        public int GameSessionId { get; set; }
        [ForeignKey(nameof(GameSessionId))]
        public GameSession GameSession { get; set; } = null!;

        public ICollection<Lifeline> Lifelines { get; set; }
            = new List<Lifeline>();

        public ICollection<PlayerAnswer> PlayerAnswers { get; set; }
            = new List<PlayerAnswer>();
    }
}
