namespace CoupleSchedule.Application.Identity.UseCases.Commands.RegisterPartner;

public interface IRegisterPartnerHandler
{
    Task ExecuteAsync(RegisterPartnerCommand command);
}