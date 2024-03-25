using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazingTrails.Api.Persistence.Entities;

public class RouteInstruction
{
    public int Id { get; set; }

    public int TrailId { get; set; }

    public int Stage { get; set; }

    public string Description { get; set; } = null!;

    public Trail Trail { get; set; } = null!;
}

public class RouteInstructionConfig : IEntityTypeConfiguration<RouteInstruction>
{
    public void Configure(EntityTypeBuilder<RouteInstruction> builder)
    {
        builder.Property(p => p.TrailId).IsRequired();
        builder.Property(p => p.Stage).IsRequired();
        builder.Property(p => p.Description).IsRequired();
    }
}