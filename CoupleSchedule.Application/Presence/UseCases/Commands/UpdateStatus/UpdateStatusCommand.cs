using CoupleSchedule.Domain.Presence.Enums;

namespace CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;

public record UpdateStatusCommand(
    Guid MyId,
    string Activity,
    int Focus
);