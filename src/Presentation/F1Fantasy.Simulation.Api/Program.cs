using F1Fantasy.Infrastructure;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddApplicationHandlers<F1Fantasy.Application.Simulation.GetTeamPointsQuery>();

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app.UseFastEndpoints(config =>
    {
        config.Serializer.Options.AddCustomConverters();
    })
    .UseSwaggerGen();

app.Run();
