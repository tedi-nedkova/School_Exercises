using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Data.Configurations
{
    public class FactionConfiguration
            : IEntityTypeConfiguration<Faction>
    {
        public void Configure(EntityTypeBuilder<Faction> builder)
        {
            builder.HasData(this.GenerateFactions());
        }

      
        public IEnumerable<Faction> GenerateFactions()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory);
            var json = File.ReadAllText($"{projectDirectory}/../../../../StrategyGame.Data/Data/factions.json");

            var factions = JsonConvert.DeserializeObject<List<Faction>>(json)
                ?? throw new Exception("Invalid json file path");

            return factions;
        }
    }
}
