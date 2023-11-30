using F1Fantasy.Domain.Simulation;
using F1Fantasy.Infrastructure.Abstractions;

namespace F1Fantasy.Application.Simulation.Handlers;

public class GetPointsQueryHandler(ITeamRepository teamRepository) 
    : IQueryHandler<GetTeamPointsQuery, TeamPointsQueryResult>
{
    public async Task<TeamPointsQueryResult> Handle(GetTeamPointsQuery query, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetById(query.Id, cancellationToken);
        return new TeamPointsQueryResult(query.Id, team.Points);
    }
}
