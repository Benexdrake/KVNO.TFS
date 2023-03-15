namespace KVNO.TFS.Server.Data;

public class DevOpsDbContext : DbContext
{
    public DbSet<DevOpsCollection> Collections { get; set; }
    public DbSet<DevOpsProject> Projects { get; set; }
    public DbSet<DevOpsWorkItem> WorkItems { get; set; }

    public DevOpsDbContext(DbContextOptions<DevOpsDbContext> options) : base(options)
    {
    }
}
