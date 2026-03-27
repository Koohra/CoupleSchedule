namespace CoupleSchedule.Application.Academic.UseCases.CreateStudyTrack;

public sealed record CreateStudyCommand(
    Guid PartnerId,
    string Title,
    string Description,
    DateTime? TargetDate
);