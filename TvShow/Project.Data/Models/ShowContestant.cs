namespace Project.Data.Models
{
    public class ShowContestant
    {
        public int ShowId { get; set; }
        public Show Show { get; set; }

        public int ContestantId { get; set; }
        public Contestant Contestant { get; set; }
    }
}
