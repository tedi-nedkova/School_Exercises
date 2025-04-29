using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace MoneyQuiz.Data.Models
{
    public class PlayerGameSession
    {
        [Key]
        public int Id { get; set; }
        
        public int PlayerId { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; } = null!;

        public int GameSessionId { get; set; }
        [ForeignKey(nameof(GameSessionId))]
        public virtual GameSession GameSession { get; set; } = null!;

        public ICollection<Lifeline> Lifelines { get; set; }
            = new List<Lifeline>();

        public ICollection<PlayerAnswer> PlayerAnswers { get; set; }
            = new List<PlayerAnswer>();
    }
}
