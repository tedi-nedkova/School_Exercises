using CourierFirm.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CourierFirm.Data.Constraints.ModelConstraints.CourierConstraints;

namespace CourierFirm.Data
{
    public class Courier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public int OfficeId { get; set; }
        [ForeignKey(nameof(OfficeId))]
        public Office Office { get; set; } = null!;

        public int? VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; } = null!;

        public ICollection<Package> Packages { get; set; } 
                = new List<Package>();

        public ICollection<CourierDeliveryRoute> CourierDeliveryRoutes { get; set; }
                = new List<CourierDeliveryRoute>();
    }
}
