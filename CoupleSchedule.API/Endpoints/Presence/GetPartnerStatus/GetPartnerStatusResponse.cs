namespace CoupleSchedule.API.Endpoints.Presence.GetPartnerStatus;

public record GetPartnerStatusResponse(
    string Name,
    string Activity,
    string FocusName,
    string FocusDescription,
    DateTime LastSeen
);