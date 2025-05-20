using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace StrategyGame.Data.Configurations
{
    public class UnitConfiguration
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasData(this.GenerateUnits());
        }

        public IEnumerable<Unit> GenerateUnits()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory);
            var json = File.ReadAllText($"{projectDirectory}/../../../../StrategyGame.Data/Data/units.json");

            var units = JsonConvert.DeserializeObject<List<Unit>>(json)
                ?? throw new Exception("Invalid json file path");

            return units;
        }
    }
}
