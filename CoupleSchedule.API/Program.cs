using CoupleSchedule.Application.Common;
using CoupleSchedule.Infrastructure.Common;
using CoupleSchedule.Infrastructure.Common.Persistence;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("WebApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddAuth(builder.Configuration);

builder.Services.AddSignalR();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
    

var app = builder.Build();

app.UseCors("WebApp");

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();
app.UseSwaggerGen();
app.MapHub<CoupleSchedule.Infrastructure.Presence.SignalR.PresenceHub>("/hubs/presence");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();

