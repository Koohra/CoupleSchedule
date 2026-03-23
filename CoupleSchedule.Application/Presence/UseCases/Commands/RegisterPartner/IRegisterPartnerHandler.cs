namespace CoupleSchedule.Application.Presence.UseCases.Commands.RegisterPartner;

public interface IRegisterPartnerHandler
{
    Task ExecuteAsync(RegisterPartnerCommand command);
}