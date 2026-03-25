namespace CoupleSchedule.API.Endpoints.Presence.GetMyStatus;

public record GetMyStatusResponse(
    string Name,
    string Activity,
    string FocusName,
    string FocusDescription,
    DateTime LastSeen
);