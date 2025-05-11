using CourierFirm.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CourierFirm.Data.Constraints.ModelConstraints.DeliveryRouteConstraints;

namespace CourierFirm.Data
{
    public class DeliveryRoute
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(LocationMaxLength)]
        public string StartLocation { get; set; } = null!;

        [Required]
        [MaxLength(LocationMaxLength)]
        public string EndLocation { get; set; } = null!;

        public ICollection<CourierDeliveryRoute> CourierDeliveryRoutes { get; set; } 
                = new List<CourierDeliveryRoute>();
    }
}
