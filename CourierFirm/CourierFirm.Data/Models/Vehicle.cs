using CourierFirm.Data.Models;
using System.ComponentModel.DataAnnotations;
using static CourierFirm.Data.Constraints.ModelConstraints.VehicleConstraints;

namespace CourierFirm.Data
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PlateNumberMaxLength)]
        public string PlateNumber { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [MaxLength(TypeMaxLength)]
        public string Type { get; set; } = null!;

        public ICollection<CourierVehicle> CourierVehicles { get; set; } 
                = new List<CourierVehicle>();
    }
}
