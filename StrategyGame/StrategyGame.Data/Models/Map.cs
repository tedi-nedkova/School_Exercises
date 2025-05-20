using System.ComponentModel.DataAnnotations;

public class Map
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int SizeX { get; set; }

    [Required]
    public int SizeY { get; set; }

    public string? Description { get; set; }

    public ICollection<PlayerLocation> PlayerLocations { get; set; }
     = new List<PlayerLocation>();
}
