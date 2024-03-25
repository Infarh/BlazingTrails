using BlazingTrails.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazingTrails.Api.Persistence;

public class BlazingTrailsContext : DbContext
{
    public DbSet<Trail> Trails { get; set; } = null!;

    public DbSet<RouteInstruction> RouteInstructions { get; set; } = null!;

    public BlazingTrailsContext(DbContextOptions<BlazingTrailsContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TrailConfig());
        modelBuilder.ApplyConfiguration(new RouteInstructionConfig());
    }
}
