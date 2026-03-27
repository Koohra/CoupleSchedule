namespace CoupleSchedule.Application.Academic.UseCases.CreateStudyTrack;

public interface ICreateStudyTrackHandler
{
    Task<Guid> ExecuteAsync(CreateStudyCommand command, CancellationToken ct);
}