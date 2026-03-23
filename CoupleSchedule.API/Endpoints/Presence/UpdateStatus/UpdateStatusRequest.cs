using CoupleSchedule.Domain.Presence.Enums;

namespace CoupleSchedule.API.Endpoints.Presence.UpdateStatus;

public record UpdateStatusRequest(
    Guid PartnerId,
    string Activity,
    FocusLevel Focus
);