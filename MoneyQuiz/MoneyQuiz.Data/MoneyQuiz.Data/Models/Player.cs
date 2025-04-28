using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyQuiz.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Email { get; set; }

        public ICollection<PlayerGameSession> PlayersGameSessions { get; set; }
            = new List<PlayerGameSession>();
    }
}
