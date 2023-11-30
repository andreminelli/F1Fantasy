using F1Fantasy.Domain.Simulation;

namespace F1Fantasy.Infrastructure.Memory;

public class TeamRepository : ITeamRepository
{
    public Task<Team> GetById(TeamId id, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Team(id));
    }
}
