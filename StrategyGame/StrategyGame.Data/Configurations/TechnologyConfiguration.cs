using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StrategyGame.Data.Configurations
{
    public class TechnologyConfiguration
          : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.HasData(this.GenerateTechnologies());
        }

        public IEnumerable<Technology> GenerateTechnologies()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory);
            var json = File.ReadAllText($"{projectDirectory}/../../../../StrategyGame.Data/Data/technologies.json");

            var technologies = JsonConvert.DeserializeObject<List<Technology>>(json)
                ?? throw new Exception("Invalid json file path");

            return technologies;
        }
    }
}
