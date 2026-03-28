using CoupleSchedule.Application.Academic.UseCases.CreateStudyTrack;
using CoupleSchedule.Application.Identity.UseCases.Commands.Login;
using CoupleSchedule.Application.Identity.UseCases.Commands.RegisterPartner;
using CoupleSchedule.Application.Presence.UseCases.Commands.LinkPartner;
using CoupleSchedule.Application.Presence.UseCases.Commands.UpdateStatus;
using CoupleSchedule.Application.Presence.UseCases.Queries.GetMyStatus;
using CoupleSchedule.Application.Presence.UseCases.Queries.GetPartnerStatus;
using Microsoft.Extensions.DependencyInjection;

namespace CoupleSchedule.Application.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ILoginHandler, LoginHandler>();
        services.AddScoped<IRegisterPartnerHandler, RegisterPartnerHandler>();
        
        services.AddScoped<IUpdateStatusHandler, UpdateStatusHandler>();
        services.AddScoped<IGetPartnerStatusHandler, GetPartnerStatusHandler>();
        services.AddScoped<IGetMyStatusHandler, GetMyStatusHandler>();
        services.AddScoped<ILinkPartnerHandler, LinkPartnerHandler>();

        services.AddScoped<ICreateStudyTrackHandler, CreateStudyTrackHandler>();
        
        return services;
    }
}