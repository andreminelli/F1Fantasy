using F1Fantasy.Infrastructure;
using F1Fantasy.Simulation.Application;
using F1Fantasy.Simulation.Infrastructure;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure()
    .AddSimulationInfrastructure()
    .AddApplicationHandlers<GetTeamPointsQuery>();

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
