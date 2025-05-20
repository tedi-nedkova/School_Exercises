using System.ComponentModel.DataAnnotations;

public class Technology
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string Description { get; set; }

    [Required]
    public int ResearchTime { get; set; }

    public ICollection<PlayerTechnology> PlayerTechnologies { get; set; }
     = new List<PlayerTechnology>();
}
