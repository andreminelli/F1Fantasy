using F1Fantasy.Simulation.Domain;

namespace F1Fantasy.Simulation.Infrastructure.Memory;

public class TeamRepository : ITeamRepository
{
    public Task<Team> GetById(TeamId id, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Team(id));
    }
}
