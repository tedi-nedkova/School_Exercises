using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PlayerTechnology
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    [Required]
    public int TechnologyId { get; set; }

    [ForeignKey(nameof(TechnologyId))]
    public Technology Technology { get; set; }

    [Required]
    public bool IsResearched { get; set; }

    public DateTime? ResearchedAt { get; set; }
}
