using Ardalis.ApiEndpoints;
using BlazingTrails.Api.Persistence;
using BlazingTrails.Api.Persistence.Entities;
using BlazingTrails.Shared.Features.ManageTrails;
using Microsoft.AspNetCore.Mvc;

namespace BlazingTrails.Api.Features.ManageTrails;

public class AddTrailEndpoint(BlazingTrailsContext Database, ILogger<AddTrailEndpoint> Logger) : EndpointBaseAsync
    .WithRequest<AddTrailRequest>
    .WithActionResult<int>
{
    [HttpPost(AddTrailRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddTrailRequest request, CancellationToken Cancel = default)
    {
        Logger.LogInformation("Запись маршрута в БД {trail}", request.Trail);

        var trail = new Trail
        {
            Name = request.Trail.Name,
            Description = request.Trail.Description,
            Location = request.Trail.Location,
            TimeInMinutes = request.Trail.TimeInMinutes,
            Length = request.Trail.Length,
        };

        await Database.AddAsync(trail, Cancel);

        var route = request.Trail.Route.Select(t => new RouteInstruction
        {
            Stage = t.Stage,
            Description = t.Description,
            Trail = trail,
        });

        await Database.AddRangeAsync(route, Cancel);

        await Database.SaveChangesAsync(Cancel);

        Logger.LogInformation("Запись маршрута в БД {trail} выполнена успешно", request.Trail);

        return Ok(trail.Id);
    }
}
