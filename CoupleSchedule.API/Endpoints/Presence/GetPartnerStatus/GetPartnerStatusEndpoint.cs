using CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.GetPartnerStatus;

public sealed class GetPartnerStatusEndpoint(IGetPartnerStatusHandler handler) 
    : Endpoint<GetPartnerStatusRequest, GetPartnerStatusResponse, GetPartnerStatusMapper>
{
    public override void Configure()
    {
        Get("/partners/{PartnerId}/status");
        AllowAnonymous(); //remover quando implementar o JWT
    }

    public override async Task HandleAsync(GetPartnerStatusRequest req, CancellationToken ct)
    {
        var query = Map.ToEntity(req);
        
        var dto = await handler.ExecuteAsync(query, ct);
        
        var response = Map.FromDto(dto);

        await Send.OkAsync(response, ct);
    }
}