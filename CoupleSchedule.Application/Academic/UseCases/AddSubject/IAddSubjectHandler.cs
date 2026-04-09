namespace CoupleSchedule.Application.Academic.UseCases.AddSubject;

public interface IAddSubjectHandler
{
    Task<Guid> ExecuteAsync(AddSubjectCommand command, CancellationToken ct = default);
}