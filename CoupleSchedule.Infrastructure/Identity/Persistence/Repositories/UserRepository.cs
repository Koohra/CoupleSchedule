using CoupleSchedule.Domain.Identity.Entities;
using CoupleSchedule.Domain.Identity.Interfaces;
using CoupleSchedule.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoupleSchedule.Infrastructure.Identity.Persistence.Repositories;

public sealed class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task AddAsync(User user) =>
        await context.Users.AddAsync(user);

    public async Task<bool> EmailExistsAsync(string email) =>
        await context.Users.AnyAsync(c => c.Email == email);
}