namespace CoupleSchedule.Application.Academic.UseCases.AddSubject;

public sealed record AddSubjectCommand(Guid StudyTrackId, string Name);