using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierFirm.Data.Models
{
    [PrimaryKey(nameof(CourierId), nameof(DeliveryRouteId))]
    public class CourierDeliveryRoute
    {
        public int CourierId { get; set; }
        [ForeignKey(nameof(CourierId))]
        public Courier Courier { get; set; } = null!;

        public int DeliveryRouteId { get; set; }
        [ForeignKey(nameof(DeliveryRouteId))]
        public DeliveryRoute DeliveryRoute { get; set; } = null!;
    }
}
