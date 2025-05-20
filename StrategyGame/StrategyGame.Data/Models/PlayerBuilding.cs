using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PlayerBuilding
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    [Required]
    public int BuildingId { get; set; }

    [ForeignKey(nameof(BuildingId))]
    public Building Building { get; set; }

    public int Level { get; set; }

    [Required]
    public DateTime BuiltAt { get; set; }
}
