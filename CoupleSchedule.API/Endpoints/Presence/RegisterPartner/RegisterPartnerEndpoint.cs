using CoupleSchedule.Application.Presence.UseCases.Commands.RegisterPartner;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.RegisterPartner;

public sealed class RegisterPartnerEndpoint(IRegisterPartnerHandler handler) 
    : Endpoint<RegisterPartnerRequest, RegisterPartnerResponse, RegisterPartnerMapper>
{
    public override void Configure()
    {
        Post("/partners/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterPartnerRequest req, CancellationToken ct)
    {
        var command = Map.ToEntity(req);
        try
        {
            await handler.ExecuteAsync(command);
            await Send.OkAsync(Map.ToResponse(true),cancellation: ct);
        }
        catch (Exception ex)
        {
            await Send.ResponseAsync(new RegisterPartnerResponse(false, ex.Message), 400, ct);
        }
        
    }
}