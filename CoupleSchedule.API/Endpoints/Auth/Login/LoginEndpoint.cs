using CoupleSchedule.Application.Identity.UseCases.Commands.Login;
using FastEndpoints;

namespace CoupleSchedule.API.Endpoints.Auth.Login;

public sealed class LoginEndpoint(ILoginHandler loginHandler) 
    : Endpoint<LoginRequest, LoginResponse, LoginMapper>
{
    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var command = Map.ToEntity(req);
        
        var result = await loginHandler.ExecuteAsync(command);
        
        if (!result.Success)
            await Send.UnauthorizedAsync(ct);
        
        await Send.OkAsync(Map.FromDto(result), ct);
    }
}