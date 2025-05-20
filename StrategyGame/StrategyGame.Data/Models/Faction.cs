using System.ComponentModel.DataAnnotations;

public class Faction
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(40)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<PlayerFaction> PlayerFactions { get; set; }
    public ICollection<Building> Buildings { get; set; }
           = new List<Building>();
    public ICollection<Unit> Units { get; set; }
     = new List<Unit>();
}
