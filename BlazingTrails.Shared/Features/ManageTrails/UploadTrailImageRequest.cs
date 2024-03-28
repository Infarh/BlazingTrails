using System.Runtime.CompilerServices;

using MediatR;

using Microsoft.AspNetCore.Components.Forms;

namespace BlazingTrails.Shared.Features.ManageTrails;

public record UploadTrailImageRequest(int TrailId, IBrowserFile File) : IRequest<UploadTrailImageRequest.Response>
{
    public const string RouteTemplate = "/api/trails/{TrailId}/images";

    public string Route => RouteTemplate.Replace("{TrailId}", TrailId.ToString());
    //public string Route => DefaultInterpolatedStringHandler

    public record Response(string ImageName);
}
