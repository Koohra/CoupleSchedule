using CoupleSchedule.Application.Academic.UseCases.CreateStudyTrack;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Academic.CreateStudyTrack;

public sealed class CreateStudyTrackMapper 
    : Mapper<CreateStudyTrackRequest, CreateStudyTrackResponse, CreateStudyCommand>
{
    public override CreateStudyCommand ToEntity(CreateStudyTrackRequest r) => new(
        Title: r.Title,
        Description: r.Description,
        PartnerId: Guid.Empty,
        TargetDate: r.TargetDate
    );
}