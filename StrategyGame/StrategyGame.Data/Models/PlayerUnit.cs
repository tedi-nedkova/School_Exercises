using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class PlayerUnit
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    [Required]
    public int UnitId { get; set; }

    [ForeignKey(nameof(UnitId))]
    public Unit Unit { get; set; }

    [Required]
    public int Quantity { get; set; }
}
