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
