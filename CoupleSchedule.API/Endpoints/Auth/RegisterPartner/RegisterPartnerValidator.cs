using FastEndpoints;
using FluentValidation;

namespace CoupleSchedule.API.Endpoints.Auth.RegisterPartner;

public sealed class RegisterPartnerValidator : Validator<RegisterPartnerRequest>
{
    public RegisterPartnerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Nome é obrigatório.")
            .MinimumLength(3)
            .WithMessage("Nome deve ter pelo menos 3 caracteres.");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("O e-mail é obrigatório")
            .EmailAddress()
            .WithMessage("O formato do e-mail é inválido");

        RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("Senha é obrigatória.")
            .MinimumLength(6)
            .WithMessage("Senha deve ter pelo menos 6 caracteres.");
    }
}