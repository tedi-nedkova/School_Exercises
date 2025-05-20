using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PlayerFaction
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    [Required]
    public int FactionId { get; set; }

    [ForeignKey(nameof(FactionId))]
    public Faction Faction { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
}
