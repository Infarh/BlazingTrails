using System.Net.Http.Json;
using MediatR;

namespace BlazingTrails.Shared.Features.ManageTrails;

public class AddTrailHandler(HttpClient http) : IRequestHandler<AddTrailRequest, AddTrailRequest.Response>
{
    public async Task<AddTrailRequest.Response> Handle(AddTrailRequest request, CancellationToken Cancel)
    {
        var response = await http.PostAsJsonAsync(AddTrailRequest.RouteTemplate, request, Cancel).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
            return new(-1);

        var trail_id = await response.Content.ReadFromJsonAsync<int>(cancellationToken: Cancel).ConfigureAwait(false);

        return new(trail_id);
    }
}
