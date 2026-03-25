namespace CoupleSchedule.API.Endpoints.Auth.RegisterPartner;

public record RegisterPartnerRequest(
    string Name,
    string Password,
    string Email
    );