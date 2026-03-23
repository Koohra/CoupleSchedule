using CoupleSchedule.Application.Presence.UseCases.Commands.RegisterPartner;
using CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;
using CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;
using Microsoft.Extensions.DependencyInjection;

namespace CoupleSchedule.Application.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterPartnerHandler, RegisterPartnerHandler>();
        services.AddScoped<IUpdateStatusHandler, UpdateStatusHandler>();
        services.AddScoped<IGetPartnerStatusHandler, GetPartnerStatusHandler>();

        return services;
    }
}