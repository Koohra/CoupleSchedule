using System.Security.Claims;
using CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.UpdateStatus;

public sealed class UpdateStatusEndpoint(IUpdateStatusHandler handler)
    : Endpoint<UpdateStatusRequest, UpdateStatusResponse, UpdateStatusMapper>
{
    public override void Configure()
    {
        Put("/partners/update-status");
    }

    public override async Task HandleAsync(UpdateStatusRequest req, CancellationToken ct)
    {
        var commandTemplate = Map.ToEntity(req);

        var authenticatedId = User.FindFirstValue("id");

        if (string.IsNullOrEmpty(authenticatedId))
            await Send.UnauthorizedAsync(ct);

        var finalCommand = commandTemplate with { MyId = Guid.Parse(authenticatedId!) };

        await handler.ExecuteAsync(finalCommand);
        await Send.OkAsync(Map.ToResponse(true), ct);
    }
}