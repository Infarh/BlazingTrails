using FluentValidation;

using static BlazingTrails.Shared.Features.ManageTrails.TrailDTO;

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

public class TrailDTOValidator : AbstractValidator<TrailDTO>
{
    public TrailDTOValidator()
    {
        RuleFor(t => t.Name).NotEmpty().WithMessage("Please enter name");
        RuleFor(t => t.Description).NotEmpty().WithMessage("Please enter description");
        RuleFor(t => t.Location).NotEmpty().WithMessage("Please enter location");
        RuleFor(t => t.Length).GreaterThan(0).WithMessage("The length must be greater than 0");
        RuleFor(t => t.TimeInMinutes).GreaterThan(0).WithMessage("The time in minutes must be greater than 0");
        RuleFor(t => t.Route).NotEmpty().WithMessage("Please enter route instruction");

        RuleForEach(t => t.Route).SetValidator(new TrailDTORouteInstructionValidator());
    }
}

public class TrailDTORouteInstructionValidator : AbstractValidator<RouteInstruction>
{
    public TrailDTORouteInstructionValidator()
    {
        RuleFor(i => i.Stage).GreaterThan(0).WithMessage("The stage must be greater then 0");
        RuleFor(i => i.Description).NotEmpty().WithMessage("Please enter route instruction description");
    }
}