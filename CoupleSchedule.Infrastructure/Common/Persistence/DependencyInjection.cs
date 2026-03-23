using CoupleSchedule.Domain.Common.Interfaces;
using CoupleSchedule.Domain.Identity.Interfaces;
using CoupleSchedule.Domain.Presence.Interfaces;
using CoupleSchedule.Infrastructure.Identity.Persistence.Repositories;
using CoupleSchedule.Infrastructure.Presence.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoupleSchedule.Infrastructure.Common.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPartnerRepository, PartnerRepository>();
        
        return services;
    }
}