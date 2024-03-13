namespace BlazingTrails.Client.Features.Home;

public class Trail
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public string Image { get; set; } = null!;
    
    public string Location { get; set; } = null!;
    
    public int TimeInMinutes { get; set; }

    public string TimeFormatted => $"{TimeInMinutes / 60}h {TimeInMinutes % 60}m";

    public int Length { get; set; }

    public IEnumerable<RouteInstruction> Route { get; set; } = [];
}
