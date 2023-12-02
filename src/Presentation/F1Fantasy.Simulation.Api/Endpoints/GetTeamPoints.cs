using F1Fantasy.Application.Simulation;
using F1Fantasy.Infrastructure.Abstractions;
using FastEndpoints;

namespace F1Fantasy.Simulation.Api.Endpoints;

public class GetTeamPoints : Endpoint<GetTeamPointsQuery, TeamPointsQueryResult>
{
    private readonly IQueryDispatcher _queryDispatcher;

    public GetTeamPoints(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    public override void Configure()
    {
        Get("/teams/{teamId}/points");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetTeamPointsQuery request, CancellationToken cancellationToken)
    {
        var result = await _queryDispatcher.Dispatch(request, cancellationToken);
        await SendOkAsync(result);
    }
}
