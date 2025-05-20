using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Battle
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int AttackerId { get; set; }

    [Required]
    public int DefenderId { get; set; }

    [ForeignKey(nameof(AttackerId))]
    public Player Attacker { get; set; }

    [ForeignKey(nameof(DefenderId))]
    public Player Defender { get; set; }

    [Required]
    public DateTime StartedAt { get; set; }

    public DateTime? EndedAt { get; set; }

    [Required]
    public string Result { get; set; } = null!;

    public ICollection<BattleUnit> BattleUnits { get; set; }
        = new List<BattleUnit>();
}
