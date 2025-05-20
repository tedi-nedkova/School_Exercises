using System.ComponentModel.DataAnnotations;

public class Resource
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<PlayerResource> PlayerResources { get; set; }
     = new List<PlayerResource>();
}
