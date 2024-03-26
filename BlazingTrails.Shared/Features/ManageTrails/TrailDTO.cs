namespace BlazingTrails.Shared.Features.ManageTrails;

public class TrailDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public string Location { get; set; } = "";

    public int TimeInMinutes { get; set; }

    public int Length { get; set; }

    public List<RouteInstruction> Route { get; set; } = [];

    public class RouteInstruction
    {
        public int Stage { get; set; }

        public string Description { get; set; } = "";
    }
 }
