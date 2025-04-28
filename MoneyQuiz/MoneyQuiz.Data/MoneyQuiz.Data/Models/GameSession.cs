using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Models
{
    public class GameSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public decimal FinalAmount { get; set; }

        public ICollection<PlayerGameSession> PlayersGameSessions { get; set; }
           = new List<PlayerGameSession>();
    }
}
