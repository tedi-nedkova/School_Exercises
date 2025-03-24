using System;
using System.Collections.Generic;

namespace FormulaOne_2._0.Data.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int? FoundationYear { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
