namespace CoupleSchedule.Application.Identity.UseCases.Commands.RegisterPartner;

public record RegisterPartnerCommand(
    string Name,
    string Password,
    string Email
    );