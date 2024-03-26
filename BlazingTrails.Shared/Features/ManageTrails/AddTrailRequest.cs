using FluentValidation;
using MediatR;

namespace BlazingTrails.Shared.Features.ManageTrails;

public record AddTrailRequest(TrailDTO Trail) : IRequest<AddTrailRequest.Response>
{
    public const string RouteTemplate = "/api/trails";

    public record Response(int TrailId);
}

public class AddTrailRequestValidator : AbstractValidator<AddTrailRequest>
{
    public AddTrailRequestValidator() => RuleFor(r => r.Trail).SetValidator(new TrailDTOValidator());
}
