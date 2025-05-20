using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Building
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public int BuildTime { get; set; }

    [Required]
    public int FactionId { get; set; }

    [ForeignKey(nameof(FactionId))]
    public Faction Faction { get; set; }

    public ICollection<PlayerBuilding> PlayerBuildings { get; set; }
        = new List<PlayerBuilding>();
}
