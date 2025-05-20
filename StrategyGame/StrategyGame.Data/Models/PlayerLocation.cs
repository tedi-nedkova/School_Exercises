using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PlayerLocation
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    [Required]
    public int MapId { get; set; }

    [ForeignKey(nameof(MapId))]
    public Map Map { get; set; }

    [Required]
    public int X { get; set; }

    [Required]
    public int Y { get; set; }
}
