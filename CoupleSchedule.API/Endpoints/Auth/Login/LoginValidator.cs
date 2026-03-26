using FastEndpoints;
using FluentValidation;

namespace CoupleSchedule.API.Endpoints.Auth.Login;

public sealed class LoginValidator : Validator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("0 e-mail é obrigatório")
            .EmailAddress()
            .WithMessage("O formato do e-mail é invalido");

        RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("A senha é obrigatória")
            .MinimumLength(6)
            .WithMessage("A senha está com o tamanho inválido.");
    }
    
}