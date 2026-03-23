using CoupleSchedule.Application.Common;
using CoupleSchedule.Infrastructure.Common.Persistence;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
    

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();

