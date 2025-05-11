
using System.ComponentModel.DataAnnotations;
using static CourierFirm.Data.Constraints.ModelConstraints.OfficeConstraints;


namespace CourierFirm.Data
{
    public class Office
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; }

        public ICollection<Courier> Couriers { get; set; } = new List<Courier>();
    }
}
