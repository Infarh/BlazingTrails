﻿using System.Net.Http.Json;

using MediatR;

using Microsoft.Extensions.Logging;

namespace BlazingTrails.Shared.Features.ManageTrails;

public class AddTrailHandler(HttpClient http, ILogger<AddTrailHandler> Logger) : IRequestHandler<AddTrailRequest, AddTrailRequest.Response>
{
    public async Task<AddTrailRequest.Response> Handle(AddTrailRequest request, CancellationToken Cancel)
    {
        Logger.LogInformation("Отправка маршрута на сервер {request}", request);

        var response = await http.PostAsJsonAsync(AddTrailRequest.RouteTemplate, request, Cancel).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            Logger.LogWarning("Отправка маршрута на сервер выполнена с ошибкой {request}", request);
            return new(-1);
        }

        var trail_id = await response.Content.ReadFromJsonAsync<int>(cancellationToken: Cancel).ConfigureAwait(false);

        Logger.LogInformation("Отправка маршрута на сервер завершена успешно {request}", request);

        return new(trail_id);
    }
}
