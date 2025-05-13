using CourierFirm.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CourierFirm.Data.Constraints.ModelConstraints.PackageConstraints;

namespace CourierFirm.Data
{
    public class Package
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TrackingNumberMaxLength)]
        public string TrackingNumber { get; set; } = null!;

        [Range(WeightInKgMin, WeightInKgMax)]
        public int WeightInKg { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        public int CourierId { get; set; }
        [ForeignKey(nameof(CourierId))]
        public Courier Courier { get; set; } = null!;

        public string? Type { get; set; }

        [Required]
        public string DeliveryAddress { get; set; } = null!;

        public DeliveryStatusType DeliveryStatus { get; set; }

        public DateTime? DeliveryDate { get; set; }
    }
}
