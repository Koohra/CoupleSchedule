using CoupleSchedule.Application.Common.Interfaces;
using CoupleSchedule.Domain.Identity.Interfaces;

namespace CoupleSchedule.Application.Identity.UseCases.Commands.Login;

public sealed class LoginHandler(
    IUserRepository userRepo, 
    IPasswordHasher passwordHasher, 
    IJwtTokenGenerator jwtTokenGenerator) : ILoginHandler

{
    public async Task<LoginDto> ExecuteAsync(LoginCommand command)
    {
        var user = await userRepo.GetByEmailAsync(command.Email);

        if (user is null || !passwordHasher.Verify(command.Password, user.PasswordHash))
            return new LoginDto(false, Message: "Credenciais inválidas");
        
        var token = jwtTokenGenerator.GenerateToken(user.Id, user.Email);
        return new LoginDto(true, token);
    }
}