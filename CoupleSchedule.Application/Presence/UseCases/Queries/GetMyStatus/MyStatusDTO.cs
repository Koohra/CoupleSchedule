namespace CoupleSchedule.Application.Presence.UseCases.Queries.GetMyStatus;

public record MyStatusDto(
    string Name,
    string Activity,
    string FocusName,
    string FocusDescription,
    DateTime LastSeen
);