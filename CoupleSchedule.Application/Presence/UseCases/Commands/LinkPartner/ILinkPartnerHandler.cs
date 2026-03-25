namespace CoupleSchedule.Application.Presence.UseCases.Commands.LinkPartner;

public interface ILinkPartnerHandler
{
    Task ExecuteAsync(LinkPartnerCommand command);
}