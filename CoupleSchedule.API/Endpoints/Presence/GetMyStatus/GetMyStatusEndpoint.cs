using System.Security.Claims;
using CoupleSchedule.Application.Presence.UseCases.Queries.GetMyStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.GetMyStatus;

public sealed class GetMyStatusEndpoint(IGetMyStatusHandler handler)
    : EndpointWithoutRequest<GetMyStatusResponse, GetMyStatusMapper>
{
    public override void Configure()
    {
        Get("/partners/my-status");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var authenticatedId = User.FindFirstValue("id");
        
        if (string.IsNullOrEmpty(authenticatedId))
            await Send.UnauthorizedAsync(ct);
        
        var query = new GetMyStatusQuery(Guid.Parse(authenticatedId!));
        var dto = await handler.ExecuteAsync(query, ct);
        await Send.OkAsync(Map.FromEntity(dto), ct);
    }
}