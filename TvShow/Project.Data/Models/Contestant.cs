using System.ComponentModel.DataAnnotations;

namespace Project.Data.Models
{
    public class Contestant
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public int? Age { get; set; }

        [EmailAddress]
        public string? ContactEmail { get; set; }

        public string? PhoneNumber { get; set; }

        public ICollection<ShowContestant> ShowContestants { get; set; } = new List<ShowContestant>();
    }
}
