using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StrategyGame.Data.Configurations
{
    public class ResourceConfiguration
         : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasData(this.GenerateResources());
        }

        public IEnumerable<Resource> GenerateResources()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory);
            var json = File.ReadAllText($"{projectDirectory}/../../../../StrategyGame.Data/Data/resources.json");

            var resources = JsonConvert.DeserializeObject<List<Resource>>(json)
                ?? throw new Exception("Invalid json file path");

            return resources;
        }
    }
}
