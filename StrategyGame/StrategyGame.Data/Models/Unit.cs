using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Unit
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public int AttackPower { get; set; }

    [Required]
    public int DefensePower { get; set; }

    [Required]
    public int TrainingTime { get; set; }

    [Required]
    public int FactionId { get; set; }

    [ForeignKey(nameof(FactionId))]
    public Faction Faction { get; set; }

    public ICollection<PlayerUnit> PlayerUnits { get; set; }
     = new List<PlayerUnit>();
    public ICollection<BattleUnit> BattleUnits { get; set; }
     = new List<BattleUnit>();
}
