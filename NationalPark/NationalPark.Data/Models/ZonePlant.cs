using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalPark.Data.Models
{
    public class ZonePlant
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public int PlantId { get; set; }
        public string Density { get; set; }

        public Zone Zone { get; set; }
        public PlantSpecies PlantSpecies { get; set; }
    }
}
