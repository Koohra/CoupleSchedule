namespace CoupleSchedule.API.Endpoints.Presence.RegisterPartner;

public record RegisterPartnerRequest(
    string Name,
    string Password,
    string Email
    );