using CoupleSchedule.Domain.Presence.Enums;

namespace CoupleSchedule.API.Endpoints.Presence.UpdateStatus;

public record UpdateStatusRequest(
    string Activity,
    int FocusId
);