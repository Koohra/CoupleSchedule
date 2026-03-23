namespace CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;

public record PartnerStatusDTO(
    string Name,
    string Activity,
    string FocusName,
    string FocusDescription,
    DateTime LastSeen
);