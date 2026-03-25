namespace CoupleSchedule.Application.Presence.UseCases.Commands.LinkPartner;

public record LinkPartnerCommand(Guid MyId, string PartnerEmail);