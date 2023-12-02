using F1Fantasy.Domain.Simulation;
using F1Fantasy.Infrastructure.Abstractions;

namespace F1Fantasy.Application.Simulation;

public record GetTeamPointsQuery : IQuery<GetTeamPointsQuery, TeamPointsQueryResult>
{
    public TeamId? TeamId { get; init; }
}

public record TeamPointsQueryResult(TeamId Id, double Points) : IQueryResult;