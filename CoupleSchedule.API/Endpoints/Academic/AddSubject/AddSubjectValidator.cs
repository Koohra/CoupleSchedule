using FastEndpoints;
using FluentValidation;

namespace CoupleSchedule.API.Endpoints.Academic.AddSubject;

public sealed class AddSubjectValidator : Validator<AddSubjectRequest>
{
    public AddSubjectValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("O nome da disciplina é obrigatório");
    }
}