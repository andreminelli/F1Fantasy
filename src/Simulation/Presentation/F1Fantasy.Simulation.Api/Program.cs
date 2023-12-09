using F1Fantasy.Infrastructure;
using F1Fantasy.Simulation.Application;
using F1Fantasy.Simulation.Infrastructure;
using FastEndpoints;
using FastEndpoints.Swagger;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure()
    .AddSimulationInfrastructure()
    .AddApplicationHandlers<GetTeamPointsQuery>();

builder.Services
    .AddFastEndpoints()
    .AddAuthorization()
    .SwaggerDocument();

builder.Services
    .AddKeycloakAuthentication(builder.Configuration, options =>
    {
        options.Authority = "http://keycloak:8080/realms/F1Fantasy";
        options.Audience = "api-simulation";
        options.RequireHttpsMetadata = false; // Development only!!
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = "http://localhost:8888/realms/F1Fantasy",
            ValidAudience = "api-simulation",
            
        };
    });
builder.Services.AddKeycloakAuthorization(builder.Configuration);

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(config =>
    {
        config.Serializer.Options.AddCustomConverters();
    })
    .UseSwaggerGen();

app.Run();
