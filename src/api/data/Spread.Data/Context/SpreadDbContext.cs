namespace Spread.Data.Context;

public class SpreadDbContext : DbContext
{
    public SpreadDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Block> Blocks { get; set; }
    public DbSet<LookUp> LookUps { get; set; }
    public DbSet<LookUpType> LookUpTypes { get; set; }
    public DbSet<SystemParameter> SystemParameters { get; set; }
}
