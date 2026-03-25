using CoupleSchedule.Application.Common;
using CoupleSchedule.Infrastructure.Common.Persistence;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("WebApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddAuth(builder.Configuration);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
    

var app = builder.Build();

app.UseCors("WebApp");

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();
app.UseSwaggerGen();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();

