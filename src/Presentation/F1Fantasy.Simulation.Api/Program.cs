using F1Fantasy.Application.Simulation;
using F1Fantasy.Domain.Simulation;
using F1Fantasy.Infrastructure;
using F1Fantasy.Infrastructure.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddApplicationHandlers<F1Fantasy.Application.Simulation.GetTeamPointsQuery>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/teams/{teamId}/points", async (IQueryDispatcher dispatcher, TeamId teamId, CancellationToken cancellationToken) => 
{
    var result = await dispatcher.Dispatch(new GetTeamPointsQuery(teamId), cancellationToken);
    return Results.Ok(result.Points);
})
.WithName("GetTeamPoints")
.WithOpenApi();

app.Run();
