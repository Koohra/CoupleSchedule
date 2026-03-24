using CoupleSchedule.Application.Identity.UseCases.Commands.Login;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Auth.Login;

public sealed class LoginMapper : Mapper<LoginRequest, LoginResponse, LoginCommand>
{
    public override LoginCommand ToEntity(LoginRequest r) => new(
        Email: r.Email,
        Password: r.Password);
    
    public LoginResponse FromDto(LoginDto res) => new(res.Success, res.Token);
}