using System.Security.Claims;
using CoupleSchedule.Application.Academic.UseCases.CreateStudyTrack;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Academic.CreateStudyTrack;

public sealed class CreateStudyTrackEndpoint(ICreateStudyTrackHandler handler)
    : Endpoint<CreateStudyTrackRequest, CreateStudyTrackResponse, CreateStudyTrackMapper>
{
    public override void Configure()
    {
        Post("/academic/study-tracks");
    }

    public override async Task HandleAsync(CreateStudyTrackRequest req, CancellationToken ct)
    {
        var command = Map.ToEntity(req);

        var authenticatedId = User.FindFirstValue("id");
        if (string.IsNullOrEmpty(authenticatedId))
        {
            await Send.UnauthorizedAsync(ct);
            return;
        }

        var finalCommand = command with
        {
            PartnerId = Guid.Parse(authenticatedId!),
            Description = req.Description,
            Title = req.Title,
            TargetDate = req.TargetDate
        };
        
        var trackId = await handler.ExecuteAsync(finalCommand, ct);
        await Send.OkAsync(new CreateStudyTrackResponse(trackId), ct);
    }
}