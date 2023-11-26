using F1Fantasy.Domain.Simulation;
using F1Fantasy.Infrastructure.Abstractions;

namespace F1Fantasy.Application.Simulation.Handlers;

public class GetPointsQueryHandler(ITeamRepository teamRepository) 
    : IQueryHandler<GetTeamPointsQuery, GetTeamPointsQueryResult>
{
    public async Task<GetTeamPointsQueryResult> Handle(GetTeamPointsQuery query, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetById(query.Id, cancellationToken);
        return new GetTeamPointsQueryResult(query.Id, team.Points);
    }
}
