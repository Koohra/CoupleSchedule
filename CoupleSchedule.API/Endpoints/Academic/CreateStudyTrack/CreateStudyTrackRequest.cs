namespace CoupleSchedule.API.Endpoints.Academic.CreateStudyTrack;

public sealed record CreateStudyTrackRequest(string Title, string Description, DateTime? TargetDate);