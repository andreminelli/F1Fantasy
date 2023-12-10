using F1Fantasy.Infrastructure.Abstractions;
using F1Fantasy.Simulation.Domain;

namespace F1Fantasy.Simulation.Application.Handlers;

public class GetPointsQueryHandler(ITeamRepository teamRepository)
    : IQueryHandler<GetTeamPointsQuery, TeamPointsQueryResult>
{
    public async Task<TeamPointsQueryResult> Handle(GetTeamPointsQuery query, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetById(query.TeamId, cancellationToken);
        return new TeamPointsQueryResult(query.TeamId, team.Points);
    }
}
