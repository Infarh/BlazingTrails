using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazingTrails.Api.Persistence.Entities;

public class Trail
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Image { get; set; }

    public string Location { get; set; } = null!;

    public int TimeInMinutes { get; set; }

    public int Length { get; set; }

    public ICollection<RouteInstruction> Route { get; set; } = new HashSet<RouteInstruction>();
}

public class TrailConfig : IEntityTypeConfiguration<Trail>
{
    public void Configure(EntityTypeBuilder<Trail> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Location).IsRequired();
        builder.Property(p => p.TimeInMinutes).IsRequired();
        builder.Property(p => p.Length).IsRequired();
    }
}