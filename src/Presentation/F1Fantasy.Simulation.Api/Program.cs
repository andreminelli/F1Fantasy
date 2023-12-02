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

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseFastEndpoints()
    .UseSwaggerGen();

//app.MapGet("/teams/{teamId}/points", async (IQueryDispatcher queryDispatcher, GetTeamPointsQuery request, CancellationToken cancellationToken) => 
//{
//    var result = await queryDispatcher.Dispatch(request, cancellationToken);
//    return Results.Ok(result.Points);
//})
//.WithName("GetTeamPoints")
//.WithOpenApi();

app.Run();
