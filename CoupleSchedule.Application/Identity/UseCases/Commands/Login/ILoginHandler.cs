namespace CoupleSchedule.Application.Identity.UseCases.Commands.Login;

public interface ILoginHandler
{
    Task<LoginDto> ExecuteAsync(LoginCommand command);
}