namespace CoupleSchedule.Application.Identity.UseCases.Commands.Login;

public record LoginDto(bool Success, string Token = "", string Message = "");