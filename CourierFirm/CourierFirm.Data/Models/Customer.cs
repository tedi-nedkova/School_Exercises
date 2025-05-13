using System.ComponentModel.DataAnnotations;
using static CourierFirm.Data.Constraints.ModelConstraints.CustomerConstraints;

namespace CourierFirm.Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [MaxLength(EmailMaxLength)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MaxLength(PhoneMaxLength)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        public ICollection<Package> Packages { get; set; } 
                = new List<Package>();
    }
}
