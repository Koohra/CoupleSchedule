namespace CoupleSchedule.Domain.Identity.Entities;

public sealed class User(string email, string passwordHash)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Email { get; private set; } = email;
    public string PasswordHash { get; private set; } = passwordHash;
}