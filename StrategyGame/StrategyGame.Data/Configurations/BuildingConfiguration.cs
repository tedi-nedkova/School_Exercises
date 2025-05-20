using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Reflection;


namespace StrategyGame.Data.Configurations
{
    internal class BuildingConfiguration
         : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasData(this.GenerateBuildings());
        }

        public IEnumerable<Building> GenerateBuildings()
        {
            var workingDirectory = Environment.CurrentDirectory;
            string DirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var projectDirectory = Directory.GetParent(DirPath);
            var json = File.ReadAllText($"{projectDirectory}/../../../../StrategyGame.Data/Data/buildings.json");

            var buildings = JsonConvert.DeserializeObject<List<Building>>(json)
                ?? throw new Exception("Invalid json file path");

            return buildings;
        }
    }
}
