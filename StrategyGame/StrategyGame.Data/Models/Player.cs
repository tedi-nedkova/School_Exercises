using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Player
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public DateTime CreatedAt { get; set; }

    public ICollection<PlayerFaction> PlayerFactions { get; set; }
        = new List<PlayerFaction>();

    public ICollection<PlayerBuilding> PlayerBuildings { get; set; }
        = new List<PlayerBuilding>();

    public ICollection<PlayerUnit> PlayerUnits { get; set; }
     = new List<PlayerUnit>();

    public ICollection<PlayerResource> PlayerResources { get; set; }
     = new List<PlayerResource>();

    public ICollection<PlayerTechnology> PlayerTechnologies { get; set; }
     = new List<PlayerTechnology>();

    public ICollection<PlayerLocation> PlayerLocations { get; set; }
     = new List<PlayerLocation>();

}
