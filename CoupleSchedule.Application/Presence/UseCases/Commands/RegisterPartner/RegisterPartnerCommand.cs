namespace CoupleSchedule.Application.Presence.UseCases.Commands.RegisterPartner;

public record RegisterPartnerCommand(
    string Name,
    string Password,
    string Email
    );