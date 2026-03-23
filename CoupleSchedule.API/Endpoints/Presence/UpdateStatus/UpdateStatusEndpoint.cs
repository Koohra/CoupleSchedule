using CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Presence.UpdateStatus;

public sealed class UpdateStatusEndpoint(IUpdateStatusHandler handler)
    : Endpoint<UpdateStatusRequest, UpdateStatusResponse, UpdateStatusMapper>
{
    public override void Configure()
    {
        Put("/partners/update-status");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateStatusRequest req, CancellationToken ct)
    {
        var command = Map.ToEntity(req);
        await handler.ExecuteAsync(command);
        await Send.OkAsync(Map.ToResponse(true), ct);
    }
}