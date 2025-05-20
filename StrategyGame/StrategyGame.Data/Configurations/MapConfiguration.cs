using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StrategyGame.Data.Configurations
{
    public class MapConfiguration
         : IEntityTypeConfiguration<Map>
    {
        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder.HasData(this.GenerateMaps());
        }

        public IEnumerable<Map> GenerateMaps()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory);
            var json = File.ReadAllText($"{projectDirectory}/../../../../StrategyGame.Data/Data/maps.json");

            var maps = JsonConvert.DeserializeObject<List<Map>>(json)
                ?? throw new Exception("Invalid json file path");

            return maps;
        }
    }
}
