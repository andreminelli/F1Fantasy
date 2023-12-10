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

builder.Services
    .AddAuthentication()
    .AddJwtBearer();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(config =>
    {
        config.Serializer.Options.AddCustomConverters();
    })
    .UseSwaggerGen();

app.Run();
