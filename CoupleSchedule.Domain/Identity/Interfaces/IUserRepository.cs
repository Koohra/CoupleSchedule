using CoupleSchedule.Domain.Identity.Entities;

namespace CoupleSchedule.Domain.Identity.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<bool> EmailExistsAsync(string email);
}