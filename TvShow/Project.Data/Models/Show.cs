using System.ComponentModel.DataAnnotations;

namespace Project.Data.Models
{
    public class Show
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime? AirDate { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<ShowContestant> ShowContestants { get; set; } = new List<ShowContestant>();
    }
}
