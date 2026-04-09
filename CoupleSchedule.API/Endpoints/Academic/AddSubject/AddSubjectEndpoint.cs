using CoupleSchedule.Application.Academic.UseCases.AddSubject;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Academic.AddSubject;

public sealed class AddSubjectEndpoint(IAddSubjectHandler handler)
    : Endpoint<AddSubjectRequest, AddSubjectResponse>
{
    public override void Configure()
    {
        Post("/academic/study-tracks/{studyTrackId}/subjects");
    }

    public override async Task HandleAsync(AddSubjectRequest req, CancellationToken ct)
    {
        var trackId = Route<Guid>("studyTrackId");
        var command = new AddSubjectCommand(trackId, req.Name);
        var subjectId = await handler.ExecuteAsync(command, ct);
        await Send.OkAsync(new AddSubjectResponse(subjectId), ct);
    }
}