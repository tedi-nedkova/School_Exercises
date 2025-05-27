using System.ComponentModel.DataAnnotations;

namespace Project.Data.Models
{
    public class Quiz
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public int ShowId { get; set; }
        public Show Show { get; set; }

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
