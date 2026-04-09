using CoupleSchedule.Domain.Academic.Interfaces;
using CoupleSchedule.Domain.Common.Interfaces;

namespace CoupleSchedule.Application.Academic.UseCases.AddSubject;

public sealed class AddSubjectHandler(IStudyTrackRepository studyTrackRepo, IUnitOfWork unitOfWork) 
    : IAddSubjectHandler
{
    public async Task<Guid> ExecuteAsync(AddSubjectCommand command, CancellationToken ct = default)
    {
        var studyTrack = await studyTrackRepo.GetByIdAsync(command.StudyTrackId, ct);
        if (studyTrack is null) throw new ArgumentException("Study track not found");
        
        var subjectId    = studyTrack.AddSubject(command.Name);
        await unitOfWork.CommitAsync();
        return subjectId;
    }
}