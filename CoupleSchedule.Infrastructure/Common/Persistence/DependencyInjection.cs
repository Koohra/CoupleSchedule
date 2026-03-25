using System.Text;
using CoupleSchedule.Application.Common.Interfaces;
using CoupleSchedule.Domain.Common.Interfaces;
using CoupleSchedule.Domain.Identity.Interfaces;
using CoupleSchedule.Domain.Presence.Interfaces;
using CoupleSchedule.Infrastructure.Common.Security;
using CoupleSchedule.Infrastructure.Identity.Persistence.Repositories;
using CoupleSchedule.Infrastructure.Presence.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
        services.AddScoped<ICoupleRepository, CoupleRepository>();
        
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        
        return services;
    }
    
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        services.AddSingleton(jwtSettings!); 
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings!.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });

        services.AddAuthorization();
        return services;
    }
}