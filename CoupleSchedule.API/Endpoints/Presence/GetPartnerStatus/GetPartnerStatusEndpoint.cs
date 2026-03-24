using System.Security.Claims;
using CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.GetPartnerStatus;

public sealed class GetPartnerStatusEndpoint(IGetPartnerStatusHandler handler)
    : Endpoint<GetPartnerStatusRequest, GetPartnerStatusResponse, GetPartnerStatusMapper>
{
    public override void Configure()
    {
        Get("/partners/partner-status");
    }

    public override async Task HandleAsync(GetPartnerStatusRequest req, CancellationToken ct)
    {
        var queryTemplate = Map.ToEntity(req);

        var myId = User.FindFirstValue("id");

        if (string.IsNullOrEmpty(myId)) await Send.UnauthorizedAsync(ct);

        var finalQuery = queryTemplate with { PartnerId = Guid.Parse(myId!) };

        var dto = await handler.ExecuteAsync(finalQuery, ct);
        await Send.OkAsync(Map.FromDto(dto), ct);
    }
}