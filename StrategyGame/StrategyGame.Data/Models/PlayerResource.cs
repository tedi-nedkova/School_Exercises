using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PlayerResource
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    [Required]
    public int ResourceId { get; set; }

    [ForeignKey(nameof(ResourceId))]
    public Resource Resource { get; set; }

    [Required]
    public int Amount { get; set; }
}
