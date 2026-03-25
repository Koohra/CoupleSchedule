using CoupleSchedule.Application.Identity.UseCases.Commands.RegisterPartner;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Auth.RegisterPartner;

public sealed class RegisterPartnerMapper : Mapper<RegisterPartnerRequest, RegisterPartnerResponse, RegisterPartnerCommand>
{
    public override RegisterPartnerCommand ToEntity(RegisterPartnerRequest r) => new(
        Name: r.Name,
        Password: r.Password,
        Email: r.Email
    );

    public RegisterPartnerResponse ToResponse(bool success) => new(
        Success: success,
        Message: success ? "Parceiro registrado com sucesso!" : "Falha ao registrar."
        );

}