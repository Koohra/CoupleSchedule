using CoupleSchedule.Domain.Academic.Entities;
using CoupleSchedule.Domain.Academic.Interfaces;
using CoupleSchedule.Domain.Common.Interfaces;

namespace CoupleSchedule.Application.Academic.UseCases.CreateStudyTrack;

public sealed class CreateStudyTrackHandler(IStudyTrackRepository studyRepo, IUnitOfWork unitOfWork)
    : ICreateStudyTrackHandler
{
    public async Task<Guid> ExecuteAsync(CreateStudyCommand command, CancellationToken ct = default)
    {
        var studyTrack = StudyTrack.Create(
            command.PartnerId,
            command.Title,
            command.Description,
            command.TargetDate
        );

        await studyRepo.AddAsync(studyTrack, ct);
        await unitOfWork.CommitAsync();
        
        return studyTrack.Id;
    }
}