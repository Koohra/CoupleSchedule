using FastEndpoints;
using FluentValidation;

namespace CoupleSchedule.API.Endpoints.Academic.CreateStudyTrack;

public sealed class CreateTrackValidator : Validator<CreateStudyTrackRequest>
{
    public CreateTrackValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .WithMessage("Titulo é obrigatório")
            .MinimumLength(3)
            .WithMessage("Titulo deve ter pelo menos 3 caracteres.");
    }
}