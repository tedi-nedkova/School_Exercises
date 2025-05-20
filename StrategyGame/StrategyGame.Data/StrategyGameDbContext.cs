using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class StrategyGameDbContext : DbContext
{
    public StrategyGameDbContext(DbContextOptions<StrategyGameDbContext> options)
      : base(options)
    {
    }
    public StrategyGameDbContext()
    {
            
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Faction> Factions { get; set; }
    public DbSet<PlayerFaction> PlayerFactions { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<PlayerBuilding> PlayerBuildings { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<PlayerUnit> PlayerUnits { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<PlayerResource> PlayerResources { get; set; }
    public DbSet<Battle> Battles { get; set; }
    public DbSet<BattleUnit> BattleUnits { get; set; }
    public DbSet<Map> Maps { get; set; }
    public DbSet<PlayerLocation> PlayerLocations { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<PlayerTechnology> PlayerTechnologies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=STUDENT19;Database=StrategyGame;Integrated Security=true;TrustServerCertificate=true;");
    }
}
