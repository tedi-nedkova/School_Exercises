using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourierFirm.Data.Models
{
    [PrimaryKey(nameof(CourierId), nameof(VehicleId))]
    public class CourierVehicle
    {
        public int CourierId { get; set; }
        [ForeignKey(nameof(CourierId))]
        public Courier Courier { get; set; } = null!;

        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; } = null!;
    }
}
